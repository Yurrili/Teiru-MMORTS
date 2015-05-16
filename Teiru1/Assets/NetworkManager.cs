using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	
	
	private const string typeName = "Teiru";
	private const string gameName = "Baboon";
	private const int maxPlayers = 10;
	private HostData[] hostList;
	public GameObject playerPrefab;
	public static GameObject p;
	public NetworkPlayer np1;

	
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

	void OnDisconnectedFromServer(NetworkDisconnection info) {
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

	void OnApplicationQuit() {
		Debug.Log("OnApplicationQuit");
		Network.RemoveRPCs(Network.player);
		Network.DestroyPlayerObjects(Network.player);

	}

	void OnFailedToConnect(NetworkConnectionError error) {
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


	private void SpawnPlayer()
	{
		p  = Network.Instantiate(playerPrefab, new Vector3(0f, 5f, 0f), Quaternion.identity, 0) as GameObject;
		print ("SpawnPlayer" + p.name);
	}
	
	
	void StartServer()
	{
		Network.InitializeServer(maxPlayers, 22222, true);
		MasterServer.RegisterHost(typeName, gameName);
	}

	
	void OnGUI()
	{
		if (!Network.isClient && !Network.isServer)
		{
			if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
				StartServer();
			
			if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh Hosts"))
				RefreshHostList();
			
			if (hostList != null)
			{
				for (int i = 0; i < hostList.Length; i++)
				{

					if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostList[i].gameName))
						JoinServer(hostList[i]);
				}
			}
		}
	}
	
	

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
