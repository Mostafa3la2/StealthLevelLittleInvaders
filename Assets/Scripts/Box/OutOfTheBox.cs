using UnityEngine;
using System.Collections;

public class OutOfTheBox : MonoBehaviour {
	public GameObject Player;


	
	// Update is called once per frame
	void Update () {
		if(GetComponent<BlendIn>().playable ){
			if(Input.GetKeyDown(KeyCode.E)){

			Player.transform.position=new Vector3(this.transform.position.x+30,this.transform.position.y,this.transform.position.z);
			Player.SetActive(true);
			GetComponent<BlendIn>().playable=false;
				}
		}
	}
}
