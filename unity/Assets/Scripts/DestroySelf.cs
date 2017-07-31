using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {

	public float destroyAfterSec = 1.0f;

	// Use this for initialization
	IEnumerator Start () {

		yield return new WaitForSeconds(destroyAfterSec);

		Destroy(gameObject);
	}
	
}
