using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CreateBoard : MonoBehaviour {

	// Use this for initialization
	public GameObject[] squarePrefab;
	public GameObject[] squares;
	const int N = 3;
	float [] xpos;
	float [] ypos;
	float[] newPos;
	const string STANDARD = "12345678."; // -1 represents empty square
	 string curArrangement;
	int movingSquarePos;
	bool slidingNow;
	public bool solved;
	private float multiplier=2;
	void Start () {

		float x = transform.position.x, y = transform.position.y;

		xpos = new float[] {x  , x + (multiplier*1.1f) , x + (multiplier*2.2f)};
		ypos = new float[] {y , y - (multiplier*1.1f) , y - (multiplier*2.2f)};
		squares = new GameObject[9];

		curArrangement = STANDARD; //initialize board
		generateRandomBoard (20); // generate random position
		drawThisArrangement (curArrangement);
		slidingNow = false;
	}

	int getEmptySquareIndex(string arrangement) {
		return arrangement.IndexOf (".");
	}

	void drawThisArrangement (string arrangement) {
		// only one time
		curArrangement = arrangement;
		int cnt = 0;
		for (int i=0; i<N; i++) {
			for (int j=0; j<N; j++) {
				if (arrangement[cnt] == '.') {
					// if it's empty  
					cnt++ ; 
					continue; 
				}
				squares[cnt] = Instantiate (squarePrefab[arrangement[cnt++] - '0' - 1],
				                            new Vector2(xpos[j] , ypos[i]) , 
				                            Quaternion.Euler(0 , 0 , 180)) as GameObject;
			}
		}
	}
	float[] moveSquare(int dir){
		// 0 for upper 1 for down 2 for right 3 for left

		int [] a = {-N , N , 1 , -1};
		int emptySqIndex = getEmptySquareIndex (curArrangement);

		int pos = emptySqIndex + a[dir];

		if (pos < 0 || pos >= N*N ) // no upper or lower square 
			return null;

		if (a [dir] == 1 && emptySqIndex % N == (N - 1)) // no right square
			return null;

		if (a [dir] == -1 && emptySqIndex % N == 0) // no left square
			return null;

		slidingNow = true; // set sliding flag
		//modify curArrangement

		curArrangement = swapStringChars (curArrangement, pos, emptySqIndex);

		GameObject upperSquare = squares [pos];

		// modify squares array to match new arrangment
		squares [emptySqIndex] = upperSquare;
		squares [pos] = null;
		
		// assign moving square 
		movingSquarePos = emptySqIndex;

		return new float[] {xpos[emptySqIndex % N] , ypos[emptySqIndex / N]};
		// return new positions
	}

	void generateRandomBoard( int maxDistance = 10) {
		int [] a = {0 , 1 , 2, 3};
		for (int i=0; i < maxDistance; i++) {
			moveSquare(a[Random.Range(0 , 4)]);
		}
	}
	// Update is called once per frame
	void Update () {

		if (curArrangement == STANDARD && !slidingNow) {// solved
			solved=true;
			//Debug.Log("BLABLABLABLA");
		}
		if (!slidingNow) {
			if (Input.GetKey ("down"))
				newPos = moveSquare (0);
			 else if (Input.GetKey ("up")) 
				newPos = moveSquare (1);
			else if (Input.GetKey ("left")) 
				newPos = moveSquare (2);
			 else if (Input.GetKey ("right")) 
				newPos = moveSquare (3);
		} else {

					float curX = squares [movingSquarePos].transform.position.x, curY = squares [movingSquarePos].transform.position.y;
					if (Mathf.Abs (newPos [0] - curX) > .04f) {

						float xDiff = Mathf.Sign (newPos [0] - curX) * 0.04f;
						squares [movingSquarePos].transform.position = new Vector2 (curX + xDiff, curY);
				
					} else if (Mathf.Abs (newPos [1] - curY) > .04f) {

						float yDiff = Mathf.Sign (newPos [1] - curY) * 0.04f;
						squares [movingSquarePos].transform.position = new Vector2 (curX, curY + yDiff);
				
					} else
						slidingNow = false;
		}
	}

	string swapStringChars(string value , int position1 , int position2) {
		char[] array = value.ToCharArray(); // Get characters
		char temp = array[position1]; // Get temporary copy of character
		array[position1] = array[position2]; // Assign element
		array[position2] = temp; // Assign element
		return new string(array); // Return string

	}
}



	