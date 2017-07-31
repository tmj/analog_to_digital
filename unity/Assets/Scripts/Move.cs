using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public float range = 5;

	float initX;

	void Awake() {
		initX = transform.position.x;
	}

	// Update is called once per frame
	void Update () {

		float ratio = Mathf.Sin(Time.time);
		Vector3 pos = transform.position;
		pos.x = initX + range * ratio;
		transform.position = pos;

	}
}
