using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item>();

	void Start() {
		items.Add (new Item ("Bomb", 1, "Bom Waktu \nuntuk menghancurkan batu", 0, 0, Item.ItemType.Weapon));
		items.Add (new Item ("Land", 2, "Tanah untuk \nmenutup lubang", 0, 0, Item.ItemType.Weapon));
		items.Add (new Item ("Kunci", 3, "Kunci yang digunakan\nuntuk membuka pintu", 0, 0, Item.ItemType.Weapon));
	}
}
