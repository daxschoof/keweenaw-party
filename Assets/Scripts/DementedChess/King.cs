using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece {
	public override bool canMove(Vector2 pos) {
		return Mathf.Abs(pos.x-boardPos.x) <= 1 && Mathf.Abs(pos.y-boardPos.y) <= 1;
	}
}
