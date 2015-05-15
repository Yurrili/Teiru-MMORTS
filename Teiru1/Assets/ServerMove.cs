using UnityEngine;
using System.Collections;

public class ServerMove : MonoBehaviour {

	public float speed = 2f;
	
	void Update()
	{
		if (networkView.isMine)
		{
		//	InputMovement();
		}
	}
	
	void InputMovement()
	{
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			rigidbody2D.MovePosition(rigidbody2D.position);
		
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			rigidbody2D.MovePosition(rigidbody2D.position );
		
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			rigidbody2D.MovePosition(rigidbody2D.position);
		
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			rigidbody2D.MovePosition(rigidbody2D.position );
	}
}
