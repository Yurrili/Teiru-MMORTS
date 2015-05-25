﻿using UnityEngine;
using System.Collections;

public class MChat : MonoBehaviour 
{
	public Rect windowRect = new Rect(200, 200, 300, 300);
	public static string messBox = "", messageToSend = "", user = "";
	
	private void OnGUI()
	{
		
		
		if (NetworkPeerType.Disconnected != Network.peerType)
			windowRect = GUI.Window(1, windowRect, windowFunc, "Chat");
	}
	
	private void windowFunc(int id)
	{
		GUILayout.Box(messBox , GUILayout.Height(200));
		GUIStyle myStyle = new GUIStyle(GUI.skin.textField);
		myStyle.alignment = TextAnchor.MiddleLeft;
		GUILayout.BeginHorizontal();
		messageToSend = GUILayout.TextField(messageToSend ,myStyle);
		if (GUILayout.Button("Send" , GUILayout.Width(75)))
		{
			networkView.RPC("sendMessage", RPCMode.All, ShowACharacter.a.DName + ": " + messageToSend + "\n");
			messageToSend = "";
		}
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
		GUILayout.Label("User:");
		user = ShowACharacter.a.DName;
		
		GUILayout.EndHorizontal();
		
		GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
	}
	
	[RPC]
	public void sendMessage(string mess)
	{
		messBox += mess;
	}

	public static void roll(string m) 
	{
		messBox += m;
	}
}