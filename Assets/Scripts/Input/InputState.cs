using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ButtonState{
	public bool value;
	public float holdTime = 0f;


}
public enum Direction{
	right=1,left=-1

}
public class InputState : MonoBehaviour {
	private Dictionary<Buttons,ButtonState> ButtonStates=new Dictionary<Buttons ,ButtonState >();
	public Direction Direction=Direction.right;
	public float absVelX = 0f;
	public float absVelY = 0f;
	
	private Rigidbody2D body2d;
	void Awake(){
		body2d = GetComponent<Rigidbody2D> ();
	}
	void FixedUpdate(){
		absVelX = Mathf.Abs (body2d.velocity.x);
		absVelY = Mathf.Abs (body2d.velocity.y);
	}
	public void SetButtonValue(Buttons key,bool value){
		if (!ButtonStates.ContainsKey (key)) {
			ButtonStates.Add(key,new ButtonState());
		
		}

		var state = ButtonStates [key];
		if (state.value && !value) {

			state.holdTime=0;
		}
		else if(state.value && value){
			state.holdTime+=Time.deltaTime;


		}

		state.value = value;

	}
	public bool getButtonValue(Buttons key){
		if (ButtonStates.ContainsKey (key))
			return ButtonStates [key].value;
		else
			return false;

	}
	public float getButtonHoldTime(Buttons key){
		if (ButtonStates.ContainsKey (key))
			return ButtonStates [key].holdTime;
		else
			return 0;
		
	}
}
