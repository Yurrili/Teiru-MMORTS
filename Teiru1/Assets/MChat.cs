﻿using UnityEngine;
using System.Collections;

public class MChat : MonoBehaviour 
{
	public Texture panel;
	private Rect windowRect = new Rect(200, 200, 300, 450);
	private string messBox = "", messageToSend = "", user = "";
	
	private void OnGUI()
	{


		if (NetworkPeerType.Disconnected != Network.peerType)
			windowRect = GUI.Window(1, windowRect, windowFunc, "Chat");
	}
	
	private void windowFunc(int id)
	{
		GUILayout.Box(messBox , GUILayout.Height(350));
		GUIStyle myStyle = new GUIStyle(GUI.skin.textField);
		myStyle.alignment = TextAnchor.MiddleLeft;
		GUILayout.BeginHorizontal();
		messageToSend = GUILayout.TextField(messageToSend ,myStyle);
		if (GUILayout.Button("Send" , GUILayout.Width(75)))
		{
			networkView.RPC("sendMessage", RPCMode.All, user + ": " + messageToSend + "\n");
			messageToSend = "";
		}
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
		GUILayout.Label("User:");
		user = GUILayout.TextField(user);
		
		GUILayout.EndHorizontal();
		
		GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
	}
	
	[RPC]
	public void sendMessage(string mess)
	{
		messBox += mess;
	}
}
