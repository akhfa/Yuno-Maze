using UnityEngine;
using System.Collections;

public class UseLand : MonoBehaviour {

	private GameObject maze;
	private GameObject quad;

	// Use this for initialization
	void Start () {
		maze = GameObject.FindWithTag("Maze");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("UseBomb"))
			Destroy (maze);
	}
}
