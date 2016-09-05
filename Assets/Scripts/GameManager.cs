using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public bool gameOver=false;
	private GameObject[] CheckpointList;
	public GameObject player;
	public GameObject[] LaserList;
	public GameObject missionFailed;
	private Vector3 pos=Vector3.zero;
	private bool cont=true;
	// Use this for initialization
	void Start () {
		CheckpointList=GameObject.FindGameObjectsWithTag("Checkpoint");
		LaserList=GameObject.FindGameObjectsWithTag("Laser");

	}
	
	// Update is called once per frame
	void Update () {

		if(LaserList.Length==0){
			LaserList=GameObject.FindGameObjectsWithTag("Laser");
		}
		if(player.transform.position.y<=-100){
			GameObject.Find("Platform").GetComponent<PlatformMove>().landed=false;
			GameObject.Find("Platform").transform.position=GameObject.Find("Platform").GetComponent<PlatformMove>().initialPosition;
			foreach(GameObject ls in LaserList){
				ls.transform.position=ls.GetComponent<LaserControl>().initialPosition;
				ls.SetActive(false);
			}

			gameOver=true;
		}
		if(gameOver){
			Time.timeScale=0;
			cont=false;
			missionFailed.SetActive(true);
			Debug.Log("gameover");
			foreach(GameObject cp in CheckpointList){
				if(cp.GetComponent<Checkpoint>().activated){
					//player.transform.position=cp.GetComponent<Checkpoint>().position;
					 pos=cp.GetComponent<Checkpoint>().position;
					gameOver=false;
				}

			}
		}
		if(Input.GetKeyDown(KeyCode.Tab)){
			if(!cont){
			cont=true;
			player.transform.position=pos;
			missionFailed.SetActive(false);
				Time.timeScale=1;}}
	}

}
