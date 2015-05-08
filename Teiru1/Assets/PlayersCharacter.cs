using UnityEngine;
using System.Collections;

public class PlayersCharacter {

	public string PlayerName;
	public string DName;
	public CharacterClass Class_;
	public CharacterStats Statistics;
	public Item [] Equ = new Item[4];
	public string Avatar ;

	public PlayersCharacter(string PlayerName, string CharacterName,int ClassOfCharacter, int STR, int DEX, int CON, int INT , int WIS, int CHA, int level , int helmet, int chest, int boots, int weapon, string Avatar, string spell) {

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
			case 1 :
				Class_ = new CharacterClass_Ranger(CON);
				(Class_ as CharacterClass_Ranger).setLvl (level);
				(Class_ as CharacterClass_Ranger).setSkill(spell);
			break;

			case 2 :
				Class_ = new CharacterClass_Mage(CON);
				(Class_ as CharacterClass_Mage).setLvl (level);
				(Class_ as CharacterClass_Mage).setSkill(spell);
			break;

			case 3 :
				Class_ = new CharacterClass_Knight(CON);
				(Class_ as CharacterClass_Knight).setLvl (level);
				(Class_ as CharacterClass_Knight).setSkill(spell);
			break;

			case 4 :
				Class_ = new CharacterClass_Mystiq(CON);
				(Class_ as CharacterClass_Mystiq).setLvl (level);
				(Class_ as CharacterClass_Mystiq).setSkill(spell);
			break;
		}

			Equ [0] = new Helmet(helmet);
			Equ [1] = new Chest (chest);
			Equ [2] = new Boots(boots);
			Equ [3] = new Weapon(weapon);

		this.Avatar = Avatar;
	}
}
