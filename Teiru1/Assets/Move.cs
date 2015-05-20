using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	float speed = 450.0f;
	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector2.zero;
	private Vector3 syncEndPosition = Vector2.zero;
	
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
	}

	void InputMovement()
	{
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.A) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
		{
			//print ("s");
			var move = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
			//transform.position += move * speed * Time.deltaTime;
			//rigidbody.MovePosition (rigidbody.position + move * speed * Time.deltaTime);
			rigidbody2D.MovePosition (rigidbody2D.position + move * speed * Time.deltaTime);
			int DistanceAway = 600;
			Vector2 PlayerPOS = NetworkManager.p.transform.transform.position;
			GameObject.Find ("Main Camera").transform.position = new Vector3 (PlayerPOS.x, PlayerPOS.y,-600);
		}
	}


	void OnCollisionEnter2D(Collision2D coll)
	{
		string pe = coll.gameObject.name;
		if (coll.gameObject.name.Contains("(Clone)"))
		{
			Debug.Log("fff");
			Physics2D.IgnoreCollision(coll.collider, NetworkManager.p.collider2D);
		}
	}


	private void SyncedMovement()
	{
		syncTime += Time.deltaTime;
		rigidbody2D.position = Vector2.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		Vector3 syncPosition = Vector2.zero;
		if (stream.isWriting)
		{
			syncPosition = rigidbody2D.position;
			stream.Serialize(ref syncPosition);

		}
		else
		{
			stream.Serialize(ref syncPosition);
			
			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;
			
			syncStartPosition = rigidbody2D.position;
			syncEndPosition = syncPosition;
		}
	}
}