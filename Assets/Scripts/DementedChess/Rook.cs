using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece {
	public override bool canMove(Vector2 pos) {
		return pos.x-boardPos.x == 0 || pos.y-boardPos.y == 0;
	}
}
