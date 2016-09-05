using UnityEngine;
using System.Collections;

public class DroneMovement : MonoBehaviour {
	private Rigidbody2D myBody;
	public float x;
	public float xMinThreshold,xMaxThreshold;
	private bool right=true;
	private bool left;
	//private bool check=true;
	// Use this for initialization
	void Start () {
		myBody=GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		myBody.velocity=new Vector2(x,myBody.velocity.y);
		transform.localScale = new Vector3 (-Mathf.Sign(x), 1, 1);
		//Debug.Log(transform.position.x);
		if(right&&transform.position.x>xMaxThreshold){
			right=false;
			left=true;
			x=-x;

		}
		if(left&&transform.position.x<xMinThreshold){

			right=true;
			left=false;
			x=-x;
			
		}
	}

}
