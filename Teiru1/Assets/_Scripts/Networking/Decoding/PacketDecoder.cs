using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PacketDecoder 
{

	private static DataInputStream ClientInput;
	private MasterClient MClient;

	public PacketDecoder(MasterClient client, DataInputStream clientInput)
	{
		MClient = client;
		ClientInput = clientInput;
	}

	public bool Login()
	{
		bool success = ClientInput.ReadBoolean ();
		if (success) 
		{
			string username = ClientInput.ReadUTF();
			Debug.Log ("Succesfully logged in");
			return success;
		}

		byte opcode = ClientInput.ReadByte ();
		GameObject.Find ("txtLoginMessage").GetComponent<Text>().text = GetLoginMessage(opcode);
		//Debug.Log ("Failed to log in");
		return success;
	}

	private string GetLoginMessage(byte opcode)
	{
	switch(opcode)
		{
		case 0:
			return "Invalid username or password";
			break;
		case 1:
			return "Account is already logged in";
			break;
		default:
			return "invalid opcode sent from server";
			break;
		}
	}
}

