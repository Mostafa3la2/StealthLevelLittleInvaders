using UnityEngine;
using System.Collections;

public class EndPoint : MonoBehaviour {
	public GameObject Platform;
	public GameObject laser1;
	public GameObject laser2;
	// Use this for initialization
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name=="Player"){
			Platform.GetComponent<PlatformMove>().landed=false;
			laser1.SetActive(false);
			laser2.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
