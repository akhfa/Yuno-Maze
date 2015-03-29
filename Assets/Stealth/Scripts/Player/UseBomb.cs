using UnityEngine;
using System.Collections;

public class UseBomb : MonoBehaviour {

	private GameObject stone;
	//public Transform bomb;
	public Inventory inventory;

	// Use this for initialization
	void Start () {
		stone = GameObject.FindWithTag("Stone");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("UseBomb") && inventory.InventoryContains(0))
		{
			Debug.Log(inventory.InventoryContains(1));
			inventory.RemoveItem(1);
			//var bombb = Instantiate(bomb, transform.position, transform.rotation);
			//transform.localScale = new Vector3(0.01F, 0.01F, 0.01F);
			StartCoroutine(placeBomb());

		}
	}

	IEnumerator placeBomb()
	{
		yield return new WaitForSeconds (5);
		Destroy(stone);
		inventory.AddItem(2);
	}
}
