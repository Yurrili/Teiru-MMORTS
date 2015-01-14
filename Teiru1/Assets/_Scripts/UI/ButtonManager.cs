using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour 
{

	private MasterClient MClient;

	void Start()
	{
		MClient = GameObject.Find ("MasterClient").GetComponent<MasterClient>();
	}

	public void SendLogin()
	{
//		InputField[] loginData = GameObject.Find ("LoginPanel").GetComponentsInChildren<InputField> ();
//		string username = loginData [0].text.ToString ();
//		string password = loginData [1].text.ToString ();

//		MClient.SendPacket (0,username + "`" + password );
	}
}
