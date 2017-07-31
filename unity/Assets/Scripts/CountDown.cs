using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountDown : MonoBehaviour {

	public Text text;
	bool scale = true;
	float default_scale;

	void Awake() {
		default_scale = transform.localScale.x;
	}

	// Use this for initialization
	IEnumerator Start () {
		
		text.text = 3.ToString();

		yield return new WaitForSeconds (1);

		text.gameObject.transform.localScale = Vector3.one * default_scale;
		text.text = 2.ToString();

		yield return new WaitForSeconds (1);

		text.gameObject.transform.localScale = Vector3.one * default_scale;
		text.text = 1.ToString();

		yield return new WaitForSeconds (1);

		text.gameObject.transform.localScale = Vector3.one * default_scale;
		text.text = "START!";
		scale = false;

		yield return new WaitForSeconds (1);

		text.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (scale) {
			Vector3 scale = text.gameObject.transform.localScale;
			scale -= Vector3.one * Time.deltaTime * 0.5f;
			text.transform.localScale = scale;
		}
	}
}
