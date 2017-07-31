using UnityEngine;
using System.Collections;

public class EffectEmitter : MonoBehaviour {

	public Object effectPrefab;

	void Awake() {
		enabled = false;
	}

	void OnCollisionEnter(Collision col) {
		if (enabled) {
			if (col.gameObject.GetComponent<EffectEmitter>() != null) {
				GameObject.Instantiate(effectPrefab, col.contacts[0].point, Quaternion.identity);
				enabled = false;
			}
		}
	}

}
