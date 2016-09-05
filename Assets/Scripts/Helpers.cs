using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Helpers :MonoBehaviour {
	public static bool Contains(Vector3 pos,Transform terminal,float epsilon){
		
		if(pos.x<=terminal.position.x+terminal.localScale.x&&pos.x>terminal.position.x-epsilon){
			return true;
		}
		
		return false;
	}

	public static void ActivateText(Text myGUIText ){
		myGUIText.text = "E";
		myGUIText.gameObject.SetActive(true);
	}

	public static void DeactivateText(Text myGUIText){
		myGUIText.gameObject.SetActive(false);


	}
}
