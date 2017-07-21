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

	Vector3 speed;
	int counter = 0;

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Space)) {
			// カメラ移動
			Vector2 size_half = new Vector2 (Screen.width, Screen.height) / 2;
			Vector2 pos_mouse = new Vector2 (Input.mousePosition.x, Input.mousePosition.y) - size_half;
			float screen_half_size = size_half.magnitude;
			float pos_size = pos_mouse.magnitude;
			Vector3 pos = Camera.main.transform.position;
			if (screen_half_size * 0.5 < pos_size) {
				Vector3 move = new Vector3 (pos_mouse.x, 0, pos_mouse.y) / size_half.magnitude * 0.5f;
				pos += move;
			}


			float wheel = Input.GetAxis ("Mouse ScrollWheel"); 
			if (wheel != 0) {
				pos += Vector3.up * wheel * 10;
			}
			Camera.main.transform.position = pos;
		}

		pre_world_pos = world_pos;

		mouse_screen_pos = Input.mousePosition;
		mouse_screen_pos.z = Camera.main.transform.position.y - transform.position.y;
		world_pos = Camera.main.ScreenToWorldPoint(mouse_screen_pos);
		world_pos.y = 5;//Camera.main.transform.position.y - 15;//transform.position.y;
		//world_pos = Input.mousePosition;

		transform.position = world_pos;
		Vector3 tmp = world_pos - pre_world_pos;
		if(tmp.magnitude >= 1.0f) {
			speed = tmp ;
			counter = 0;
		}
		else {
			counter++;
			if(counter > 2) {
				speed = Vector3.zero;

			}
		}
	}
	int aaa = 0;
	void OnGUI() {
		GUILayout.BeginVertical();
		GUILayout.Label (speed.ToString (), "box");
		GUILayout.Label((world_pos - pre_world_pos).ToString(), "box");
		if(holding_object != null) {
			GUILayout.Label(holding_object.gameObject.name);
		}

		GUILayout.EndVertical();

	}

	public void OnPointerDown(BaseEventData bed) {
		Ray ray = Camera.main.ScreenPointToRay(mouse_screen_pos);
		RaycastHit result;
		if (Physics.Raycast(ray, out result)) {
			if (result.collider.gameObject.tag == "Holdable") {
				holding_object = result.collider.gameObject;
				this.transform.localRotation = Quaternion.Euler(30, 0, 0);
			}
		}
	}

	public void OnPointerUp(BaseEventData bed) {
		if (holding_object != null) {
			Rigidbody rigid_body = holding_object.GetComponent<Rigidbody>();
			rigid_body.WakeUp();
			rigid_body.AddForce(speed * 1000, ForceMode.Force);
			rigid_body.AddTorque(speed * 200, ForceMode.Force);
			EffectEmitter ee = holding_object.GetComponent<EffectEmitter> ();
			if (ee != null) {
				ee.enabled = true;
			}
			holding_object = null;
			this.transform.localRotation = Quaternion.Euler(90, 0, 0);
		}
	}

	public void OnDrag(BaseEventData bed) {
		if(holding_object != null) {
			Vector3 pos = this.transform.position;
			pos.y = 4;	
			holding_object.transform.position = pos;
			holding_object.GetComponent<Rigidbody>().Sleep();
		}
	}

}


