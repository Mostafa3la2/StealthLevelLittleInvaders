using UnityEngine;
using System.Collections;

public class PlayerDetected : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name=="Player"){
			//global detection flag set to true

			GameObject.Find("GameManager").GetComponent<GameManager>().gameOver=true;

		} 

	}
}
