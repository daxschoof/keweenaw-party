using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece {
	public override bool canMove(Vector2 pos) {
		return true;
	}
}
