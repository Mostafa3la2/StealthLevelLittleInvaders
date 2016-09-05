using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PuzzleTextManager : MonoBehaviour ,IPointerDownHandler{
	private GameObject initText;

	public InitTextManager txtManager; 
	private Text myText;
	private bool flag;
	public bool clicked;
	// Use this for initialization
	public void OnPointerDown(PointerEventData eventData)
	{

		clicked=true;
			if(txtManager.PuzzleText&&clicked){

			myText.text="Password Sequence Initialized\nEnter missing values";


		}
	}
	void Start () {
		initText=GameObject.Find("InitText");
		myText=GetComponent<Text>();
		txtManager=initText.GetComponent<InitTextManager>();



	}
	
	// Update is called once per frame
	void Update () {

		if(txtManager.PuzzleText&&!clicked){
			myText.text="Override Security Protocol";
		}



	}
}
