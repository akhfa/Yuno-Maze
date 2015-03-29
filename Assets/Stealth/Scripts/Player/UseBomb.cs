using UnityEngine;
using System.Collections;

public class UseBomb : MonoBehaviour {
	public AudioClip bombSound;
	private GameObject stone;
	//public Transform bomb;
	public Inventory inventory;

	// Use this for initialization
	void Start () {
		stone = GameObject.FindWithTag("Stone");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("UseBomb") && inventory.InventoryContains(1))
		{
			Debug.Log(inventory.InventoryContains(1));
			inventory.RemoveItem(1);
			StartCoroutine(placeBomb());

		}
	}

	IEnumerator placeBomb()
	{
		yield return new WaitForSeconds (5);
		AudioSource.PlayClipAtPoint(bombSound, transform.position);
		Destroy(stone);
		inventory.AddItem(2);
	}
}
