using UnityEngine;
using System.Collections;

public class StoneCrash : MonoBehaviour {
	//Gak kepake
	public AudioClip keyGrab;                       // Audioclip to play when the key is picked up.
	
	
	private GameObject player;                      // Reference to the player.
	//private PlayerInventory playerInventory;        // Reference to the player's inventory.
	//private Inventory inventory;
	public Inventory inventory;
	
	
	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindWithTag("Player");
		
	}

	public IEnumerator setBomb()
	{
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
		inventory.AddItem (2);
		//AudioSource.PlayClipAtPoint(keyGrab, transform.position);
	}

}
