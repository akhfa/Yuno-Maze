using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public int slotsX, slotsY;
	public List<Item> slots = new List<Item> ();
	public List<Item> inventory = new List<Item>();
	private bool showInventory = false;
	private ItemDatabase database;
	private bool showTooltip;
	private string tooltip;
	private bool draggingItem;
	private Item draggedItem;
	private int prevIndex;

	// Use this for initialization
	void Start () {
		for(int i = 0; i< (slotsX * slotsY); i++) {
			slots.Add(new Item());
			inventory.Add(new Item());
		}
		database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
		AddItem (1);
		AddItem (0);
		AddItem (1);
		AddItem (2);
	}

	void Update() {
		if(Input.GetButtonDown("Inventory")) {
			showInventory = !showInventory;
		}
	}
	
	// Update is called once per frame
	void OnGUI () {
		tooltip = "";
		if(showInventory) {
			DrawInventory();
			if(showTooltip) {
				GUI.Box (new Rect(Event.current.mousePosition.x + 15f, Event.current.mousePosition.y, 200, 200), tooltip);
			}
		}
		if(draggingItem) {
			GUI.DrawTexture(new Rect(Event.current.mousePosition.x + 15f, Event.current.mousePosition.y, 50, 50), draggedItem.itemIcon);
		}
	}

	void DrawInventory() {
		Event e = Event.current;
		int i = 0;

		for(int x = 0; x < slotsX; x++) {
			for(int y = 0; y < slotsY; y++) {
				Rect slotRect = new Rect(y * 42, x * 42, 40, 40);
				GUI.Box(slotRect, "");
				slots[i] = inventory[i];

				if(slots[i].itemName != null) {
					GUI.DrawTexture(slotRect, slots[i].itemIcon);
					if(slotRect.Contains(e.mousePosition)) {
						tooltip = CreateTooltip(slots[i]);
						showTooltip = true;

						if(e.button == 0 && e.type == EventType.mouseDrag && !draggingItem) {
							draggingItem = true;
							prevIndex = i;
							draggedItem = slots[i];
							inventory[i] = new Item();
						}
						if(e.type == EventType.mouseUp && draggingItem) {
							inventory[prevIndex] = inventory[i];
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
					}
				}
				else {
					if(slotRect.Contains(e.mousePosition)) {
						if(e.type == EventType.mouseUp && draggingItem) {
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
					}
				}

				if(tooltip == "") {
					showTooltip = false;
				}

				i++;
			}
		}
	}

	string CreateTooltip(Item item) {
		tooltip = "<color=#ffffff>" + item.itemName + "</color>\n\n" +
			"<color=#ffffff>" + item.itemDesc + "</color>";
		return tooltip;
	}

	void RemoveItem(int id) {
		for(int i = 0; i < inventory.Count; i++) {
			if(inventory[i].itemID == id) {
				inventory[i] = new Item();
				break;
			}
		}
	}

	void AddItem(int id) {
		for (int i = 0; i < inventory.Count; i++) {
			if(inventory[i].itemName == null) {
				for(int j = 0; j < database.items.Count; j++) {
					if(database.items[j].itemID == id) {
						inventory[i] = database.items[j];
					}
				}
				break;
			}
		}
	}

	bool InventoryContains(int id) {
		bool found = false;
		int i = 0;

		while(i < inventory.Count && !found) {
			if (inventory[i].itemID == id) {
				found = true;
			}

			i++;
		}

		return found;
	}
}
