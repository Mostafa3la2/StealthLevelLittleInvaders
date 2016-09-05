using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Terminal : MonoBehaviour {
	private GameObject player;
	public bool terminalUse=false;
	public Text myGUItext;

	public int guiTime = 2;
	// Use this for initialization
	void Start () {
		player=GameObject.Find("Player");
		myGUItext.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Helpers.Contains(player.transform.position,this.transform,20)){
			Helpers.ActivateText(myGUItext);
			// Start coroutine for deactivating gui elements
			StartCoroutine(GuiDisplayTimer(guiTime));


			if(Input.GetKeyDown(KeyCode.E)){
				Helpers.DeactivateText(myGUItext);
				terminalUse=true;			
			}


		}else{
			Helpers.DeactivateText(myGUItext);
		}


	
	}

	/*private bool Contains(Vector3 pos,Transform terminal,float epsilon){
	
		if(pos.x<=terminal.position.x+terminal.localScale.x&&pos.x>terminal.position.x-epsilon){
			return true;
		}

		return false;
	}*/
	IEnumerator GuiDisplayTimer(int time)
	{
		// Waits an amount of time
		yield return new WaitForSeconds(time);
		// Deactivate GUI objects;


	}


}
