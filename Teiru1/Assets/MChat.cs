using UnityEngine;
using System.Collections;

public class MChat : MonoBehaviour 
{
	public Texture panel;
	private Rect windowRect = new Rect(200, 200, 300, 300);
	private string messBox = "", messageToSend = "", user = "";
	private Vector2 scrollvector = new Vector2(0,0);
	
	private void OnGUI()
	{
		
		
		if (NetworkPeerType.Disconnected != Network.peerType)
			windowRect = GUI.Window(1, windowRect, windowFunc, "Chat");
	}
	
	private void windowFunc(int id)
	{
		GUI.BeginGroup(new Rect(0,10,300,200));
		scrollvector = GUILayout.BeginScrollView( scrollvector, GUILayout.Width(300), GUILayout.Height(200));
		GUILayout.Box(messBox);
		GUILayout.EndScrollView();
		GUI.EndGroup ();



		//GUI.BeginGroup(new Rect(20,230,400,400));
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

		//GUI.EndGroup ();
		
		GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
	}
	
	[RPC]
	public void sendMessage(string mess)
	{
		messBox += mess;
	}
}