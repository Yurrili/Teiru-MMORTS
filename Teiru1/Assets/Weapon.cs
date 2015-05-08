using UnityEngine;
using System.Collections;

public class Weapon : Item {
	
	public Weapon(int a)
	{
		base.itemDD = a;
		if (a == 0) {
			base.name = "Axe of the Celestial Battalion";
			base.Description = "battleaxe forged by master dwarven and poladar blacksmiths and blessed \n" +
				"by a great sorcerer, it was made for a poladar chief.\n " ;
			base.cost = 20;
			base.isDestroyed = false;
			base.Part = "Weapon";
			base.Type = "Axe";
			CharacterStats temp = new CharacterStats ();
			temp.setCHA (0);
			temp.setCON (1);
			temp.setINT (0);
			temp.setDEX (2);
			temp.setSTR (0);
			temp.setWIS (0);
			base.bonus = temp;
		} else {
			if (a == 1) {
				base.name = "Elven Blade";
				base.Description = "This sword (like the other eleven) has a generic metallic colored blade and a black hilt.\n" +
					"There is a small white symbol (See Symbol below) etched in on side of the black hilt.";
				base.cost = 40;
				base.isDestroyed = false;
				base.Part = "Weapon";
				base.Type = "Sword";
				CharacterStats temp = new CharacterStats ();
				temp.setCHA (1);
				temp.setCON (0);
				temp.setINT (1);
				temp.setDEX (1);
				temp.setSTR (0);
				temp.setWIS (1);
				base.bonus = temp;
			} else {
				if (a == 2) {
					base.name = "Warlord’s Bow";
					base.Description = "This mithral elements of bow allows the shooter \nto attract and lead a number of followers ";
					
					base.cost = 60;
					base.isDestroyed = false;
					base.Part = "Weapon";
					base.Type = "Bow";
					CharacterStats temp = new CharacterStats ();
					temp.setCHA (4);
					temp.setCON (0);
					temp.setINT (1);
					temp.setDEX (1);
					temp.setSTR (0);
					temp.setWIS (0);
					base.bonus = temp;
				} else {
					if (a == 3) {
						base.name = "Demon Blade";
						base.Description = "This blade is fashioned to make the warrior appear \n" + 
							"to be a demon. The pictures on the blades shows a horned demon head";
						base.cost = 20;
						base.isDestroyed = false;
						base.Part = "Weapon";
						base.Type = "Blade";
						CharacterStats temp = new CharacterStats ();
						temp.setCHA (1);
						temp.setCON (0);
						temp.setINT (0);
						temp.setDEX (1);
						temp.setSTR (3);
						temp.setWIS (0);
						base.bonus = temp;
					} else {
						if (a == 5) {
							base.name = "Dragonskin hook";
							base.Description = "This hook is crafted from the hide of a great wyrm dragon.\n" +
								" At the warrior's command, the hook sprouts enormous dragon wings, \n" +
									"giving warrior more mobility .";
							base.cost = 60;
							base.isDestroyed = false;
							base.Part = "Weapon";
							base.Type = "Hook";
							CharacterStats temp = new CharacterStats ();
							temp.setCHA (0);
							temp.setCON (0);
							temp.setINT (1);
							temp.setDEX (4);
							temp.setSTR (1);
							temp.setWIS (0);
							base.bonus = temp;
						} else {
							if (a == 4) {
								base.name = "Dagger of Luck";
								base.Description = "This dagger gives wearer a  lot of bonuses ";
								base.cost = 40;
								base.isDestroyed = false;
								base.Part = "Weapon";
								base.Type = "Dagger";
								CharacterStats temp = new CharacterStats ();
								temp.setCHA (1);
								temp.setCON (1);
								temp.setINT (1);
								temp.setDEX (1);
								temp.setSTR (0);
								temp.setWIS (1);
								base.bonus = temp;
							}
							
						}
					}
				}
			}
		}}
} 

