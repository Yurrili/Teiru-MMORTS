using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	float speed = 10.0f;
	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;
	
	void Update() 
	{
		if (networkView.isMine)
		{
			InputMovement();
		}
		else
		{
			SyncedMovement();
		}
		Vector3 PlayerPOS = NetworkManager.p.transform.transform.position;
		GameObject.Find ("Main Camera").transform.position = new Vector3 (PlayerPOS.x, PlayerPOS.y, PlayerPOS.z - 310);
	}

	void InputMovement()
	{
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.A) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
		{
			var move = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
			transform.position += move * speed * Time.deltaTime;
			rigidbody.MovePosition (rigidbody.position + move * speed);
			int DistanceAway = 310;
			Vector3 PlayerPOS = NetworkManager.p.transform.transform.position;
			GameObject.Find ("Main Camera").transform.position = new Vector3 (PlayerPOS.x, PlayerPOS.y, PlayerPOS.z - DistanceAway);
		}
		else
		{
			rigidbody.velocity = new Vector3(0,0,0);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		this.rigidbody.velocity = Vector3.zero;
	}

	void OnCollisionEnter(Collision c)
	{
		this.rigidbody.velocity = Vector3.zero;
	}

	private void SyncedMovement()
	{
		syncTime += Time.deltaTime;
		rigidbody.position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		Vector3 syncPosition = Vector3.zero;
		if (stream.isWriting)
		{
			syncPosition = rigidbody.position;
			stream.Serialize(ref syncPosition);
		}
		else
		{
			stream.Serialize(ref syncPosition);
			
			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;
			
			syncStartPosition = rigidbody.position;
			syncEndPosition = syncPosition;
		}
	}
}