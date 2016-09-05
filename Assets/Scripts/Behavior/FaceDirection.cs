using UnityEngine;
using System.Collections;

public class FaceDirection : AbstractBehavior {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var right = inputstate.getButtonValue (inputButtons [0]);
		var left = inputstate.getButtonValue (inputButtons [1]);
		if (right) {
			inputstate.Direction = Direction.right;
		} else if (left) {
			inputstate.Direction=Direction.left;
		}
		transform.localScale = new Vector3 ((float)inputstate.Direction, 1, 1);
	}
}
