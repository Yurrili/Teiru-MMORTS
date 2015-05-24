using UnityEngine;
using System.Collections;

public class HP_Bar : MonoBehaviour {
	

		public Texture2D HP ;
		public Texture2D Labels ;
		public Texture2D av;
		public static HPValue Health = ShowACharacter.a.Class_.getHPValue();
	
		private  static float maxHealth = (float)(Health.getMAXHP()*100);
		private static float lenghtMaxHP = (float)((Health.getMAXHP()/Health.getMAXHP())*100);
		private  static float curHealth = (float)((Health.getCurrentHP()/Health.getMAXHP())*100);

	public static Texture2D[] sprites;
		// Use this for initialization
		void Start () {   
		}
		
		// Update is called once per frame
		void Update () {
			AddjustCurrentHealth(0);
		}
		
		void OnGUI () {
			GUIStyle hp = new GUIStyle ();
			hp.normal.background = HP;
			hp.normal.textColor = Color.yellow;

			GUIStyle cStyl = new GUIStyle ();
			cStyl.normal.background = Labels;
			cStyl.normal.textColor = Color.white;
			cStyl.alignment = TextAnchor.MiddleCenter;

			
			sprites = Resources.LoadAll<Texture2D>("avatars"); 
			
		GUIStyle c = new GUIStyle();
		c.normal.textColor = Color.yellow;

			if (Network.isClient || Network.isServer) {

				//HealthBar

			char d = ShowACharacter.a.Avatar.ToCharArray ()[2];
			int number = int.Parse(d+"");
			GUI.Box(new Rect(5, 35, 190, 90),"", cStyl);
			GUI.DrawTexture(new Rect(23, 60, 40, 40), sprites[number], ScaleMode.ScaleToFit);
			string nameLabel = "Name : " + NetworkManager.khg[0];
			GUI.Label(new Rect(75, 50, 80,  5), nameLabel, c);
			GUI.Box(new Rect(77, 72, lenghtMaxHP,  5), "HP");
			GUI.Box(new Rect(77, 72, curHealth,  5), "LVL 1", hp);
				
				string state = "State :" + Health.getState();
			GUI.Label(new Rect(77, 90,100,  5), state, c);

			}
		
		}
		
		public void AddjustCurrentHealth(int adj){
			
			curHealth += adj;
			
			if(curHealth <0)
				curHealth = 0;
			
			if(curHealth > maxHealth)
				curHealth = maxHealth;
			
			if(maxHealth <1)
				maxHealth = 1;
			
			//healthBarLength =(Screen.width /2) * (curHealth / (float)maxHealth);
		}

}
