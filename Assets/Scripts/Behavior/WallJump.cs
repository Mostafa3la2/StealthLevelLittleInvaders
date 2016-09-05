using UnityEngine;
using System.Collections;

public class WallJump : AbstractBehavior {
	public Vector2 jumpVelocity= new Vector2(50,200);
	public bool jumpingOffWall;
	public float resetDelay=.2f;
	private float timeElapsed=0;
	
	// Update is called once per frame
	void Update () {
		if(collisionState.onWall&&!collisionState.standing){

			var canJump=inputstate.getButtonValue(inputButtons[0]);
			if(canJump&&!jumpingOffWall){
			inputstate.Direction=inputstate.Direction==Direction.right?Direction.left:Direction.right;
				rigidbody2d.velocity=new Vector2(jumpVelocity.x*(float)inputstate.Direction,jumpVelocity.y);
				ToggleScripts(false);
				jumpingOffWall=true;

			}

		}
		if(jumpingOffWall){
			timeElapsed+=Time.deltaTime;
			if(timeElapsed>resetDelay){
				ToggleScripts(true);
				jumpingOffWall=false;
				timeElapsed=0;

			}

		}
	
	}
}
