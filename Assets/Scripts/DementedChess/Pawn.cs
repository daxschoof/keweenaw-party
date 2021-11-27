using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece {
	public override bool canMove(Vector2 pos) {
		return Mathf.Abs(pos.y-boardPos.y) == 1 && pos.x-boardPos.x == 0;
	}
}
