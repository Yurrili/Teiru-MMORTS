using UnityEngine;
using System.Collections;
using ogclient_framework;

public class Client : MonoBehaviour 
{
	public static Client singleton;
	private GameClient client;

	void Awake()
	{
		if (singleton == null) 
		{
			DontDestroyOnLoad(this);
		}
		else
		{
			DestroyImmediate(this);
		}
	}

	void Start()
	{
		singleton = this;
		client = new GameClient ("localhost");
		client.TcpPort = 5055;
		client.UdpPort = 5056;
		PacketManager.Init ();
		client.Init ();
	}

	void Update()
	{
		client.Update ();
	}

	void OnApplicationQuit()
	{
		client.OnApplicationQuit();
	}
}
