using UnityEngine;
using System.Collections;

public class OnScreen : MonoBehaviour {

	public Texture aTexture;

	public Texture range;
	public Texture2D buttonsA;
	public Texture2D buttonsB;

	public static float Rect_range_Width = Screen.width - 167;
	public static float Rect_range_hight = 187;

	void OnGUI()
	{
		GUIStyle a = new GUIStyle ();
		a.alignment = TextAnchor.MiddleCenter;
		a.normal.background = buttonsA;
		a.onNormal.background = buttonsA;
		a.onHover.background = buttonsB;
		a.hover.background = buttonsB;

		a.normal.textColor = Color.yellow;
		a.onNormal.textColor = Color.yellow;
		a.hover.textColor = Color.yellow;
		a.onHover.textColor = Color.yellow;

		if (GUI.Button (new Rect (10, 5, 80, 40), "Exit", a)) {
			Application.Quit();
		}
			//StartServer();
		
		
		if (GUI.Button (new Rect (80, 5, 160, 40), "Return to menu", a)) 
		{
				Application.LoadLevel("a");

		}
		//-8168f, -9298f

		if (Network.isClient || Network.isServer)
		{
			GUI.DrawTexture(new Rect(Screen.width-205, 5, 200, 200), aTexture, ScaleMode.ScaleToFit);
			GUI.DrawTexture(new Rect(Rect_range_Width, Rect_range_hight, 15, 15), range, ScaleMode.ScaleToFit);
		}

	}

}
