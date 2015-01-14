using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class MasterClient : MonoBehaviour {

	public static MasterClient singleton;

	#region Networking Variables
	private const int PORT = 5055;
	private static TcpClient Client;
	private static NetworkStream Stream; 
	private static BinaryWriter ClientWriter;
	private static BinaryReader ClientReader;
	private static DataOutputStream ClientOutput;
	private static DataInputStream ClientInput;
	private static PacketEncoder PacketsOut;
	private static PacketDecoder PacketsIn;
	#endregion

	private static Thread InputListener;

	void Start()
	{
		if (Client == null)
		{
	//		Connect();
		}
	}

	void Awake()
	{
		if (singleton == null) 
		{
						singleton = this;
						DontDestroyOnLoad (this);
		} 
		else 
		{
			Destroy(gameObject);
		}
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Client.Close ();
		}
	}

	public void Connect()
	{
		Client = new TcpClient ();
		try
		{
			Client.Connect(IPAddress.Parse("127.0.0.1"),PORT);
			Stream = Client.GetStream();
			ClientWriter = new BinaryWriter(Stream);
			ClientReader = new BinaryReader(Stream);
			ClientOutput = new DataOutputStream(ClientWriter);
			ClientInput = new DataInputStream(ClientReader);
			PacketsOut = new PacketEncoder(ClientOutput);
			PacketsIn = new PacketDecoder(this,ClientInput);

			PacketsOut.SendLogin("admin","admin");

			InputListener = new Thread(new ThreadStart(InputLoop));
			InputListener.Start ();


		}
		catch(Exception e)
		{
			Debug.LogException(e);
		}
	}

	public void SendPacket(byte packetID, string data)
	{
		string[] packetData = data.Split ('`');
		switch(packetID)
		{
		case 0:
			PacketsOut.SendLogin(packetData[0],packetData[1]);	
			break;
		case 1:
			break;
		case 2:
			break;
		}
	}
	
	void InputLoop()
	{
	while (Client.Connected) 
		{
			byte PacketID = ClientInput.ReadByte();
			switch(PacketID)
			{
			case 0:
				PacketsIn.Login();

				break;
			case 1:
				break;
			case 2:
				break;
			}
		}
	}

	void OnApplicationQuit()
	{
	//	Client.Close ();
	}
}
