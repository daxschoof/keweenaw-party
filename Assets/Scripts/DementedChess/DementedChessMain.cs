using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DementedChessMain : MonoBehaviour {
	public GameObject blackSquare;
	public GameObject whiteSquare;
	public GameObject pawn;
	public GameObject bishop;
	public GameObject knight;
	public GameObject rook;
	public GameObject queen;
	public GameObject king;
	public int boardSize;
	public int[][] occupied; // 0 not occupied, 1 by white, 2 by black

	// Start is called before the first frame update
	void Start() {
		occupied = new int[boardSize][];
		GetComponent<Camera>().orthographicSize = Mathf.Max(1, ((float)Screen.height/Screen.width))*boardSize/2f;
		for(int i = 0; i < boardSize; i++) { occupied[i] = new int[boardSize]; }
		for(int i = 0; i < boardSize; i++) {
			for(int j = 0; j < boardSize; j++) {
				Instantiate((((((i+1)%4 < 2) ? 2 : 0)+j+1)%4 < 2) ? blackSquare : whiteSquare, new Vector3(
					((j%2 == 0) ? 1 : -1)*(((boardSize%2 == 0) ? 0.5f : 0)+(((boardSize%2 == 0) ? 0 : 1)+j)/2),
					((i%2 == 0) ? 1 : -1)*(((boardSize%2 == 0) ? 0.5f : 0)+(((boardSize%2 == 0) ? 0 : 1)+i)/2),
					0
				), Quaternion.identity);
				occupied[j][i] = 0;
			}
		}
	}

	// Update is called once per frame
	void Update() {
		
	}
}
