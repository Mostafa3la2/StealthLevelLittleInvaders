using UnityEngine;
using System.Collections;

public class BoxDetected : MonoBehaviour {
	//this script behaves similarly to the SoundDetector, should be abstracted 
	public bool entered;
	public GameObject Player;
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name=="Cube"){

			entered=true;
		} 
	}
		void OnTriggerExit2D(Collider2D col){

		if(col.gameObject.name=="Cube"){
			
			entered=false;
		} 
	}
	void Update(){
		if(entered&&GameObject.Find("Cube").GetComponent<Rigidbody2D>().velocity.x>10){
			Player.transform.position=new Vector3(this.transform.position.x+30,this.transform.position.y,this.transform.position.z);
			Player.SetActive(true);
			GameObject.Find("Cube").GetComponent<BlendIn>().playable=false;
			GameObject.Find("Cube").transform.position=GameObject.Find("Cube").GetComponent<ControlBox>().initialPosition;
			GameObject.Find("GameManager").GetComponent<GameManager>().gameOver=true; //will be replaced with global detection flag

		}

	}

}