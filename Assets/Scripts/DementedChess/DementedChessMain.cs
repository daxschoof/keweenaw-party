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

		for(int white = -1; white <= 1; white += 2) {
			if(boardSize >= 5) {
				for(int i = 0; i < boardSize; i++) {
					Pawn piece = Instantiate(pawn, new Vector3(-boardSize/2+((boardSize%2 == 0) ? 0.5f : 0)+i, white*(-boardSize/2+((boardSize%2 == 0) ? 0.5f : 0)+1), -1), Quaternion.identity).GetComponent<Pawn>();
					piece.white = (white == 1);
					piece.boardPos = new Vector2(i, (boardSize-1)/2f+white*((boardSize-1)/2f-1));
					if(white != 1) {
						piece.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
					}
					occupied[(int)piece.boardPos.x][(int)piece.boardPos.y] = (white == 1) ? 1 : 2;
				}
			}
		}
		for(int white = 1; white >= -1; white -= 2) {
			int i = (boardSize-1)/2; // rounding down here is intentional
			int next;
			for(int pieces = 0; pieces < boardSize; pieces++) {
				Piece piece;
				Vector3 pos = new Vector3(white*(-boardSize/2+((boardSize%2 == 0) ? 0.5f : 0)+i), white*(-boardSize/2+((boardSize%2 == 0) ? 0.5f : 0)), -1);
				if(i == (boardSize-1)/2) {
					piece = Instantiate(king, pos, Quaternion.identity).GetComponent<King>();
					next = i+1;
				}
				else if(i == (boardSize-1)/2+1 && boardSize%2 == 0) {
					piece = Instantiate(queen, pos, Quaternion.identity).GetComponent<Queen>();
					next = boardSize-1; // doing this (and all below) like this because if no queen then rook triggers on right first
				}
				else if(i == 0 || i == boardSize-1) {
					piece = Instantiate(rook, pos, Quaternion.identity).GetComponent<Rook>();
					next = (i == boardSize-1) ? 0 : (boardSize-1)/2+2;
				}
				else if(i <= (boardSize-1)/4f || i >= (boardSize-1)-(boardSize-1)/4f) {
					piece = Instantiate(knight, pos, Quaternion.identity).GetComponent<Knight>();
					next = (i > boardSize/2f) ? (boardSize-1)-i : (boardSize-1)-i+1;
				}
				else {
					piece = Instantiate(bishop, pos, Quaternion.identity).GetComponent<Bishop>();
					next = (i > boardSize/2f) ? (boardSize-1)-i : (boardSize-1)-i+1;
				}
				piece.white = (white == 1);
				piece.boardPos = new Vector2((white == 1) ? i : (boardSize-1)-i, (boardSize-1)/2f+white*((boardSize-1)/2f));
				if(white != 1) {
					piece.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
				}
				occupied[(int)piece.boardPos.x][(int)piece.boardPos.y] = (white == 1) ? 1 : 2;
				i = next;
			}
		}
	}

	// Update is called once per frame
	void Update() {
		
	}
}