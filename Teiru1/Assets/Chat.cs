using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Chat : MonoBehaviour
{    
	public List<ChatMessage> messages = new List<ChatMessage> ();
	public string InputString = "";
	static public bool show = false;
	static HostData data;
	public Vector2 v = new Vector2(0, (Screen.height/2) - (Screen.height/8));



	void Update()
	{
		//if (show) {
		if(InputString.Contains("\n"))
		{
			SendMessage (InputString, "MyName");
			InputString = "";
		}
		//}				
	}

	void OnGUI()
	{
		if (show) 
		{
			GUILayout.BeginArea(new Rect(0, Screen.height/3 * 2, (Screen.width/3), (Screen.height/4)));
			v = GUILayout.BeginScrollView(v, "box", GUILayout.Width(Screen.width/3), GUILayout.Height(Screen.height/4));
			foreach(ChatMessage m in messages)
			{
				GUILayout.Label (m.Sender + ": " + m.Message);
			}
			GUILayout.EndScrollView ();
			GUILayout.EndArea();
			InputString = GUI.TextArea(new Rect(0, (Screen.height/16 * 15), Screen.width/3, Screen.height/16), InputString);

		}                             
	}

	public void SendMessage(string m, string sender)
	{
		networkView.RPC ("Client_SendMessage", RPCMode.All, m, sender);
		print ("sending2");
	}

	public static void Show()
	{
		show = true;
	}

	public static void ReceiveData(HostData a)
	{
		data = a;
	}

	[RPC]
	void Client_SendMessage(string m, string sender)
	{
		Convert (m, sender);
	}

	void Convert(string Message, string Sender)
	{
		ChatMessage cm = new ChatMessage (Sender, Message);
		messages.Add (cm);
	}
}

[System.Serializable]
public class ChatMessage
{
	public ChatMessage(string SenderName, string msg)
	{
		Sender = SenderName;
		Message = msg;
	}

	public string Message;
	public string Sender;
}