using UnityEngine;
using System.Collections;

public class LightBug : MonoBehaviour {
	private GameObject spotlight;
	private Light myspotlight;
	// Use this for initialization
	void Start () {
		spotlight=GameObject.FindWithTag("Broken");
		//myspotlight=spotlight.GetComponent<Light>();
		StartCoroutine(Toggle());
	}

	
	
	void Update()
	{



	}
	
	

	IEnumerator Toggle()
	{

		while(true){

			yield return new WaitForSeconds(2.0f);
			spotlight.SetActive(false);

			yield return new WaitForSeconds(2.0f);
			spotlight.SetActive(true);

		}
	}
}
