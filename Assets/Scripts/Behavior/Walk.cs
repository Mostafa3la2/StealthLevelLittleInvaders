using UnityEngine;
using System.Collections;

public class Walk : AbstractBehavior {
	public float speed=50f;
	public float runMultiplier=2f;
	public float stealthMultiplier=.5f;
	public bool running;
	public bool stealMode;
	public int sound;
	public GameObject board;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		sound=5;
		running = false;
		var right = inputstate.getButtonValue (inputButtons [0]);
		var left = inputstate.getButtonValue (inputButtons [1]);
		var run = inputstate.getButtonValue (inputButtons [2]);
		stealMode = inputstate.getButtonValue (inputButtons [3]);
		if(!board.GetComponent<CamManager>().stopPlayer){
		if (right || left) {
			var tmpspeed=speed;
			if(run && runMultiplier>0){
				running = true;
				tmpspeed*=runMultiplier;
				sound=10;

			}
			if(stealMode ){
				stealMode=true;
				tmpspeed*=stealthMultiplier;
				sound=2;
			}

			var velx=tmpspeed*(float)inputstate.Direction;
			rigidbody2d.velocity=new Vector2(velx,rigidbody2d.velocity.y);
			}}
	}
}
