using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece {
	public override bool canMove(Vector2 pos) {
		return pos.x-boardPos.x == 0 && (
			((white)
				? boardPos.y == (main.boardSize-1)-1 || boardPos.y == (main.boardSize-1)-3
				: boardPos.y == 1 || boardPos.y == 3
			)
				? (int)((Mathf.Abs(pos.y-boardPos.y)-1)/2) == 0
				: Mathf.Abs(pos.y-boardPos.y) == 1
		);
	}
}
