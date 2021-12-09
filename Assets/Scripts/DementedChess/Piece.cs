using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour {
	public Vector2 boardPos;
	public bool white;
	//public bool whiteSprite;
	//public bool blackSprite;
	private bool dragging;
	private bool wasDragging = false;
	protected static DementedChessMain main;
	private static Camera mainCamera;

	// Start is called before the first frame update
	void Start() {
		main = GameObject.Find("Main Camera").GetComponent<DementedChessMain>();
		mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update() {
		if(main.paused) return;
		if(main.occupied[(int)boardPos.x][(int)boardPos.y] != ((white) ? 1 : 2)) {
			// TODO: add points
			Destroy(gameObject);
			Destroy(this);
		}
		Vector2 pos = new Vector2(0, 0); // to be able to compile
		if(Input.GetMouseButton(0))    pos = Input.mousePosition;
		else if(Input.touchCount != 0) pos = Input.GetTouch(0).position;
		if(Input.GetMouseButton(0) || Input.touchCount != 0) {
			pos = mainCamera.ScreenToWorldPoint(pos);
			if(dragging) {
				transform.position = new Vector3(pos.x, pos.y, transform.position.z);
			}
			else if(!wasDragging && (pos-(Vector2)transform.position).magnitude < 0.5) {
				dragging = true;
			}
			wasDragging = true;
		}
		else {
			if(dragging) {
				pos = (Vector2)transform.position;
				pos.x = Mathf.Round(pos.x+((main.boardSize%2 == 0) ? 0.5f : 0))-((main.boardSize%2 == 0) ? 0.5f : 0);
				pos.y = Mathf.Round(pos.y+((main.boardSize%2 == 0) ? 0.5f : 0))-((main.boardSize%2 == 0) ? 0.5f : 0);
				Vector2 newBoardPos = new Vector2(
					main.boardSize/2f-0.5f+pos.x,
					main.boardSize/2f-0.5f-pos.y
				);
				if(
					newBoardPos.x >= 0 && newBoardPos.x < main.boardSize &&
					newBoardPos.y >= 0 && newBoardPos.y < main.boardSize &&
					main.occupied[(int)newBoardPos.x][(int)newBoardPos.y] != ((white) ? 1 : 2) &&
					canMove(newBoardPos)
				) {
					main.occupied[(int)boardPos.x][(int)boardPos.y] = 0;
					boardPos = newBoardPos;
					main.occupied[(int)boardPos.x][(int)boardPos.y] = (white) ? 1 : 2;
					transform.position = new Vector3(pos.x, pos.y, transform.position.z);
				}
				else {
					transform.position = new Vector3(
						-main.boardSize/2f+0.5f+boardPos.x,
						 main.boardSize/2f-0.5f-boardPos.y,
						transform.position.z
					);
				}
				dragging = false;
			}
			wasDragging = false;
		}
	}

	public abstract bool canMove(Vector2 pos);
}
