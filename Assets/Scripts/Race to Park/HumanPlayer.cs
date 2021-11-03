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
	public float joystickOverlap;
	// Public to be able to check that player comes (mostly) to a stop in the space
	public Vector3 velocity;
	private RaceToParkMain main;
	private Camera mainCamera;
	private GameObject joystick, joystickHandle;

	// Start is called before the first frame update
	void Start() {
		main = GameObject.Find("Main Camera").GetComponent<RaceToParkMain>();
		mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
		joystick = GameObject.Find("Joystick");
		joystickHandle = GameObject.Find("Joystick Handle");
		if(main.snowy) maxAcceleration = maxAccelerationSnowy;
		joystickOverlap = (joystick.GetComponent<Renderer>().bounds.size.x-joystickHandle.GetComponent<Renderer>().bounds.size.x)/2+joystickOverlap*joystickHandle.GetComponent<Renderer>().bounds.size.x;
	}

	void Update() {
		if(!main.gamePlaying) return;
		Vector3 aim = transform.eulerAngles;
		if(main.joystick) {
			Vector2 pos = new Vector2(0, 0); // to be able to compile
			if(Input.GetMouseButton(0))    pos = Input.mousePosition;
			else if(Input.touchCount != 0) pos = Input.GetTouch(0).position;
			if(Input.GetMouseButton(0) || Input.touchCount != 0) {
				pos = mainCamera.ScreenToWorldPoint(pos);
				// Show joystick for the first time
				if(!joystick.GetComponent<SpriteRenderer>().enabled) {
					joystick.GetComponent<SpriteRenderer>().enabled = true;
					joystickHandle.GetComponent<SpriteRenderer>().enabled = true;
					joystick.transform.position = new Vector3(
						pos.x,
						pos.y,
						joystick.transform.position.z
					);
				}
				// Update joystick and aim each frame
				else {
					joystickHandle.transform.position =
						new Vector3(0, 0, joystickHandle.transform.position.z)+(Vector3)(
							(Vector2)joystick.transform.position +
							(pos-(Vector2)joystick.transform.position).normalized*Mathf.Min((pos-(Vector2)joystick.transform.position).magnitude, joystickOverlap)
						)
					;
					aim.z += rotateSpeed*Mathf.DeltaAngle(
						aim.z,
						-Mathf.Atan2(
							joystickHandle.transform.position.x-joystick.transform.position.x,
							joystickHandle.transform.position.y-joystick.transform.position.y
						)*Mathf.Rad2Deg
					);
				}
			}
			// Hide joystick
			else {
				joystick.GetComponent<SpriteRenderer>().enabled = false;
				joystickHandle.GetComponent<SpriteRenderer>().enabled = false;
				joystickHandle.transform.position = new Vector3(
					joystick.transform.position.x,
					joystick.transform.position.y,
					joystickHandle.transform.position.z
				);
			}
		}
		else {
			aim.z += Time.deltaTime*keyTurnSpeed*(((Input.GetKey(keyLeft)) ? 1 : 0)-((Input.GetKey(keyRight) ? 1 : 0)));
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
						? Vector3.Dot(joystickHandle.transform.position-joystick.transform.position, direction)
						: ((Input.GetKey(keyForward)) ? 1 : 0)-((Input.GetKey(keyBackward) ? 1 : 0))
				)*(Time.deltaTime*maxAcceleration)
			))*direction;
		}
		else {
			velocity = velocity.magnitude*(1-drag)*(slippyness*velocity.normalized+direction).normalized+(
				(main.joystick)
					? Vector3.Dot(joystickHandle.transform.position-joystick.transform.position, direction)
					: ((Input.GetKey(keyForward)) ? 1 : 0)-((Input.GetKey(keyBackward) ? 1 : 0))
			)*(Time.deltaTime*maxAcceleration)*direction;
			if(Mathf.Abs(velocity.magnitude) > maxSpeed) velocity = maxSpeed*velocity.normalized;
		}
		transform.position += Time.deltaTime*velocity;
	}
}
