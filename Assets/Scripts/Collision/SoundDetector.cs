using UnityEngine;
using System.Collections;

public class SoundDetector : MonoBehaviour {
	//this script behaves similarly to the SoundDetector, should be abstracted

	public bool entered;
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name=="Player"){
			
			entered=true;
		} 
	}
	void OnTriggerExit2D(Collider2D col){
		
		if(col.gameObject.name=="Player"){
			
			entered=false;
		} 
	}
	void Update(){
		if(entered&&GameObject.Find("Player").GetComponent<Walk>().sound>=5){
			GameObject.Find("GameManager").GetComponent<GameManager>().gameOver=true; //will be replaced with global detection flag
			
		}
	
}
}
