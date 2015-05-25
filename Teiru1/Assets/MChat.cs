﻿using UnityEngine;
using System.Collections;

public class MChat : MonoBehaviour 
{
	public GUISkin myskin;
	
	private Rect windowRect = new Rect(200, 200, 300, 450);
	public static string messBox = "", messageToSend = "", user = "";
	
	private void OnGUI()
	{
		GUI.skin = myskin;
		if (NetworkPeerType.Disconnected != Network.peerType)
			windowRect = GUI.Window(1, windowRect, windowFunc, "Chat");
	}
	
	private void windowFunc(int id)
	{
		GUILayout.Box(messBox, GUILayout.Height(350));
		
		GUILayout.BeginHorizontal();
		messageToSend = GUILayout.TextField(messageToSend);
		if (GUILayout.Button("Send" , GUILayout.Width(75)))
		{
			networkView.RPC("SendMessage", RPCMode.All, user + ": " + messageToSend + "\n");
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
	public void SendMessage(string mess)
	{
		messBox += mess;
	}
	
	public static void roll(string m)
	{
		messBox += m;
	}
}