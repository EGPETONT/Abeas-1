using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;

[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(CapsuleCollider))]
public class PlayerMovement : MonoBehaviour
{
	//public float speed = 10.0f;
	//public float gravity = 10.0f;
	//public float maxVelocityChange = 10.0f;
	//public bool canJump = true;
	//public float jumpHeight = 2.0f;
	//private bool grounded = false;

	//[SerializeField] private Rigidbody rigidbody;
	//[SerializeField] private LeanJoystick joystick;
	//[SerializeField] private Transform root;
	//void Awake()
	//{
	//	rigidbody.freezeRotation = true;
	//	rigidbody.useGravity = false;
	//}

	//void FixedUpdate()
	//{
	//	if (grounded)
	//	{
	//		// Calculate how fast we should be moving
	//		//Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	//		Vector3 targetVelocity = new Vector3(joystick.ScaledValue.x, 0, joystick.ScaledValue.y);
	//		targetVelocity = transform.TransformDirection(targetVelocity);
	//		targetVelocity *= speed;

	//		// Apply a force that attempts to reach our target velocity
	//		Vector3 velocity = rigidbody.velocity;
	//		Vector3 velocityChange = (targetVelocity - velocity);
	//		velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
	//		velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
	//		velocityChange.y = 0;
	//		rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

	//		// Jump
	//		if (canJump && Input.GetButton("Jump"))
	//		{
	//			rigidbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
	//		}

	//		//root.Rotate(0.0f, -joystick.ScaledValue.x, 0.0f);
	//		root.eulerAngles = new Vector3(0.0f, -joystick.ScaledValue.x * 90, 0.0f);
	//	}

	//	// We apply gravity manually for more tuning control
	//	rigidbody.AddForce(new Vector3(0, -gravity * rigidbody.mass, 0));

	//	grounded = false;
	//}

	//void OnCollisionStay()
	//{
	//	grounded = true;
	//}

	//float CalculateJumpVerticalSpeed()
	//{
	//	// From the jump height and gravity we deduce the upwards speed 
	//	// for the character to reach at the apex.
	//	return Mathf.Sqrt(2 * jumpHeight * gravity);
	//}


	public float walkSpeed = 6;

	Vector3 moveAmount;
	Vector3 smoothMoveVelocity;
	Rigidbody rb;

	[SerializeField] private LeanJoystick joystick;

	[SerializeField] private Transform root;
	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{

		float inputX = joystick.ScaledValue.x;//Input.GetAxisRaw("Horizontal");
		float inputY = joystick.ScaledValue.y; //Input.GetAxisRaw("Vertical");

		Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
		Vector3 targetMoveAmount = moveDir * walkSpeed;
		moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

		//root.transform.rotation = Quaternion.LookRotation(Vector3.zero);
		//root.transform.Rotate(-90, 0, 0);
	}

	void FixedUpdate()
	{

		Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
		rb.MovePosition(rb.position + localMove);
	}
}
