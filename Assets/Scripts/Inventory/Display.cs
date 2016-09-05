using UnityEngine;
using System.Collections;

public class Display : MonoBehaviour {

	public bool viewable;
	private GameObject inv;
	void Start(){
		inv = GameObject.Find ("Inventory Panel");
		viewable = false;
	}
	// Use this for initialization
	void Update(){
		var inventoryKey = Input.GetKeyDown (KeyCode.I);
			if ( viewable == false) {
				inv.SetActive(false);

			} 
		if(inventoryKey==true){
			if(viewable==true){
				viewable=false;
			}else{
				viewable = true;
				inv.SetActive (true);}
			}
		//Debug.Log ("Hello");

		}

}
