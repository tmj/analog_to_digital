using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Hand : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	Vector3 pre_world_pos;
	Vector3 world_pos;
	Vector3 mouse_screen_pos;

	GameObject holding_object;

	// Update is called once per frame
	void Update () {
		pre_world_pos = world_pos;

		mouse_screen_pos = Input.mousePosition;
		mouse_screen_pos.z = Camera.main.transform.position.y - transform.position.y;
		world_pos = Camera.main.ScreenToWorldPoint(mouse_screen_pos);
		world_pos.y = transform.position.y;
		//world_pos = Input.mousePosition;

		transform.position = world_pos;
	}

	void OnGUI() {
		GUILayout.BeginVertical();
		GUILayout.Label((world_pos - pre_world_pos).ToString(), "box");
		if(holding_object != null) {
			GUILayout.Label(holding_object.gameObject.name);
		}

		GUILayout.EndVertical();

	}

	public void OnPointerDown(BaseEventData bed) {
		Ray ray = Camera.main.ScreenPointToRay(mouse_screen_pos);
		RaycastHit result;
		if(Physics.Raycast(ray, out result)) {
			holding_object = result.collider.gameObject;
			Debug.Log("OnPointerDown");
		}
	}

	public void OnPointerUp(BaseEventData bed) {
		if (holding_object != null) {
			Rigidbody rigid_body = holding_object.GetComponent<Rigidbody>();
			rigid_body.WakeUp();
			rigid_body.AddForce((world_pos - pre_world_pos)*5000, ForceMode.Force);
			holding_object.GetComponent<EffectEmitter>().enabled = true;
			holding_object = null;
		}
	}

	public void OnDrag(BaseEventData bed) {
		if(holding_object != null) {
			Vector3 pos = this.transform.position;
			pos.y -= 1;	
			holding_object.transform.position = pos;
			holding_object.GetComponent<Rigidbody>().Sleep();
		}
	}

}


