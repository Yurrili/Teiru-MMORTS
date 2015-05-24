using UnityEngine;
using System.Collections;
using System.Xml.Serialization; 
using System.Collections.Generic;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class Move : MonoBehaviour {
	
	float speed = 450.0f;
	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector2.zero;
	private Vector3 syncEndPosition = Vector2.zero;
	private Animator animator;
	private bool hide = true;
	private bool hide1 = true;

	public Texture2D HP ;
	public Texture2D buttonsA;
	public Texture2D buttonsB;
	public Texture2D inputField;
	public Texture2D atk;

	public Texture2D panel;
	private PlayersCharacter MyCharacter = ShowACharacter.a;
	private bool fight = false;
	public static bool might = false;
	public static List<NetworkViewID> l = new  List<NetworkViewID> ();
	bool got = false;
	public int counter = 0;
	private int theChoosenOne = 0;

	private bool TrueFight = false;
	private bool SendAccept = false;

	//Enemy HP_Bars
	private static int MAXHP_Enemy = 8;
	private static int CurrentHP_Enemy = 8;
	private float maxHealth_EN = (float)(MAXHP_Enemy*100);
	private float lenghtMaxHP_EN = (float)((MAXHP_Enemy/MAXHP_Enemy)*100);
	private float curHealth_EN = (float) ((CurrentHP_Enemy/MAXHP_Enemy)*100);

	private int av_EN = 0;

	void Start()
	{
		//NetworkManager.p.name = MenuManager._Character_.DName;
		NetworkView.Find(networkView.viewID).gameObject.name= NetworkManager.skak;
		if (NetworkView.Find(networkView.viewID).gameObject.name!="Main camera"  && got == false)
		{
			animator = this.GetComponent<Animator> ();			
			if (Network.isClient)
			{
				networkView.RPC("addPlayer",RPCMode.Server, networkView.viewID);
			}
			else
			{
				l.Add (networkView.viewID);
			}
		}
		else
		{
			got = false;
		}
	}

	[RPC]
	public void addPlayer(NetworkViewID p)
	{
		if (!l.Contains(p))
		{
			got = true;
			l.Add (p);
		}
	}

	[RPC]
	public void retList(int i)
	{
		networkView.RPC("getList", RPCMode.Others, l[i]);
	}
	
	[RPC]
	public void getList(NetworkViewID id)
	{
		l.Add (id);
	}
	
	[RPC]
	public void getCount()
	{
		networkView.RPC("setCount", RPCMode.Others, l.Count);
	}
	
	[RPC]
	public void setCount(int i)
	{
		counter = i;
	}


	//TUTAJ PROBOWALAM COS NAPISAC
	[RPC]
	public void getHP(NetworkPlayer play)
	{
		networkView.RPC ("setHP", play, ShowACharacter.a.Class_.getHPValue().getCurrentHP ());
		//wysyłamy "requesta" do innego kompa i on wywoluje funckję która zwróci nam hp
	}
	
	[RPC]
	public void setHP(int hp)
	{
		//CurrentHP_Enemy = hp;
	}
	
	[RPC]
	public void sendHP(int hp)
	{
		// wyslalismy Hp i mamy tą wartość na innym kompie w hp
		//CurrentHP_Enemy = hp;
		TrueFight = true;
		fight = false;
	}

	//AVATARS

	[RPC]
	public void getAV(NetworkPlayer play)
	{
		char d = ShowACharacter.a.Avatar.ToCharArray ()[2];
		
		int number = int.Parse(d+"");

		networkView.RPC ("setAv", play, number);
		//wysyłamy "requesta" do innego kompa i on wywoluje funckję która zwróci nam hp
	}


	[RPC]
	public void setAv(int av)
	{
		av_EN = av;
	}


	[RPC]
	public void sendAv(int av)
	{
		// wyslalismy Hp i mamy tą wartość na innym kompie w hp
		//CurrentHP_Enemy = hp;
		av_EN = av;
		hide1 = false;
		hide = false;
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
		//map_final
		if (coll.gameObject.name != "map_final")
		{
			string j = coll.gameObject.name;
			string h = NetworkManager.p.name;
			Physics2D.IgnoreCollision (coll.collider, NetworkManager.p.collider2D);
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
		for (int i = 0; i < l.Count ; i++)
		{
			if(NetworkManager.khg[i] == name){
				
				theChoosenOne = i;
				
			}
			
		}
		fight = true;
		might = false;

	}

	[RPC]
	public void sendAccept(string name)
	{
		for (int i = 0; i < l.Count ; i++)
		{
			if(NetworkManager.khg[i] == name){
				
				theChoosenOne = i;
				
			}
			
		}

		fight = false;
		TrueFight = true;
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

		GUIStyle hp = new GUIStyle ();
		hp.normal.background = HP;
		hp.normal.textColor = Color.yellow;

		GUIStyle attack = new GUIStyle ();
		attack.normal.background = HP;

	
		GUIStyle cStyl = new GUIStyle ();
		cStyl.normal.background = buttonsA;
		cStyl.alignment = TextAnchor.MiddleCenter;
		cStyl.normal.textColor = Color.yellow;

		GUIStyle c = new GUIStyle();
		c.normal.textColor = Color.yellow;

		if (fight) 
		{

				GUI.DrawTexture(new Rect(Screen.width/2 - 168, 100, 300, 200), panel, ScaleMode.StretchToFill);
				string quote = "Do you wanna fight with : " +  NetworkManager.khg[theChoosenOne];
				GUI.Label(new Rect (Screen.width/2 - 130, 150,180,50), quote ,c);
				
				if (GUI.Button (new Rect (Screen.width / 2 - 145, 200, 250, 50), "Start fight", a)) 
				{
					//FIGHT
					print ("Fight");
					TrueFight = true;
					fight = false;
					SendAccept = true;
					
				}

		}

		if (Network.isClient || Network.isServer) 
		{	
			if(TrueFight == false){
				if (GUI.Button (new Rect (228 , 5, 120, 40), "Fight",a)) 
				{
					if (Network.isClient)
					{
						l = new  List<NetworkViewID>();
					}

					networkView.RPC("getCount",RPCMode.Server);

					if (Network.isClient)
					{
						for (int i =0;i<counter;i++)
						{
							networkView.RPC ("retList", RPCMode.Server,i);
						}
						might = true;
					}
					else
					{
						might = true;
						hide1 = true;
						hide = true;
					}
				}
			}
		}

		if (might) 
		{		
				if(hide1 == true)
				{
					GUI.DrawTexture(new Rect(20, 120, 200, 300), panel, ScaleMode.StretchToFill);
					GUI.Label(new Rect(18, 120, 205, 20), "Available users : ", cStyl);
				}

		
				if( hide == true )
				{
					
					for (int i = 0; i < l.Count ; i++)
					{
						if(NetworkManager.khg[l.Count-i-1] != ShowACharacter.a.DName){

							if (GUI.Button(new Rect(30 , 140 + (50 * i), 180, 40), NetworkManager.khg[l.Count-i-1] , a))
							{

								networkView.RPC ("startBattle", NetworkView.Find(l[i]).owner, ShowACharacter.a.DName );
								theChoosenOne = i;
								
							}
						}

					}

					if (GUI.Button(new Rect(195, 120, 20, 20), "X" , a))
					{
						hide1 = false;
						hide = false;
					}

				}

		}

		if (TrueFight) {
			hide = false;
			hide1 = false;
			//networkView.RPC ("getHp", NetworkView.Find(l[theChoosenOne]).owner , Network.player);
			//networkView.RPC ("sendHp", NetworkView.Find(l[theChoosenOne]).owner , ShowACharacter.a.Class_.getHPValue().getCurrentHP ());
			
			//char d = ShowACharacter.a.Avatar.ToCharArray ()[2];
			//int number = int.Parse(d+"");
			GUI.Label (new Rect (Screen.width / 2 - 185, 5, 250, 50), "FIGHT", a);

			//TUTAJ TEGO MI TRZEBA
			GUI.Box(new Rect(Screen.width - 395, 35, 190, 90),"", cStyl);
			GUI.DrawTexture(new Rect( Screen.width - 380, 60, 40, 40), HP_Bar.sprites[av_EN], ScaleMode.ScaleToFit);
			string nameLabel = "Name : " + NetworkManager.khg[theChoosenOne];
			GUI.Label(new Rect(Screen.width - 325, 50, 80,  5), nameLabel, c);
			GUI.Box(new Rect(Screen.width - 327, 72, lenghtMaxHP_EN,  5), "HP");
			GUI.Box(new Rect(Screen.width - 327, 72, curHealth_EN,  5), "LVL 1", hp);
			
			string state = "State :" + ShowACharacter.a.Class_.getHPValue().getState();
			GUI.Label(new Rect(Screen.width - 327, 90,100,  5), state, c);

			//SKills
			GUI.DrawTexture(new Rect(10, Screen.height/4 , 60, 130), panel, ScaleMode.StretchToFill);
			GUI.Label(new Rect(10, Screen.height/4, 60, 20), "Skills : ", cStyl);

			Skill[] d = ShowACharacter.a.Class_.AvaibleSkills.ToArray ();

			if(GUI.Button( new Rect(15,Screen.height/4 + 20,50,50), "Auto", a)){

			}

			if(GUI.Button( new Rect(15,Screen.height/4 + 70,50,50), d[0].getSkillName(), a)) {

			}



		}

		GUI.DrawTexture(new Rect(400, 499 , 600, 400), panel, ScaleMode.StretchToFill);

		if (SendAccept) {
			char d = ShowACharacter.a.Avatar.ToCharArray ()[2];
			
			int number_ = int.Parse(d+"");

			networkView.RPC ("sendAccept", NetworkView.Find(l[theChoosenOne]).owner, ShowACharacter.a.DName );
			networkView.RPC ("getAv", NetworkView.Find(l[theChoosenOne]).owner , Network.player);
			networkView.RPC ("sendAv", NetworkView.Find(l[theChoosenOne]).owner , number_ );

			SendAccept = false;
			hide1 = false;
			hide = false;

		}
	}
}