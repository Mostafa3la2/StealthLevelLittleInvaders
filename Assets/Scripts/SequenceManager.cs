using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SequenceManager : MonoBehaviour {
	private GameObject puzzleText;
	private Text gt;
	private string x="";
	public bool solved;
	public GameObject seq;
	public bool endType=false;
	public GameObject terminal;
	private string solution;
	public GameObject myTerminal;
	// Use this for initialization
	void Start () {
		puzzleText=GameObject.Find("PuzzleIntroText");
		seq.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		if(puzzleText.GetComponent<PuzzleTextManager>().clicked&&puzzleText.GetComponent<PuzzleTextManager>().txtManager.PuzzleText&&!endType){
			seq.SetActive(true);

			if(solution=="26,15"){

				terminal.GetComponent<Terminal>().terminalUse=false;
				myTerminal.SetActive(false);

				solved=true;

			}
		}
	}
	public void GetInput(string answer){

		solution=answer;
	}
}
