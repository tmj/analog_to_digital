using UnityEngine;
using System.Collections;

public class EffectEmitter : MonoBehaviour {

	public Object effectPrefab;

	void Awake() {
		enabled = false;
	}

	void OnCollisionEnter(Collision col) {
		if (enabled) {
			GameObject.Instantiate(effectPrefab, col.contacts[0].point, Quaternion.identity);
			enabled = false;
		}
	}

}
