using UnityEngine;
using System.Collections;

public class OnScreen : MonoBehaviour {

	public Texture aTexture;
	public Texture range;
	public static float Rect_range_Width = Screen.width - 85;
	public static float Rect_range_hight = 62;
	void OnGUI()
	{

		if (GUI.Button (new Rect (10, 5, 50, 30), "Exit")) {
			Application.Quit();
		}
			//StartServer();
		
		if (GUI.Button (new Rect (80, 5, 140, 30), "Return to menu")) {
						//RefreshHostList();
		}


		GUI.DrawTexture(new Rect(Screen.width-205, 5, 200, 200), aTexture, ScaleMode.ScaleToFit);
		GUI.DrawTexture(new Rect(Rect_range_Width, Rect_range_hight, 15, 15), range, ScaleMode.ScaleToFit);


	}

}
