using UnityEngine;
using System.Collections;

public class Falling : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -10) {
			Debug.Log(transform.position.y);
			transform.position.Set(-2.336225f,0f,0f);
		}
	}
}
