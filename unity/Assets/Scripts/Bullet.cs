using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	bool holded = false;

	public void Hold() {
		holded = true;
	}

	void OnCollisionEnter(Collision col) {
		if (holded) {
			if (col.gameObject.tag == "Ground") {
				Destroy(gameObject);
			}
		}
	}

}
