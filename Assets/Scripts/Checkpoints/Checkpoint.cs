using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	public Vector3 position;
	public bool activated;
	public static GameObject[] CheckpointList;
	void Start(){
		CheckpointList=GameObject.FindGameObjectsWithTag("Checkpoint");

	}
	void OnTriggerEnter2D(Collider2D player){
		if(player.gameObject.name=="Player"){
			position=player.transform.position;
			ActivateCheckpoint();
			activated=true;
		}}
	void ActivateCheckpoint(){
		foreach(GameObject cp in CheckpointList){
			cp.GetComponent<Checkpoint>().activated=false;
		}

	}
}
