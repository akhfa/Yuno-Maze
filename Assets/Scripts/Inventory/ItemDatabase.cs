using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item>();

	void Start() {
		items.Add(new Item("Batu", 0, "Sebuah benda padat, bisa dipijaki", 0, 0, Item.ItemType.Weapon));
		items.Add (new Item("Palu", 1, "Sebuah kakas", 0, 0, Item.ItemType.Weapon));
		items.Add (new Item("Apel", 2, "Sebuah buah-buahan bervitamin A", 0, 0, Item.ItemType.Consumable));
	}
}
