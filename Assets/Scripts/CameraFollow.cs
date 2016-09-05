using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	private Transform player;
	private GameObject cube;

	// Use this for initialization
	void Start () {
		player=GameObject.Find("Player").transform;
		cube=GameObject.Find("Cube");
	}

	// Update is called once per frame
	void Update () {

		if(!(cube.GetComponent<BlendIn>().playable)){
			this.transform.position =new Vector3(player.position.x,this.transform.position.y, this.transform.position.z);}
		else{
			this.transform.position =new Vector3(cube.transform.position.x,this.transform.position.y, this.transform.position.z);}

	}
}
