using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {

	public Score score;

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Target") {
			Destroy (col.gameObject);
			int s = int.Parse (col.gameObject.name);
			score.AddScore (s);
		}
	}
}
