using UnityEngine;
using System.Collections;

public class BoxDirection : AbstractBehavior {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<BlendIn>().playable){
		var right = inputstate.getButtonValue (inputButtons [0]);
		var left = inputstate.getButtonValue (inputButtons [1]);
		if (right) {
			inputstate.Direction = Direction.right;
		} else if (left) {
			inputstate.Direction=Direction.left;
		}

	}
	}
}
