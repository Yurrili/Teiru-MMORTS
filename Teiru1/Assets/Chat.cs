using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Chat : MonoBehaviour
{    
	public List<ChatMessage> messages = new List<ChatMessage> ();
	public string InputString = "";
	static bool show = false;
	static HostData data;
	public Vector2 v = new Vector2(Screen.height/5 * 4, (Screen.height/2) - (Screen.height/8));



	void Update()
	{
		//if (show) {
		if(Input.GetKeyDown (KeyCode.Return))
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
			GUILayout.BeginScrollView(v, "box", GUILayout.Width(Screen.width/3), GUILayout.Height(Screen.height/4));
			foreach(ChatMessage m in messages)
			{
				GUILayout.Label (m.Sender + ": " + m.Message);
			}
			GUILayout.EndScrollView ();
			InputString = GUI.TextArea(new Rect(0, (Screen.height/2) - (Screen.height/64) + 110, Screen.width/3, Screen.height/16), InputString);


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