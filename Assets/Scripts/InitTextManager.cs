using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InitTextManager : MonoBehaviour {
	private Text myText;
	public bool PuzzleText;
	public int x=5;


	// Use this for initialization
	void Start () {
		myText=GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(DisplayText());


	}
	IEnumerator DisplayText() {
		for(int i=1;i<=2;i++){
			if(!PuzzleText){
				yield return new WaitForSeconds(1f);
				myText.text="Initializing Terminal";
				yield return new WaitForSeconds(1f);
				myText.text="Initializing Terminal.";
				yield return new WaitForSeconds(1f);
				myText.text="Initializing Terminal..";
				yield return new WaitForSeconds(1f);
				myText.text="Initializing Terminal...";
				yield return new WaitForSeconds(1f);

			}


		}
		myText.text="Terminal has started";
		PuzzleText=true;

	}
}
