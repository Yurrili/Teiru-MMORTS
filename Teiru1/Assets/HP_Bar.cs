using UnityEngine;
using System.Collections;

public class HP_Bar : MonoBehaviour {

	public class PlayerHealth : MonoBehaviour {
		
		public int maxHealth = 100;
		public int curHealth = 100;

		public HPValue HP = new HPValue(4);

		public Texture2D bgImage; 
		public Texture2D fgImage; 
		
		public float healthBarLength;
		
		// Use this for initialization
		void Start () {   
			healthBarLength = Screen.width /2;    
		}
		
		// Update is called once per frame
		void Update () {
			AddjustCurrentHealth(0);
		}
		
		void OnGUI () {

			if (Network.isClient || Network.isServer) {

				GUI.Label(new Rect(400, 20, 100,  20), "LIFE");

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
			
			healthBarLength =(Screen.width /2) * (curHealth / (float)maxHealth);
		}
	}
}
