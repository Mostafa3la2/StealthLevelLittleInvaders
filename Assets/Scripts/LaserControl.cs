using UnityEngine;
using System.Collections;

public class LaserControl : MonoBehaviour {
	public float velocity;
	private Rigidbody2D laserBody;
	public GameObject platform;
	public float minThreshold;
	public float maxThreshold ;
	public Vector3 initialPosition;
	private bool flip;
	// Use this for initialization
	void Start () {
		laserBody=GetComponent<Rigidbody2D>();
		initialPosition=transform.position;
		this.gameObject.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		if(platform.GetComponent<PlatformMove>().landed){

			flip=false;
				if(this.transform.position.y>minThreshold||this.transform.position.y<maxThreshold){
				if(!flip){
					velocity*=-1;
					flip=true;
				}
			}
			


			laserBody.velocity=new Vector2(platform.GetComponent<Rigidbody2D>().velocity.x,velocity);
		}
	}
}
