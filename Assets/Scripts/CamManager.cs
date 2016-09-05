using UnityEngine;
using System.Collections;

public class CamManager : MonoBehaviour {
	public Camera MainCamera;
	public Camera TerminalCamera;
	public GameObject[] terminal;
	public GameObject[] terminalScreen;
	public GameObject sequenceManager1;
	public GameObject servSys;
	public GameObject servSys2;
	public GameObject player;
	public GameObject board;
	public bool stopPlayer;
	public void ShowTerminal() {
		MainCamera.enabled = false;
		TerminalCamera.enabled = true;
	}
	
	public void ShowMain() {
		MainCamera.enabled = true;
		TerminalCamera.enabled = false;
	}
	void Start(){
		TerminalCamera.enabled=false;


	}
	void Update(){
		
		if(terminal[0].GetComponent<Terminal>().terminalUse ){

			terminalScreen[0].SetActive(true);
			ShowTerminal();
		}
		if(terminal[1].GetComponent<Terminal>().terminalUse){
			terminalScreen[1].SetActive(true);
			stopPlayer=true;
			ShowTerminal();
		}
			


		
		if(sequenceManager1.GetComponent<SequenceManager>().solved){
			servSys.SetActive(false);
			sequenceManager1.GetComponent<SequenceManager>().solved=false;
			ShowMain();
		}
		if(board.GetComponent<CreateBoard>().solved){
			board.SetActive(false);
			stopPlayer=false;
			servSys2.GetComponent<LightBug>().enabled=true;
			ShowMain();
		}

	}
}
