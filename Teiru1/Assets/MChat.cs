using UnityEngine;
using System.Collections;

public class MChat : MonoBehaviour 
{
	public GUISkin myskin;
	
	private Rect windowRect = new Rect(10, 400, 300, 300);
	public static string messBox = "", messageToSend = "", user = "";
	private Vector2 scrollvector = new Vector2(0,0);

	private void OnGUI()
	{
		GUI.skin = myskin;
		if (NetworkPeerType.Disconnected != Network.peerType)
			windowRect = GUI.Window(1, windowRect, windowFunc, "Chat");
	}
	
	private void windowFunc(int id)
	{


		GUI.BeginGroup(new Rect(20,0,250,200));
		scrollvector = GUILayout.BeginScrollView( scrollvector, GUILayout.Width(250), GUILayout.Height(200));
		GUILayout.Box(messBox, GUILayout.Width(250), GUILayout.ExpandHeight(true));
		GUILayout.EndScrollView();
		GUI.EndGroup ();

		GUIStyle myStyle = new GUIStyle(GUI.skin.textField);
		myStyle.alignment = TextAnchor.MiddleLeft;
		GUILayout.BeginHorizontal();
		messageToSend = GUILayout.TextField(messageToSend ,myStyle);

		//GUILayout.Box(messBox, GUILayout.Height(350));
		
		//GUILayout.BeginHorizontal();
		//messageToSend = GUILayout.TextField(messageToSend);
		if (GUILayout.Button("Send" , GUILayout.Width(75)))
		{
			networkView.RPC("SendMessage", RPCMode.All, user + ": " + messageToSend + "\n");
			messageToSend = "";
		}
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
		GUILayout.Label("User:");
		user = ShowACharacter.a.DName;
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