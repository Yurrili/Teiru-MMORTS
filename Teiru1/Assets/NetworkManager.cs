using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
public class NetworkManager : MonoBehaviour {
	
	public Texture2D buttonsA;
	public Texture2D buttonsB;
	public Texture2D inputField;
	public Texture panel;
	private const string typeName = "Teiru";
	private string gameName = "Baboon";
	private const int maxPlayers = 10;
	public static string ServerName;

	private HostData[] hostList;
	public GameObject playerPrefab;
	public static GameObject p;
	public NetworkPlayer np1;
	public static List<NetworkViewID> playerList;

	public static string skak = "";

	public static List<string> khg = new List<string>();


	void OnServerInitialized()
	{
		np1 = Network.player;
		SpawnPlayer();
		print ("OnServerInitialized");
	}
	
	void OnConnectedToServer()
	{
		SpawnPlayer();
		print ("OnConnectedInitialized");
	}

	void OnDisconnectedFromServer(NetworkDisconnection info) 
	{
		if (Network.isServer)
		{
			Debug.Log("Local server connection disconnected");
			//Network.RemoveRPCs(np1);
			//Network.DestroyPlayerObjects(np1);
		}
		else
			if (info == NetworkDisconnection.LostConnection)
			{
				Debug.Log("Lost connection to the server");
			}
			else
			{
			Debug.Log("Successfully diconnected from the server");
			Network.RemoveRPCs(Network.player);
			Network.DestroyPlayerObjects(Network.player);
			}
	}

	void OnApplicationQuit() 
	{
		Debug.Log("OnApplicationQuit");
		Network.RemoveRPCs(Network.player);
		Network.DestroyPlayerObjects(Network.player);

	}



	void OnFailedToConnect(NetworkConnectionError error) 
	{
		Debug.Log("Could not connect to server: " + error);
		Network.RemoveRPCs(Network.player);
		Network.DestroyPlayerObjects(Network.player);
	}

	void OnPlayerDisconnected(NetworkPlayer np)
	{
		Debug.Log("OnPlayerDisconnected");
		Network.RemoveRPCs(np);
		Network.DestroyPlayerObjects(np);
	}

	[RPC]
	public void addPlayer(NetworkViewID p)
	{
		playerList.Add (p);
	}

	[RPC]
	public void asd(string h)
	{
		skak = h;
		khg.Add (h);
	}


	private void SpawnPlayer()
	{
		//playerPrefab.rigidbody2D.gravityScale = 0.01f;
		p  = Network.Instantiate(playerPrefab, new Vector3(-8168f, -9298f, 0f), Quaternion.identity, 0) as GameObject;
		p.rigidbody2D.gravityScale = 0;
		networkView.RPC ("asd", RPCMode.AllBuffered, MenuManager._Character_.DName );
	/*	if (Network.isClient)
		{
			networkView.RPC("addPlayer",RPCMode.Server, Move.getId());
		}
		else
		{
			playerList.Add (Move.getId());
		}
		//camera.transform.parent = p;
		print ("SpawnPlayer" + p.name);*/
	}


	
	void StartServer()
	{
		playerList = new List<NetworkViewID> ();
		Network.InitializeServer(maxPlayers, 22222, true);
		MasterServer.RegisterHost(typeName, gameName);
	}


	
	void OnCollisionEnter2D(Collision2D coll)
	{
		string pe = coll.gameObject.name;
		if (coll.gameObject.name.Contains("(Clone)"))
		{
			Debug.Log("fff");
			Physics2D.IgnoreCollision(coll.collider, p.collider2D);
		}
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

		GUIStyle cStyl = new GUIStyle ();
		cStyl.normal.background = inputField;
		cStyl.alignment = TextAnchor.MiddleCenter;
		cStyl.normal.textColor = Color.yellow;

		if (!Network.isClient && !Network.isServer)
		{

			GUIStyle c = new GUIStyle();
			c.normal.textColor = Color.yellow;

			GUI.DrawTexture(new Rect(Screen.width/2 - 168, 140, 340, 130), panel, ScaleMode.StretchToFill);


			gameName = GUI.TextArea(new Rect(Screen.width/2 - 120, 160, 250, 50), gameName, 40, cStyl);
			ServerName = gameName;

			if (GUI.Button(new Rect(Screen.width/2 - 120, 210, 250, 50), "Start Server", a))
			{
				StartServer();
			}
				
			GUI.DrawTexture(new Rect(Screen.width/2 - 197, 280, 400, 400), panel, ScaleMode.ScaleToFit);

			if (GUI.Button(new Rect(Screen.width/2 - 120, 310, 250, 50), "Refresh Hosts", a))
				RefreshHostList();

			GUI.Label(new Rect(Screen.width/2 - 100, 367, 250, 50), "Available servers: ", c);
			
			if (hostList != null)
			{
				for (int i = 0; i < hostList.Length; i++)
				{

					if (GUI.Button(new Rect(Screen.width/2 - 120, 390 + (60 * i), 250, 50), hostList[i].gameName, a))
						JoinServer(hostList[i]);
				}
			}
		}

		if (Network.isClient || Network.isServer) {		
			GUI.Label(new Rect(Screen.width-210,200,209,20), gameName, cStyl);
			int number_players = Network.connections.Length + 1;
			GUI.Label(new Rect(Screen.width-210,220,209,20), "Players in game : " +  number_players,cStyl);	

		}
		/*	if (GUI.Button (new Rect (Screen.width / 2 - 120, 210, 250, 50), "Wann` fight m8",a)) 
			{
				if (Network.isClient)
				{
					for (int i =0;i<Network.connections.Length;i++)
					{
					networkView.RPC ("retList", RPCMode.Server,i);
					}
				}
				else
				{
					Move.l = playerList;
					Move.might = true;
				}
			}*/
		
	}

	/*[RPC]
	public void retList(int i)
	{
		networkView.RPC("getList", RPCMode.Others, playerList[i]);
	}
	
	[RPC]
	public void getList(NetworkViewID id)
	{
		Move.l.Add (id);
		Move.might = true;
		//networkView.RPC ("showList", RPCMode.Others, new object[] {name, h});
	}*/

	private void RefreshHostList()
	{
		MasterServer.RequestHostList(typeName);
	}
	
	void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		if (msEvent == MasterServerEvent.HostListReceived)
			hostList = MasterServer.PollHostList();
	}
	
	private void JoinServer(HostData hostData)
	{
		Debug.Log("Server Joined");
		HostData hs = hostData;
		Network.Connect(hostData);
	}
	
	/*void OnConnectedToServer()
	{
		Debug.Log("Server Joined");
	}*/
	
}
