using UnityEngine;
using System.Collections;

public class SimpleMovement : MonoBehaviour {
	public float speed=5f;
	private Rigidbody2D body2d;
	public Buttons[] input;
	private InputState inputState;
	// Use this for initialization
	void Start () {
		body2d = GetComponent<Rigidbody2D> ();
		inputState = GetComponent<InputState> ();
	}
	
	// Update is called once per frame
	void Update () {
		var right = inputState.getButtonValue (input [0]);
		var left = inputState.getButtonValue (input [1]);
		var Velx = speed;
		if (right || left) {
		Velx*=left? -1 : 1;
		
		}else{
			Velx=0;
		}
		body2d.velocity=new Vector2(Velx,body2d.velocity.y);
	}
}
