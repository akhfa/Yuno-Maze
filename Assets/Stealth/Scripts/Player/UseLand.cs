using UnityEngine;
using System.Collections;

public class UseLand : MonoBehaviour {

	private GameObject maze;
	private GameObject quad;
	public Inventory inventory;

	// Use this for initialization
	void Start () {
		maze = GameObject.FindWithTag("Maze");
		maze.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("UseLand") && inventory.InventoryContains (2)) {
			inventory.RemoveItem(2);
			Debug.Log("Ok");
			maze.SetActive (true);
		}
	}
}
