using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : MonoBehaviour {
	// 0 is no friction, 1 is stopping immediately
	public float drag;
	public float slippyness;
	public float maxSpeed;
	public float maxSpeedSnowy;
	public float maxAcceleration;
	public float maxAccelerationSnowy;
	// 0 is not able to rotate at all, 1 is facing target direction immediately (linear)
	public float rotateSpeed;
	// How much keyLeft/keyRight should try to turn (degrees per frame)
	public float keyTurnSpeed;
	public string keyLeft;
	public string keyBackward;
	public string keyForward;
	public string keyRight;
	// Public to be able to check that player comes (mostly) to a stop in the space
	public Vector3 velocity;
	private RaceToParkMain main;

	// Start is called before the first frame update
	void Start() {
		main = GameObject.Find("Main Camera").GetComponent<RaceToParkMain>();
		if(main.snowy) maxAcceleration = maxAccelerationSnowy;
	}

	void Update() {
		if(!main.gamePlaying) return;
		Vector3 aim = transform.eulerAngles;
		if(main.joystick) {
			// TODO
		}
		else {
			aim.z += keyTurnSpeed*(((Input.GetKey(keyLeft)) ? 1 : 0)-((Input.GetKey(keyRight) ? 1 : 0)));
		}
		// Unity docs say not to set one component
		transform.eulerAngles = new Vector3(
			aim.x,
			aim.y,
			rotateSpeed*(aim.z-transform.eulerAngles.z)+transform.eulerAngles.z
		);
		Vector3 direction = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z+90)*(new Vector3(1, 0, 0));
		if(!main.snowy) {
			velocity = Mathf.Min(maxSpeed, Mathf.Max(-maxSpeed,
				Vector3.Dot(velocity, direction)*(1-drag)+(
					(main.joystick)
						? 0 // TODO
						: ((Input.GetKey(keyForward)) ? 1 : 0)-((Input.GetKey(keyBackward) ? 1 : 0))
				)*(Time.deltaTime*maxAcceleration)
			))*direction;
		}
		else {
			velocity = velocity.magnitude*(1-drag)*(slippyness*velocity.normalized*Mathf.Sign(Vector3.Dot(velocity, direction))+direction).normalized+(
				(main.joystick)
					? 0 // TODO
					: ((Input.GetKey(keyForward)) ? 1 : 0)-((Input.GetKey(keyBackward) ? 1 : 0))
			)*(Time.deltaTime*maxAcceleration)*direction;
			if(Mathf.Abs(velocity.magnitude) > maxSpeed) velocity = maxSpeed*velocity.normalized;
		}
		transform.position += Time.deltaTime*velocity;
	}
}
