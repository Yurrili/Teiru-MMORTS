using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {


	private const string typeName = "UniqueGameName";
	private const string gameName = "RoomName";
	private const int maxPlayers = 10;
	private const int PORT = 55555;
	private HostData[] hostList;
	public GameObject playerPrefab;

	void OnServerInitialized()
	{
		SpawnPlayer();
	}
	
	void OnConnectedToServer()
	{
		SpawnPlayer();
	}
	
	private void SpawnPlayer()
	{
		Network.Instantiate(playerPrefab, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
	}

	
	void StartServer()
	{
		Network.InitializeServer(maxPlayers, PORT, !Network.HavePublicAddress());
		MasterServer.RegisterHost(typeName, gameName);
	}

	/*void OnServerInitialized()
	{
		Debug.Log("Server Initializied");
	}*/

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
	

	void Update()
	{

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
		Network.Connect(hostData);
	}
	
	/*void OnConnectedToServer()
	{
		Debug.Log("Server Joined");
	}*/

}
