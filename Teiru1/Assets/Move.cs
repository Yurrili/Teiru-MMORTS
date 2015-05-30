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

	public static bool fight = false;
	public static bool might = false;

	public static List<NetworkViewID> l = new  List<NetworkViewID> ();
<<<<<<< HEAD
	int counter =0;
	bool got = false;
	string hhhh= "";


	void Start()
	{
		NetworkManager.p.name = MenuManager._Character_.DName;
		string p = NetworkView.Find (networkView.viewID).gameObject.name;
		if (NetworkView.Find(networkView.viewID).gameObject.name!="Main camera"  && got == false)
		{
		animator = this.GetComponent<Animator> ();
		
		if (Network.isClient)
=======
	bool got = false;
	public int counter = 0;

	public static int theChoosenOne = 0;
	public static int theChoosenOneReversed = 0; 
	
	public static bool TrueFight = false;
	public static bool SendAccept = false;
	
	//Enemy HP_Bars
	public static int MAXHP_Enemy = 8;
	public static int CurrentHP_Enemy = 8;
	//private float maxHealth_EN = (float)(MAXHP_Enemy*100);
	public static float lenghtMaxHP_EN = (100);
	public static float curHealth_EN = (100);
	public static string[] Enemy_info;
	public static int av_EN = 0;
	public static string EN_Stats;
	public int myInitiativ;
	public int myEnemyInitiativ;
	
	public static bool myTurn = false;
	private NetworkPlayer ps;

	private GUIStyle a;
	private GUIStyle cStyl;
	private GUIStyle hp;
	private GUIStyle c;
	private GUIStyle attack;

	public int tempo = 0;

	public static bool GameOver = false;
	public static bool TrueGameOver = false;
	
	void Start()
	{
		//NetworkManager.p.name = MenuManager._Character_.DName;
		NetworkView.Find(networkView.viewID).gameObject.name= NetworkManager.skak;
		if (NetworkView.Find(networkView.viewID).gameObject.name!="Main camera"  && got == false)
>>>>>>> GodCalledTheLightDay
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
<<<<<<< HEAD
		}
		else
		{
			got = false;
		}
=======
		
		styles ();
>>>>>>> Boniedzialaloboktosmicommitowal
	}
	
	public void styles () {
		a = new GUIStyle ();
		a.alignment = TextAnchor.MiddleCenter;
		a.normal.background = buttonsA;
		a.onNormal.background = buttonsA;
		a.onHover.background = buttonsB;
		a.hover.background = buttonsB;
		
		a.normal.textColor = Color.yellow;
		a.onNormal.textColor = Color.yellow;
		a.hover.textColor = Color.yellow;
		a.onHover.textColor = Color.yellow;
		
		hp = new GUIStyle ();
		hp.normal.background = HP;
		hp.normal.textColor = Color.yellow;
		
		attack = new GUIStyle ();
		attack.normal.background = HP;
		
		
		cStyl = new GUIStyle ();
		cStyl.normal.background = buttonsA;
		cStyl.alignment = TextAnchor.MiddleCenter;
		cStyl.normal.textColor = Color.yellow;
		
		c = new GUIStyle();
		c.normal.textColor = Color.yellow;
	}
	
	//RPC
	
	[RPC]
	public void addPlayer(NetworkViewID p)
	{
		if (!l.Contains(p))
		{
<<<<<<< HEAD
		got = true;
		l.Add (p);
=======
			got = true;
			l.Add (p);
>>>>>>> GodCalledTheLightDay
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
<<<<<<< HEAD
	//	might = true;
	}

=======
	}
	
>>>>>>> GodCalledTheLightDay
	[RPC]
	public void getCount()
	{
<<<<<<< HEAD
		networkView.RPC("setCount", RPCMode.Others,l.Count);
<<<<<<< HEAD
=======
=======
		networkView.RPC("setCount", RPCMode.Others, l.Count);
>>>>>>> Boniedzialaloboktosmicommitowal
	}
	
	[RPC]
	public void setCount(int i)
	{
		counter = i;
>>>>>>> GodCalledTheLightDay
	}
	
	
	//TUTAJ PROBOWALAM COS NAPISAC
	[RPC]
	public void getCurHP(NetworkPlayer play)
	{
		networkView.RPC ("setCurHP", play, ShowACharacter.a.Class_.getHPValue().getCurrentHP ());
		//wysyłamy "requesta" do innego kompa i on wywoluje funckję która zwróci nam hp
	}
	
	[RPC]
	public void setCurHP(int hp)
	{
		CurrentHP_Enemy = hp;
	}
	
	[RPC]
	public void sendCurHP(int hp)
	{
		// wyslalismy Hp i mamy tą wartość na innym kompie w hp
		CurrentHP_Enemy = hp;
		TrueFight = true;
		fight = false;
	}

	//Statistics
	[RPC]
	public void getStats(NetworkPlayer play)
	{
		networkView.RPC ("setStats", play, ShowACharacter.a.Statistics.getDescription());
		//wysyłamy "requesta" do innego kompa i on wywoluje funckję która zwróci nam hp
	}
	
	[RPC]
	public void setStats(string stats)
	{
		EN_Stats = stats;
	}
	
	[RPC]
	public void sendStats(string stats)
	{
		// wyslalismy Hp i mamy tą wartość na innym kompie w hp
		EN_Stats = stats;
	}

	//Klasa
	//Enemy_info
	[RPC]
	public void getInfo(NetworkPlayer play)
	{
		string respond = ShowACharacter.a.Class_.getClass () + ";" + ShowACharacter.a.Class_.getBAB () + ";" + ShowACharacter.a.Class_.getFORT () + ";" + ShowACharacter.a.Class_.getREF () + ";" + ShowACharacter.a.Class_.getWILL();

		networkView.RPC ("setInfo", play, respond);
		//wysyłamy "requesta" do innego kompa i on wywoluje funckję która zwróci nam hp
	}
	
	[RPC]
	public void setInfo(string stats)
	{
		Enemy_info = stats.Split (';');
	}
	
	[RPC]
	public void sendInfo(string stats)
	{
		// wyslalismy Hp i mamy tą wartość na innym kompie w hp
		Enemy_info = stats.Split (';');
	}

	[RPC]
	public void send_getDamage(int dmg)
	{
		// wyslalismy Hp i mamy tą wartość na innym kompie w hp
		if( dmg < 0 ) {

			ShowACharacter.a.Class_.getHPValue().Hit(dmg*(-1));

			if(ShowACharacter.a.Class_.getHPValue().getCurrentHP() <= 0 ){
				//Game Over
				TrueFight = false;
				GameOver = true;
				TrueGameOver = true;
				gameOver();
			}
		} else {
			ShowACharacter.a.Class_.getHPValue().Heal(dmg);
		}
		TrueFight = true;
		fight = false;
	}

	[RPC]
	public void sendGameOver(bool game)
	{
		// wyslalismy Hp i mamy tą wartość na innym kompie w hp
		TrueFight = false;
		fight = false;
		GameOver = true;
		TrueGameOver = true;
	}

<<<<<<< HEAD
	[RPC]
	public void setCount(int i)
	{
		counter = i;
=======
	public void gameOver()
	{
		if (Network.isClient)
		{
			networkView.RPC ("sendGameOver", NetworkView.Find(l[theChoosenOneReversed]).owner , true );
			GameOver = false;
		}
		else
		{
			networkView.RPC ("sendGameOver", NetworkView.Find(l[theChoosenOne]).owner , true );
			GameOver = false;
		}
	}

	[RPC]
	public void getMaxHP(NetworkPlayer play)
	{
		networkView.RPC ("setMaxHP", play, ShowACharacter.a.Class_.getHPValue().getMAXHP ());
		//wysyłamy "requesta" do innego kompa i on wywoluje funckję która zwróci nam hp
	}
	
	[RPC]
	public void setMaxHP(int hp)
	{
		MAXHP_Enemy = hp;
	}
	
	[RPC]
	public void sendMaxHP(int hp)
	{
		// wyslalismy Hp i mamy tą wartość na innym kompie w hp
		MAXHP_Enemy = hp;
		TrueFight = true;
		fight = false;
	}
	//AVATARS
	
	[RPC]
	public void getAv(NetworkPlayer play)
	{
		char d = ShowACharacter.a.Avatar.ToCharArray ()[2];
		networkView.RPC ("setAv", play, int.Parse(d+""));
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
		calculateInit (ShowACharacter.a.Statistics.getDEX ());
		//InitiativeRoll(ShowACharacter.a.Statistics.getDEX());
	}
	
	//inicjatywa
	
	[RPC]
	public void getIniciative(NetworkPlayer play)
	{
		
		networkView.RPC ("setIniciative", play, myInitiativ);
		//wysyłamy "requesta" do innego kompa i on wywoluje funckję która zwróci nam hp
	}
	
	[RPC]
	public void setIniciative(int init)
	{
		//zwraca inicjatywe przeciwnika
		myEnemyInitiativ = init;
		AboutWiner (myEnemyInitiativ, myInitiativ);
	}
	
	[RPC]
	public void sendIniciative(int init)
	{
		//wyslalismy inicjatywe przeciwnikowi
		av_EN = init;
		hide1 = false;
		hide = false;
		calculateInit (ShowACharacter.a.Statistics.getDEX ());
		//InitiativeRoll(ShowACharacter.a.Statistics.getDEX());
	}
	
	public void AboutWiner(int a, int b) {
		if (a > b) {
			MChat.roll("Winer : " + NetworkManager.khg[theChoosenOne]);
			networkView.RPC ("aboutWiner", NetworkView.Find(l[theChoosenOneReversed]).owner ,true);
			myTurn = false;
		}else {
			MChat.roll("\nWiner : " + ShowACharacter.a.DName);
			networkView.RPC ("aboutWiner", NetworkView.Find(l[theChoosenOneReversed]).owner ,false);
			MChat.roll("\nYour turn : )\n");
			myTurn = true;
		}
	}
	
	[RPC]
	public void aboutWiner(bool av)
	{
		// wyslalismy Hp i mamy tą wartość na innym kompie w hp
		//CurrentHP_Enemy = hp;
		if (av == true) {
			MChat.roll("\nWiner : " + ShowACharacter.a.DName);
			MChat.roll("\nYour turn : )\n");
			myTurn = true;
		}else {
			MChat.roll("\nWiner : " + NetworkManager.khg[theChoosenOne]);
			MChat.roll("\nWait for your opponent\n");
			myTurn = false;
		}
	}
	
	[RPC]
	public void Turn(bool av)
	{
		myTurn = true;
		MChat.roll("\nYour turn : )\n");
	}
	
	public void ChangeTurn() {
		myTurn = false;
		
		if (Network.isClient)
		{
			networkView.RPC ("Turn", NetworkView.Find(l[theChoosenOneReversed]).owner ,true);
		}
		else
		{
			networkView.RPC ("Turn", NetworkView.Find(l[theChoosenOne]).owner ,true);
		}
		MChat.roll("\nWait for your opponent\n");
>>>>>>> Boniedzialaloboktosmicommitowal
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
<<<<<<< HEAD
		might = false;
=======
		for (int i = 0; i < NetworkManager.khg.Count ; i++)
		{
			if(NetworkManager.khg[i] == name){
				
				theChoosenOne = i;
				theChoosenOneReversed = NetworkManager.khg.Count - 1 - i;
				
			}
			
		}
>>>>>>> Boniedzialaloboktosmicommitowal
		fight = true;
		might = false;
		networkView.RPC("getCount",RPCMode.Server);
		
	}
	
	[RPC]
	public void sendAccept(string name)
	{
		networkView.RPC("getCount",RPCMode.Server);
		for (int i = 0; i < counter ; i++)
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
		
		if (Network.isClient || Network.isServer) 
		{	
			/*	if (Network.isClient && l.Count==0)
			{
				l = new  List<NetworkViewID> ();
				for (int i =0;i<counter;i++)
				{
					networkView.RPC ("retList", RPCMode.Server,i);
				}
			}*/
			
			if(TrueFight == false){
				// HELPPPPPPPP =P
				if (GUI.Button (new Rect (228 , 5, 120, 40), "Fight", a)) 
				{
					
					
					networkView.RPC("getCount",RPCMode.Server);
					
					if (Network.isClient)
					{
						l = new  List<NetworkViewID> ();
						for (int i =0;i<counter;i++)
						{
							networkView.RPC ("retList", RPCMode.Server,i);
						}
						might = true;
					} else {
						might = true;
						hide1 = true;
						hide = true;
					}
				}
			} else { // MOMENT WALKI

<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
				if( TrueGameOver != true){
				hide = false;
				hide1 = false;
>>>>>>> Boniedzialaloboktosmicommitowal

				NetworkPlayer f = NetworkView.Find(l[theChoosenOneReversed]).owner;

				networkView.RPC ("getCurHP", NetworkView.Find(l[theChoosenOne]).owner , Network.player);
				networkView.RPC ("sendCurHP",NetworkView.Find(l[theChoosenOne]).owner , ShowACharacter.a.Class_.getHPValue().getCurrentHP ());

>>>>>>> GodCalledTheLightDay

				
				networkView.RPC ("getMaxHP", NetworkView.Find(l[theChoosenOne]).owner , Network.player);
				networkView.RPC ("sendMaxHP",NetworkView.Find(l[theChoosenOne]).owner , ShowACharacter.a.Class_.getHPValue().getMAXHP());

				networkView.RPC ("getStats", NetworkView.Find(l[theChoosenOne]).owner , Network.player);
				networkView.RPC ("sendStats",NetworkView.Find(l[theChoosenOne]).owner , ShowACharacter.a.Statistics.getDescription());

				string respond = ShowACharacter.a.Class_.getClass () + ";" + ShowACharacter.a.Class_.getBAB () + ";" + ShowACharacter.a.Class_.getFORT () + ";" + ShowACharacter.a.Class_.getREF () + ";" + ShowACharacter.a.Class_.getWILL();

				networkView.RPC ("getInfo", NetworkView.Find(l[theChoosenOne]).owner , Network.player);
				networkView.RPC ("sendInfo",NetworkView.Find(l[theChoosenOne]).owner , respond);

<<<<<<< HEAD
		if (fight) 
		{
<<<<<<< HEAD
			GUI.DrawTexture(new Rect(Screen.width/2 - 168, 120, 340, 130), panel, ScaleMode.StretchToFill);
			if (GUI.Button (new Rect (Screen.width / 4 - 120, 210, 250, 50),hhhh + "wants to fight",a)) 
			{
				print ("asdad");
			}
		}

		if (Network.isClient || Network.isServer)
		{		
			if (GUI.Button (new Rect (Screen.width / 2 - 120, 210, 250, 50), "Wann` fight m8",a)) 
=======
=======
>>>>>>> Boniedzialaloboktosmicommitowal

				GUI.DrawTexture(new Rect(Screen.width/4, Screen.height/16 , 750, 600), panel, ScaleMode.StretchToFill);
				
				//char d = ShowACharacter.a.Avatar.ToCharArray ()[2];
				//int number = int.Parse(d+"");
				GUI.Label (new Rect (Screen.width / 2 - 195, 5, 250, 50), "FIGHT", a);

				GUIStyle norm = new GUIStyle ();
				norm.alignment = TextAnchor.MiddleCenter;

				//ENEMY HP BAR
				GUI.Box(new Rect(720, 85, 190, 90),"", cStyl);
				GUI.DrawTexture(new Rect( 735, 110, 40, 40), HP_Bar.sprites[av_EN], ScaleMode.ScaleToFit);
				string p =  NetworkManager.khg[theChoosenOneReversed];
				string h = NetworkManager.khg[theChoosenOne];
				string nameLabel = "Name : " + NetworkManager.khg[theChoosenOne];
				GUI.Label(new Rect(780, 100, 80,  5), nameLabel, c);
				GUI.Box(new Rect(790, 122, lenghtMaxHP_EN,  5), "HP");
				string hp_label  = CurrentHP_Enemy + "/" + MAXHP_Enemy;
				GUI.Box(new Rect(790, 122, curHealth_EN,  5), hp_label, hp);
				
				string state = "State :" + ShowACharacter.a.Class_.getHPValue().getState();
				GUI.Label(new Rect(790, 140,100,  5), state, c);

<<<<<<< HEAD
		if (Network.isClient || Network.isServer) 
		{		
			if (GUI.Button (new Rect (228 , 5, 120, 40), "Fight",a)) 
>>>>>>> GodCalledTheLightDay
			{
				networkView.RPC("getCount",RPCMode.Server);
				if (Network.isClient)
				{
<<<<<<< HEAD
=======
				l = new  List<NetworkViewID>();
				}
				networkView.RPC("getCount",RPCMode.Server);
				if (Network.isClient)
				{
>>>>>>> GodCalledTheLightDay
					for (int i =0;i<counter;i++)
					{
						networkView.RPC ("retList", RPCMode.Server,i);
=======
				GUI.Label(new Rect(330, 170, 750, 20), "About Character : ", cStyl);

				GUI.Box(new Rect(670 + 150,200,150,20), "Class : " + Enemy_info[0], norm);
				GUI.Box(new Rect(670 + 150,220,150,20), "Lvl : 1" , norm);
				GUI.Box(new Rect(670 + 150,260,150,20), "BAB : " + Enemy_info[1], norm);
				GUI.Box(new Rect(670 + 150,280,150,20), "FORT : " + Enemy_info[2], norm);
				GUI.Box(new Rect(670 + 150,300,150,20), "REF : " + Enemy_info[3], norm);
				GUI.Box(new Rect(670 + 150,320,150,20), "WILL : " + Enemy_info[4], norm);

				GUI.Label(new Rect(330, 370, 750, 20), "Statistics : ", cStyl);



				GUI.Box(new Rect(670 + 150,390,150,150), EN_Stats, norm);

				//SKills
				if(myTurn){
					GUI.DrawTexture(new Rect(320 , 550, 750, 100), panel, ScaleMode.StretchToFill);
					GUI.Label(new Rect(300, 550, 750, 20), "Skills : ", cStyl);
					
					Skill[] d = ShowACharacter.a.Class_.AvaibleSkills.ToArray ();
					
					if(GUI.Button( new Rect(320 + 60, 580, 90,50), "Auto", a)){
						TakeDamage(new Skill("Auto Attack", 0, "","",1,6,"" ));
						ChangeTurn();
>>>>>>> Boniedzialaloboktosmicommitowal
					}

					string [] brr = (d[0].getSkillName()).Split(' ');
					name = brr[0] + "\n" + brr[1];

					if(GUI.Button( new Rect(320 + 150, 580, 90, 50), name, a)) {

						TakeDamage(d[0]);
						ChangeTurn();
					}

					if(GUI.Button( new Rect(320 + 240, 580, 90, 50), "NaN", a)) {

					}

					if(GUI.Button( new Rect(320 + 330, 580, 90, 50), "NaN", a)) {
						
					}
					if(GUI.Button( new Rect(320 + 420, 580, 90, 50), "NaN", a)) {
						
					}
					if(GUI.Button( new Rect(320 + 510,580, 90, 50), "NaN", a)) {
						
					}
					if(GUI.Button( new Rect(320 +  600, 580, 90, 50), "NaN", a)) {
						
					}
					}

				}

<<<<<<< HEAD
		if (might) 
<<<<<<< HEAD
		{

			GUI.DrawTexture(new Rect(Screen.width/4 - 197, 280, 400, 400), panel, ScaleMode.ScaleToFit);
				for (int i = 0; i < l.Count ; i++)
=======
		{		
=======
				
			}
			
			if (might) 
			{		
>>>>>>> Boniedzialaloboktosmicommitowal
				if(hide1 == true)
>>>>>>> GodCalledTheLightDay
				{
					GUI.DrawTexture(new Rect(20, 120, 200, 300), panel, ScaleMode.StretchToFill);
					GUI.Label(new Rect(18, 120, 205, 20), "Available users : ", cStyl);
				}
				
				if( hide == true )
				{
					
					for (int i = 0; i < l.Count ; i++)
					{
<<<<<<< HEAD
<<<<<<< HEAD
					networkView.RPC ("startBattle", NetworkView.Find(l[i]).owner,NetworkView.Find(l[i]).gameObject.name );
=======
						if (GUI.Button(new Rect(30 , 140 + (60 * i), 180, 40), NetworkManager.khg[l.Count-i-1] , a))
						{
						networkView.RPC ("startBattle", NetworkView.Find(l[i]).owner,NetworkManager.khg[i] );
						}	
>>>>>>> GodCalledTheLightDay
=======
						if(NetworkManager.khg[l.Count-i-1] != ShowACharacter.a.DName){
							
							if (GUI.Button(new Rect(30 , 140 + (50 * i), 180, 40), NetworkManager.khg[l.Count-i-1] , a))
							{	
								//wyzwanie na pojedynek
								if (Network.isServer)
								{
									networkView.RPC ("startBattle", NetworkView.Find(l[l.Count-i-1]).owner, ShowACharacter.a.DName );
									theChoosenOne = l.Count-i-1;
									theChoosenOneReversed = i;
								}
								else
								{
									networkView.RPC ("startBattle", NetworkView.Find(l[i]).owner, ShowACharacter.a.DName );
									theChoosenOne = i;
									theChoosenOneReversed = l.Count-i-1;
								}
							}
						}
>>>>>>> Boniedzialaloboktosmicommitowal
					}
					
					if (GUI.Button(new Rect(195, 120, 20, 20), "X" , a))
					{
						hide1 = false;
						hide = false;
					}	
				}
			}
			
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
			
			if (SendAccept) {
				
				char d = ShowACharacter.a.Avatar.ToCharArray ()[2];
				NetworkPlayer f = NetworkView.Find(l[theChoosenOneReversed]).owner;
				networkView.RPC ("sendAccept", f, ShowACharacter.a.DName );
				networkView.RPC ("getAv", f , Network.player);
				networkView.RPC ("sendAv", f , int.Parse(d+""));

				//calculateInit (ShowACharacter.a.Statistics.getDEX ());
				InitiativeRoll(ShowACharacter.a.Statistics.getDEX());
				//InitiativeRoll(ShowACharacter.a.Statistics.getDEX());
				SendAccept = false;
				hide1 = false;
				hide = false;
				
			}

			if(GameOver) {

				sendTOEter ( "\nThe Winner is  :: " + NetworkManager.khg[theChoosenOne] + "\n");
				TrueGameOver = true;
				GameOver = false;
				TrueFight = false;
				fight = false;
				TrueFight = false;
			}

		}
	}
	
	private void calculateInit(int dex) {
		Dice dd = new Dice ();
		int[] roll = dd.Roll (1, 20);
		dex = getMod (dex);
		myInitiativ = roll [0] + dex;
		
		if(dex > 0)
			MChat.roll ("Initiative : " + dd.getSimpleAnswer ()+ "+"+ dex + "(DEX mod)\n");
		
		if(dex == 0 )
			MChat.roll ("Initiative : " + dd.getSimpleAnswer ()  + "\n");
		
		if(dex < 0 )
			MChat.roll ("Initiative : " + dd.getSimpleAnswer () + dex + "(DEX mod)\n");
	}
	
	private void InitiativeRoll(int dex){
		Dice dd = new Dice ();
		int[] roll = dd.Roll (1, 20);
		dex = getMod (dex);
		myInitiativ = roll [0] + dex;
		
		if(dex > 0)
			MChat.roll ("Initiative : " + dd.getSimpleAnswer ()+ "+"+ dex + "(DEX mod)  \n");
		
		if(dex == 0 )
			MChat.roll ("Initiative : " + dd.getSimpleAnswer () + "\n" );
		
		if(dex < 0 )
			MChat.roll ("Initiative : " + dd.getSimpleAnswer () + dex + "(DEX mod)\n");
		
		networkView.RPC ("getIniciative", NetworkView.Find(l[theChoosenOneReversed]).owner , Network.player);
	}

	private void TakeDamage(Skill spell ){
		if (spell.getMod () == "HP") {
			sendTOEter ( "Get " + spell.getSidesOfDice() + " bonus HP " );
			if (Network.isClient)
			{
				networkView.RPC ("send_getDamage", NetworkView.Find(l[theChoosenOneReversed]).owner , 2 );
			}
			else
			{
				networkView.RPC ("send_getDamage", NetworkView.Find(l[theChoosenOne]).owner , 2 );
			}
			//Heal
		} else {
			if(spell.getMod () == "AC"){
				//BUFF
				sendTOEter ( "Get " + spell.getSidesOfDice() + " bonus AC " );
			} else {
				
				int x = AttackRoll (ShowACharacter.a.Statistics.getSTR ());
				if (x < 5) {
					sendTOEter ("Failed roll, Sorry : " + x  + "\n");
				}else {
					if ( x == 20 ) {
						sendTOEter ( " Threat a possibility to take a critical Shot \n Dice will be rolled to confirm \n");
						int b = AttackRoll (ShowACharacter.a.Statistics.getSTR ());
						if( b == 20 ) {
							sendTOEter ( " Roll a critical hit " );
							sendTOEter ( ShowACharacter.a.DName + " attacks enemy with :: \n" +  spell.getSkillName());
							int g = (RollADamage(spell) + 5)*(-1);
							
							if (Network.isClient)
							{
								networkView.RPC ("send_getDamage", NetworkView.Find(l[theChoosenOneReversed]).owner ,g );
							}
							else
							{
								networkView.RPC ("send_getDamage", NetworkView.Find(l[theChoosenOne]).owner ,g );
							}
						} else {
							sendTOEter ( " Failed " );

						}
						
					}else {
						//attack
						sendTOEter ( ShowACharacter.a.DName + " attacks enemy with :: \n" +  spell.getSkillName());
						int g = RollADamage(spell)*(-1);

						if (Network.isClient)
						{
							networkView.RPC ("send_getDamage", NetworkView.Find(l[theChoosenOneReversed]).owner ,g );
						}
						else
						{
							networkView.RPC ("send_getDamage", NetworkView.Find(l[theChoosenOne]).owner ,g );
						}
					}
				}
			}
		}
	}
	
	private int RollADamage(Skill c){
		Dice dd = new Dice ();
		if (c.getMod () == "B") {
			//Roll 1d6 + 1k c.get
			int[] roll = dd.Roll (c.getAmountOfDice(), c.getSidesOfDice());
			int sum = roll[0];
			roll = dd.Roll(1,6);
			sum +=roll[0];
			sendTOEter( " Dmg : " + sum + " ( " + c.getAmountOfDice() + "k" + c.getSidesOfDice() + " + 1d6 ) ");
			return sum;
			
		} else {
			if (c.getAmountOfDice() == 0) {
				sendTOEter ( " Dmg : " + c.getSidesOfDice() );
				return c.getSidesOfDice();
			} else {
				int[] roll = dd.Roll (c.getAmountOfDice(), c.getSidesOfDice());
				sendTOEter ( " Dmg : " + roll[0] + " ( " + c.getAmountOfDice() + "k" + c.getSidesOfDice() + ")" );
				return roll[0];
			}
		}
	}
	
	private int AttackRoll(int str){
		Dice dd = new Dice ();
		int[] roll = dd.Roll (1, 20);
		str = getMod (str);
		int myAttack = roll [0] + str;
		
		if(str > 0)
			rollToEter ( ShowACharacter.a.DName +  " Attack Roll : " + dd.getSimpleAnswer ()+ "+"+ str + "(DEX mod)\n");
		
		if(str == 0 )
			rollToEter (ShowACharacter.a.DName + " Attack Roll : " + dd.getSimpleAnswer () + "\n");
		
		if(str < 0 )
			rollToEter (ShowACharacter.a.DName + " Attack Roll : " + dd.getSimpleAnswer () + str + "(DEX mod)\n");
		
		return myAttack;
	}

	
	private int getMod(int a){
		if( a < 10){
			return -1;
		} else {
			if( a < 12 ) {
				return 0;
			}else {
				if( a < 14 ) {
					return 1;
				} else {
					if ( a < 16 ) {
						return 2;
					} else {
						if( a <18 ) {
							return 3;
						} else {
							if( a < 20 ) {
								return 4 ;
							} else {
								if( a < 22 ) {
									return 5;
								} else {
									if( a < 24 ) {
										return 6;
									} else {
										if( a < 26 ){
											return 7;
										} else {
											return 9;
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}

	public void sendTOEter(string messageToSe){
		networkView.RPC("rollToEter", RPCMode.All, ShowACharacter.a.DName + ": " + messageToSe + "\n");
	}

	[RPC]
	public void rollToEter(string mess){
		MChat.roll(mess);
	}

	
}