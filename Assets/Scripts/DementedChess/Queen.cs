using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece {
	public override bool canMove(Vector2 pos) {
		return
			Mathf.Abs(pos.x-boardPos.x) == Mathf.Abs(pos.y-boardPos.y) ||
			pos.x-boardPos.x == 0 || pos.y-boardPos.y == 0
		;
	}
}
