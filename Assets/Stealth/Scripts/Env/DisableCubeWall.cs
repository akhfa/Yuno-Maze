using UnityEngine;
using System.Collections;

public class DisableCubeWall : MonoBehaviour {

	private GameObject wall;
	// Use this for initialization
	void Start () {
		wall = GameObject.FindWithTag ("CubeDoor");
		wall.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
