using UnityEngine;
using System.Collections;

public class Boots : Item {


	public Boots(int a)
	{
		base.itemDD = a;
		if (a == 0) {
			base.name = "Boots of the Celestial Battalion";
			base.Description = "This boots are so fine and light that they can fly \n " ;
			base.cost = 20;
			base.isDestroyed = false;
			base.Part = "Boots";
			base.Type = "Light boots";
			CharacterStats temp = new CharacterStats ();
			temp.setCHA (0);
			temp.setCON (0);
			temp.setINT (0);
			temp.setDEX (2);
			temp.setSTR (0);
			temp.setWIS (0);
			base.bonus = temp;
		} else {
			if (a == 1) {
				base.name = "Elven Boots";
				base.Description = "This extremely light boots are made of very fine mithral aglets. \n " +
					"It has a maximum Dexterity bonus of +3 and Inteligent bonus +2 .";
				base.cost = 40;
				base.isDestroyed = false;
				base.Part = "Boots";
				base.Type = "Light boots";
				CharacterStats temp = new CharacterStats ();
				temp.setCHA (0);
				temp.setCON (0);
				temp.setINT (2);
				temp.setDEX (3);
				temp.setSTR (0);
				temp.setWIS (0);
				base.bonus = temp;
			} else {
				if (a == 2) {
					base.name = "Warlord’s Boots";
					base.Description = "This mithral aglets in boots allows the wearer \nto attract and lead a number of followers ";
					
					base.cost = 60;
					base.isDestroyed = false;
					base.Part = "Boots";
					base.Type = "Light boots";
					CharacterStats temp = new CharacterStats ();
					temp.setCHA (2);
					temp.setCON (0);
					temp.setINT (2);
					temp.setDEX (5);
					temp.setSTR (0);
					temp.setWIS (0);
					base.bonus = temp;
				} else {
					if (a == 3) {
						base.name = "Demon Boots";
						base.Description = "This armor boots is fashioned to make the wearer appear \n" + 
							"to be a demon. The pictures on the heals are shaped to look like a horned demon head";
						base.cost = 20;
						base.isDestroyed = false;
						base.Part = "Boots";
						base.Type = "Heavy boots";
						CharacterStats temp = new CharacterStats ();
						temp.setCHA (0);
						temp.setCON (1);
						temp.setINT (0);
						temp.setDEX (0);
						temp.setSTR (2);
						temp.setWIS (0);
						base.bonus = temp;
					} else {
						if (a == 5) {
							base.name = "Dragonskin Boots";
							base.Description = "This boots are crafted from the hide of a great wyrm dragon.\n" +
								" At the wearer’s command, the boots sprouts enormous dragon wings, \n" +
									"allowing the wearer to fly .";
							base.cost = 60;
							base.isDestroyed = false;
							base.Part = "Boots";
							base.Type = "Heavy boots";
							CharacterStats temp = new CharacterStats ();
							temp.setCHA (1);
							temp.setCON (2);
							temp.setINT (0);
							temp.setDEX (4);
							temp.setSTR (0);
							temp.setWIS (0);
							base.bonus = temp;
						} else {
							if (a == 4) {
								base.name = "Boots of Luck";
								base.Description = "Ten 100-gp gems adorn this boots. \n " + "Gives wearer a bonus + 3 to strength and +1 to condition ";
								base.cost = 40;
								base.isDestroyed = false;
								base.Part = "Boots";
								base.Type = "Heavy boots";
								CharacterStats temp = new CharacterStats ();
								temp.setCHA (1);
								temp.setCON (1);
								temp.setINT (0);
								temp.setDEX (2);
								temp.setSTR (0);
								temp.setWIS (0);
								base.bonus = temp;
							}
							
						}
					}
				}
			}
		}}
} 

