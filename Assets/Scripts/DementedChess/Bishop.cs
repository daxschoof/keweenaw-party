using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece {
	public override bool canMove(Vector2 pos) {
		return Mathf.Abs(pos.x-boardPos.x) == Mathf.Abs(pos.y-boardPos.y);
	}
}
