using UnityEngine;
using System.Collections;

public class RotateSpotlight : MonoBehaviour {
	private bool leftTurn=false;
	private int dir=1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Quaternion newRotation=new Quaternion(transform.rotation.x,transform.rotation.y,transform.rotation.z,transform.rotation.w);
		newRotation*=Quaternion.Euler(0,0,dir);
		if(RadToDeg(transform.rotation.z)>30&&!leftTurn){
			leftTurn=true;
			dir*=-1;
		}
		if(RadToDeg(transform.rotation.z)<-30&&leftTurn){
			leftTurn=false;
			dir*=-1;
		}
		transform.rotation=Quaternion.Slerp(transform.rotation,newRotation,20*Time.deltaTime);

	}
	float RadToDeg(float x ){

		return (x*180)/Mathf.PI;

	}
}
