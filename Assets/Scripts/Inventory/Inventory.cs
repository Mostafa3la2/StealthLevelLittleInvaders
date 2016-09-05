using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class Inventory : MonoBehaviour {
	GameObject inventoryPanel;
	GameObject slotPanel;
	ItemDataBase database;
	public GameObject inventorySlot;
	public GameObject inventoryItem;
	int slotAmount;
	public List<Item> items=new List<Item>();
	public List<GameObject> slots=new List<GameObject>();
	// Use this for initialization
	void Start () {
		database = GetComponent<ItemDataBase> ();
		slotAmount = 10;
		inventoryPanel = GameObject.Find ("Inventory Panel");
		slotPanel = inventoryPanel.transform.FindChild ("Slot Panel").gameObject;
		for (int i=0; i<slotAmount; i++) {
			items.Add(new Item());
			slots.Add(Instantiate(inventorySlot));
			slots[i].GetComponent<Slot>().id=i;
			slots[i].transform.SetParent(slotPanel.transform);
		}
		AddItem (0);

		AddItem (1);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void AddItem(int id){
		Item itemtoAdd = database.FetchItemByID (id);
		if (itemtoAdd.Stackable && CheckItem (itemtoAdd)) {
			for (int i=0; i<items.Count; i++) {
				if (items [i].ID == id) {
					ItemData data = slots [i].transform.GetChild (0).GetComponent<ItemData> ();
					data.amount++;
					data.transform.GetChild (0).GetComponent<Text> ().text = data.amount.ToString ();
					break;
				}
			}
		
		} else {
			for (int i=0; i<items.Count; i++) {
				if (items [i].ID == -1) {
					items [i] = itemtoAdd;
					GameObject itemObj = Instantiate (inventoryItem);
					itemObj.GetComponent<ItemData>().item=itemtoAdd;
					itemObj.transform.SetParent (slots [i].transform);
					itemObj.transform.position = Vector2.zero;
					itemObj.GetComponent<ItemData>().slot=i;
					itemObj.GetComponent<Image> ().sprite = itemtoAdd.Sprite;
					itemObj.name = itemtoAdd.Title;

					break;
				}
		
			}
		}
	}
	bool CheckItem(Item item){
		for (int i=0; i<items.Count; i++) {
			if(items[i].ID==item.ID)
				return true;
		
		}
		return false;
	}
}
