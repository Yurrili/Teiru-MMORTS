using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	float speed = 450.0f;
	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector2.zero;
	private Vector3 syncEndPosition = Vector2.zero;
	private Animator animator;
	public Texture2D buttonsA;
	public Texture2D buttonsB;
	public Texture panel;
	private bool fight = false;
	private bool might = false;
	private ArrayList l;


	void Start()
	{
		animator = this.GetComponent<Animator> ();
	}
	
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
			if(Input.GetKey (KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
				OnScreen.Rect_range_hight = OnScreen.Rect_range_hight - 0.069f;
			}

			if(Input.GetKey (KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
				OnScreen.Rect_range_hight = OnScreen.Rect_range_hight + 0.069f;
			}

			if(Input.GetKey (KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
				OnScreen.Rect_range_Width = OnScreen.Rect_range_Width + 0.069f;
			}

			if(Input.GetKey (KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
				OnScreen.Rect_range_Width = OnScreen.Rect_range_Width - 0.069f;
			}
			//print ("s");
			var move = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
			if (move.y > 0)
			{
				animator.SetInteger("Direction", 2);
			}
			else if (move.y < 0)
			{
				animator.SetInteger("Direction", 0);
			}
			else if (move.x > 0)
			{
				animator.SetInteger("Direction", 3);
			}
			else if (move.x < 0)
			{
				animator.SetInteger("Direction", 1);
			}
			else
			{
				switch(animator.GetInteger("Direction"))
				{
				case 0:
					animator.SetInteger("Direction", 4);
					break;
				case 1:
					animator.SetInteger("Direction", 5);
					break;
				case 2:
					animator.SetInteger("Direction", 6);
					break;
				case 3:
					animator.SetInteger("Direction", 7);
					break;
				default:
					animator.SetInteger("Direction", 4);
					break;
				}
			}
			//transform.position += move * speed * Time.deltaTime;
			//rigidbody.MovePosition (rigidbody.position + move * speed * Time.deltaTime);
			rigidbody2D.MovePosition (rigidbody2D.position + move * speed * Time.deltaTime);
			Vector2 PlayerPOS = NetworkManager.p.transform.transform.position;
			GameObject.Find ("Main Camera").transform.position = new Vector3 (PlayerPOS.x, PlayerPOS.y,-600);
		}
	}


	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.name.Contains ("(Clone)"))
		{
			Physics2D.IgnoreCollision (coll.collider, NetworkManager.p.collider2D);
		//		foreach (NetworkPlayer player in Network.connections) 
		//		{
		//			if (player.ipAddress == networkView.owner.ipAddress) 
		//			{
		//			networkView.RPC ("startBattle", player, NetworkManager.p.name);
		//			}
	//			} 
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


	[RPC]
	public void startBattle(string name)
	{
		fight = true;
	}

	[RPC]
	public void showList(string name, ArrayList list)
	{
		might = true;
		l = list;
	}

	[RPC]
	public void getList(string name)
	{
		networkView.RPC ("showList", RPCMode.Others, new object[] {name, NetworkManager.playerList});
	}

	void OnGUI()
	{

		GUIStyle a = new GUIStyle ();
		a.alignment = TextAnchor.MiddleCenter;
		a.normal.background = buttonsA;
		a.onNormal.background = buttonsA;
		a.onHover.background = buttonsB;
		a.hover.background = buttonsB;
		
		a.normal.textColor = Color.yellow;
		a.onNormal.textColor = Color.yellow;
		a.hover.textColor = Color.yellow;
		a.onHover.textColor = Color.yellow;

		if (GUI.Button (new Rect (Screen.width / 2 - 120, 210, 250, 50), "Wann` fight m8",a)) {
			networkView.RPC("getList", RPCMode.Server, NetworkManager.p.name);
		}
		if (fight) {
						GUI.DrawTexture(new Rect(Screen.width/2 - 168, 120, 340, 130), panel, ScaleMode.StretchToFill);
						if (GUI.Button (new Rect (Screen.width / 2 - 120, 210, 250, 50), "Start fight",a)) {
								print ("asdad");
						}
				}

		if (might) {
			GUI.DrawTexture(new Rect(Screen.width/2 - 197, 280, 400, 400), panel, ScaleMode.ScaleToFit);
			//ArrayList list = 
				//for (int i = 0; i < ; i++)
				{
					
					if (GUI.Button(new Rect(Screen.width/2 - 120, 390 + (60 ), 250, 50),"s", a))
					print ("df");
				}
		}
	}
}