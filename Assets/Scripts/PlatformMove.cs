using UnityEngine;
using System.Collections;

public class PlatformMove : MonoBehaviour {
	public GameObject player;
	public bool landed;
	public GameObject[] lasers;
	public Vector3 initialPosition;
	// Use this for initialization
	void Start () {
		initialPosition=transform.position;
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D col){
		landed=true;
		lasers[0].SetActive(true);
		lasers[1].SetActive(true);


	}
	void Update(){
		if(landed){
			this.GetComponent<Rigidbody2D>().velocity=new Vector2(20,this.GetComponent<Rigidbody2D>().velocity.y);}
		else{
			this.GetComponent<Rigidbody2D>().velocity=new Vector2(0,this.GetComponent<Rigidbody2D>().velocity.y);
		}
	}

}
