using UnityEngine;
using System.Collections;

public class Jump : AbstractBehavior {
	public float jumpSpeed=200f;
	public float jumpDelay=.1f;
	public int jumpCount=2;

	protected float lastJumpTime=0;
	protected int jumpRemaining=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var canJump=inputstate.getButtonValue(inputButtons[0]);
		var holdTime=inputstate.getButtonHoldTime(inputButtons[0]);
		if(collisionState.standing){
			if(canJump && holdTime<.1f){
				jumpRemaining=jumpCount-1;
				onJump();
			}
		}else{
			if(canJump && holdTime<.1f&&(Time.time-lastJumpTime)>jumpDelay){
				if(jumpRemaining>0){
					jumpRemaining=jumpCount-1;
					onJump();
					jumpRemaining--;
				}
				
			}
		}
	}
	protected virtual void onJump(){
		var vel=rigidbody2d.velocity;
		lastJumpTime=Time.time;
		rigidbody2d.velocity=new Vector2(vel.x,jumpSpeed);
	}
}
