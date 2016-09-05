using UnityEngine;
using System.Collections;

public class LaserCollision : MonoBehaviour {
	private GameObject[] LaserList;
	// Use this for initialization
	void Start(){
		LaserList=GameObject.FindGameObjectsWithTag("Laser");
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name=="Player"){


			GameObject.Find("Platform").GetComponent<PlatformMove>().landed=false;
			GameObject.Find("Platform").transform.position=GameObject.Find("Platform").GetComponent<PlatformMove>().initialPosition;
			GameObject.Find("GameManager").GetComponent<GameManager>().gameOver=true;
			foreach(GameObject ls in LaserList){
				ls.transform.position=ls.GetComponent<LaserControl>().initialPosition;
				ls.SetActive(false);
			}

		}
	}
}
