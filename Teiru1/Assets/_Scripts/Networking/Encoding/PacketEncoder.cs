using UnityEngine;
using System.Collections;

public class PacketEncoder 
{

	private static DataOutputStream ClientOutput;

	public PacketEncoder(DataOutputStream clientOutput)
	{
		ClientOutput = clientOutput;
	}

	public void SendLogin(string username, string password)
	{
		Debug.Log ("username" + username + "passowrd" + password);
		ClientOutput.WriteUTF (username);
		ClientOutput.WriteUTF (password);
		ClientOutput.Flush ();
	}
}
