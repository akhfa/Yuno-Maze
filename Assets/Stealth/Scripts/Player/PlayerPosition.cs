using UnityEngine;
using System.Collections;

public class PlayerPosition : MonoBehaviour {

	private GameObject player;
	Vector3 playerPos;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		playerPos = player.transform.position;
		if (playerPos.y < 0)
			Application.LoadLevel ("Level_1");
	}
}
