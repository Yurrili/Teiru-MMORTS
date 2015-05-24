using UnityEngine;
using System.Collections;

public class HP_Bar : MonoBehaviour {

	public Texture2D HP ;
	public Texture2D Labels ;
	public Texture2D av;
	public static Texture2D[] sprites;

	private int number = 0;

	private static float maxHealth = (float)(ShowACharacter.a.Class_.getHPValue().getMAXHP()*100);
	private static float lenghtMaxHP = (float)((ShowACharacter.a.Class_.getHPValue().getMAXHP()/ShowACharacter.a.Class_.getHPValue().getMAXHP())*100);
	private static float curHealth = (float)((ShowACharacter.a.Class_.getHPValue().getCurrentHP()/ShowACharacter.a.Class_.getHPValue().getMAXHP())*100);
		

	// Use this for initialization
	void Start () { 
		sprites = Resources.LoadAll<Texture2D>("avatars"); 
		
	}
		
	// Update is called once per frame
	void Update () {

	}
		
	void OnGUI () {

	GUIStyle hp = new GUIStyle ();
		hp.normal.background = HP;
		hp.normal.textColor = Color.yellow;

	GUIStyle cStyl = new GUIStyle ();
		cStyl.normal.background = Labels;
		cStyl.normal.textColor = Color.white;
		cStyl.alignment = TextAnchor.MiddleCenter;
			
	GUIStyle c = new GUIStyle();
		c.normal.textColor = Color.yellow;

			if (Network.isClient || Network.isServer) {

				//HealthBar
				if(ShowACharacter.a != null ){
					
					char d = ShowACharacter.a.Avatar.ToCharArray ()[2];
					
					number = int.Parse(d+"");

					maxHealth = (float)(ShowACharacter.a.Class_.getHPValue().getMAXHP()*100);
					lenghtMaxHP = (float)((ShowACharacter.a.Class_.getHPValue().getMAXHP()/ShowACharacter.a.Class_.getHPValue().getMAXHP())*100);
					curHealth = (float)((ShowACharacter.a.Class_.getHPValue().getCurrentHP()/ShowACharacter.a.Class_.getHPValue().getMAXHP())*100);

					GUI.Box(new Rect(5, 35, 190, 90),"", cStyl);
					GUI.DrawTexture(new Rect(23, 60, 40, 40), sprites[number], ScaleMode.ScaleToFit);
					
					string nameLabel = "Name : " + NetworkManager.khg[0];
					
					GUI.Label(new Rect(75, 50, 80,  5), nameLabel, c);
					GUI.Box(new Rect(77, 72, lenghtMaxHP,  5), "HP");
					GUI.Box(new Rect(77, 72, curHealth,  5), "LVL 1", hp);
					
					string state = "State :" + ShowACharacter.a.Class_.getHPValue().getState();
					
					GUI.Label(new Rect(77, 90,100,  5), state, c);

				}

			}
		
		}
		


}
