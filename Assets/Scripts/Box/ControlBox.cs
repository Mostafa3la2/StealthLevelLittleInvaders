using UnityEngine;
using System.Collections;

public class ControlBox : AbstractBehavior {
	public float speed=30f;
	public Vector3 initialPosition;
	// Use this for initialization
	void Start () {
		initialPosition=transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<BlendIn>().playable){
		var right = inputstate.getButtonValue (inputButtons [0]);
		var left = inputstate.getButtonValue (inputButtons [1]);
		if (right || left) {
			var tmpspeed=speed;

			var velx=tmpspeed*(float)inputstate.Direction;
				rigidbody2d.velocity=new Vector2(velx,rigidbody2d.velocity.y);}

		}

	}
}
