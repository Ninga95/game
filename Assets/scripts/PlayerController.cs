using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

	public float inputTurn;
	public float inputForward;
	public float inputSide;

	public float turnSpeed = 300;
	public float moveSpeed = 5;

	CharacterController characterController;

	void Awake() {
		characterController = GetComponent<CharacterController> ();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		inputTurn = Input.GetAxis ("Mouse X");

		inputForward = Input.GetAxis ("Vertical");
		inputSide = Input.GetAxis ("Horizontal");
	}

	void FixedUpdate ()
	{
		transform.Rotate (Vector3.up, inputTurn * turnSpeed * Time.fixedDeltaTime);

		Vector3 delta = Vector3.zero;

		delta += transform.forward * -inputForward * moveSpeed * Time.fixedDeltaTime;
		delta += transform.right * -inputSide * moveSpeed * Time.fixedDeltaTime;

		characterController.Move (delta); 
	}

}
