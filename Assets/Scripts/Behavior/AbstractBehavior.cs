using UnityEngine;
using System.Collections;

public abstract class AbstractBehavior : MonoBehaviour {
	public Buttons[] inputButtons;
	protected InputState inputstate;
	protected Rigidbody2D rigidbody2d;
	protected CollisionState collisionState;
	public MonoBehaviour[] dissableScripts;

	protected virtual void Awake(){
		inputstate = GetComponent<InputState> ();
		rigidbody2d = GetComponent<Rigidbody2D> ();
		collisionState=GetComponent<CollisionState>();

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	protected virtual void ToggleScripts(bool value){
		foreach (var script in dissableScripts) {
			script.enabled = value;
		}
	}

}
