using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BlendIn : MonoBehaviour {
	public bool playable;
	private GameObject player;
	public Text myGUItext;
	
	public int guiTime = 2;
	// Use this for initialization
	void Start () {
		player=GameObject.Find("Player");
		//myGUItext.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if(Helpers.Contains(player.transform.position,this.transform,30)){


			if(!playable){
			Helpers.ActivateText(myGUItext);
				StartCoroutine(GuiDisplayTimer());}
			// Start coroutine for deactivating gui elements

			
			if(Input.GetKeyDown(KeyCode.E)&&!playable){
				Input.ResetInputAxes();
				Helpers.DeactivateText(myGUItext);
				playable=true;
				player.transform.position=new Vector3(0,player.transform.position.y,player.transform.position.z);
				player.gameObject.SetActive(false);
			}
			
			
		}else{
			Helpers.DeactivateText(myGUItext);		}
		
	}
	// Use this for initialization
	private bool Contains(Vector3 pos,Transform terminal,float epsilon){
		
		if(pos.x<=terminal.position.x+terminal.localScale.x&&pos.x>terminal.position.x-epsilon){
			return true;
		}
		
		return false;
	}
	IEnumerator GuiDisplayTimer()
	{
		// Waits an amount of time
		yield return new WaitForSeconds(guiTime);
		// Deactivate GUI objects;
		
		
	}

}
