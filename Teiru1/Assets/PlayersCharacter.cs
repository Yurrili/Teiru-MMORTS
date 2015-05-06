using UnityEngine;
using System.Collections;

public class PlayersCharacter {

	public string PlayerName;
	public string DName;
	public CharacterClass Class_;
	public CharacterStats Statistics;


	public PlayersCharacter(string PlayerName, string CharacterName,int ClassOfCharacter, int STR, int DEX, int CON, int INT , int WIS, int CHA, int level ) {

		this.PlayerName = PlayerName;
		this.DName = CharacterName;
		this.Statistics = new CharacterStats ();

			Statistics.setCHA (CHA);
			Statistics.setCON (CON);
			Statistics.setINT (INT);
			Statistics.setWIS (WIS);
			Statistics.setDEX (DEX);
			Statistics.setSTR (STR);

		switch( ClassOfCharacter )
		{
			case 0 :
				Class_ = new CharacterClass_Ranger(CON);
				(Class_ as CharacterClass_Ranger).setLvl (level);
			break;

			case 1 :
				Class_ = new CharacterClass_Mage(CON);
				(Class_ as CharacterClass_Mage).setLvl (level);
			break;

			case 2 :
				Class_ = new CharacterClass_Knight(CON);
				(Class_ as CharacterClass_Knight).setLvl (level);
			break;

			case 3 :
				Class_ = new CharacterClass_Mystiq(CON);
				(Class_ as CharacterClass_Mystiq).setLvl (level);
			break;
		}



	}
}
