using UnityEngine;
using System.Collections;

public class PlayersCharacter {

	private string PlayerName;
	private string Name;
	private CharacterClass Class_;
	private CharacterStats Statistics;


	public PlayersCharacter(string PlayerName, string CharacterName,int ClassOfCharacter, int STR, int DEX, int CON, int INT , int WIS, int CHA ) {

		this.PlayerName = PlayerName;
		this.Name = CharacterName;
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
			break;

			case 1 :
				Class_ = new CharacterClass_Mage(CON);
			break;

			case 2 :
				Class_ = new CharacterClass_Knight(CON);
			break;

			case 3 :
				Class_ = new CharacterClass_Mystiq(CON);
			break;
		}


	}
}
