using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDataBase : MonoBehaviour {
	private List<Item> database = new List<Item> ();
	private JsonData itemData;
	void Start(){

		itemData = JsonMapper.ToObject (File.ReadAllText (Application.dataPath + "/StreamingAssets/Items.json"));
		ConstructItemDatabase ();
	}
	public Item FetchItemByID(int id){
		for (int i=0; i<database.Count; i++) { 
			if (database [i].ID == id){
				return database [i];
				}
			}
		return null;
	}
	

	void ConstructItemDatabase(){
		for(int i=0;i<itemData.Count; i++){
			database.Add(new Item((int)itemData[i]["id"],itemData[i]["title"].ToString(),itemData[i]["slug"].ToString(),(bool)itemData[i]["stackable"],(bool)itemData[i]["dragable"],itemData[i]["description"].ToString()));

		}

	}

}
public class Item{

	public int ID{ get; set;}
	public string Title{ get; set;}
	public Sprite Sprite{ get; set;}
	public string Slug{ get; set;}
	public bool Stackable{ get; set;}
	public bool Dragable{ get; set;}
	public string Description{ get; set;}
	public Item(int id,string title,string slug,bool stackable,bool dragable,string description){
		this.ID = id;
		this.Title = title;
		this.Slug = slug;
		this.Stackable = stackable;
		this.Sprite = Resources.Load<Sprite> ("Sprites/Items/" + slug);
		this.Dragable = dragable;
		this.Description = description;

	
	}
	public Item(){
		this.ID = -1;
	}
}
