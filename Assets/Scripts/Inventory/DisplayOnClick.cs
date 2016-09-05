using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class DisplayOnClick : MonoBehaviour {
	public GameObject inventoryPanel;
	private GameObject inventory;
	private Display disp;
	public bool clicked = false;
	private ItemData item;
	
	/*public string message = "Foo Bar";
	public float guiDelay = 0.1f;
	
	private float lastHoverTime = -99.0f;*/
	void OnMouseDown() {
		//lastHoverTime = Time.timeSinceLevelLoad;
		disp.viewable = true;
		inventoryPanel.SetActive (true);
		clicked = true;

	}
	
	/*void OnGUI(){
		if(lastHoverTime + guiDelay > Time.timeSinceLevelLoad){
			GUI.Box(new Rect(0,0,170,250),message);
		}
	}*/


	// Use this for initialization
	void Start () {
		inventory = GameObject.Find ("Inventory");
		disp = inventory.GetComponent<Display> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
