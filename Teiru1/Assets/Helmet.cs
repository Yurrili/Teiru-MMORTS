using UnityEngine;
using System.Collections;

public class Helmet : Item {
	
	public Helmet(int a)
	{
		base.itemDD = a;
		if (a == 0) {
			base.name = "Hat of the Celestial Battalion";
			base.Description = "This hat are so fine and light that they can fly \n " ;
			base.cost = 20;
			base.isDestroyed = false;
			base.Part = "Head";
			base.Type = "Hat";
			CharacterStats temp = new CharacterStats ();
			temp.setCHA (0);
			temp.setCON (0);
			temp.setINT (0);
			temp.setDEX (1);
			temp.setSTR (0);
			temp.setWIS (2);
			base.bonus = temp;
		} else {
			if (a == 1) {
				base.name = "Hat of Elven Wool ";
				base.Description = "This extremely light hat are made of very fine wool. \n " +
					"It has a maximum Dexterity bonus of +3 and Inteligent bonus +2 .";
				base.cost = 40;
				base.isDestroyed = false;
				base.Part = "Head";
				base.Type = "Hat";
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
					base.name = "Warlord’s Hat";
					base.Description = "This mithral leather  allows the wearer \nto attract and lead a number of followers ";
					
					base.cost = 60;
					base.isDestroyed = false;
					base.Part = "Head";
					base.Type = "Hat";
					CharacterStats temp = new CharacterStats ();
					temp.setCHA (3);
					temp.setCON (0);
					temp.setINT (2);
					temp.setDEX (1);
					temp.setSTR (0);
					temp.setWIS (0);
					base.bonus = temp;
				} else {
					if (a == 3) {
						base.name = "Demon Helmet";
						base.Description = "This armor helmet is fashioned to make the wearer appear \n" + 
							"to be a demon. The pictures on the helmet are shaped to look like a horned demon head";
						base.cost = 20;
						base.isDestroyed = false;
						base.Part = "Head";
						base.Type = "Helmet";
						CharacterStats temp = new CharacterStats ();
						temp.setCHA (3);
						temp.setCON (1);
						temp.setINT (0);
						temp.setDEX (0);
						temp.setSTR (0);
						temp.setWIS (0);
						base.bonus = temp;
					} else {
						if (a == 5) {
							base.name = "Dragonskin Helmet";
							base.Description = "This helmet ie crafted from the hide of a great wyrm dragon.\n" +
								" At the wearer’s command, the helmet sprouts enormous dragon wings, \n" +
									"allowing the wearer to fly .";
							base.cost = 60;
							base.isDestroyed = false;
							base.Part = "Head";
							base.Type = "Helmet";
							CharacterStats temp = new CharacterStats ();
							temp.setCHA (1);
							temp.setCON (2);
							temp.setINT (0);
							temp.setDEX (2);
							temp.setSTR (0);
							temp.setWIS (1);
							base.bonus = temp;
						} else {
							if (a == 4) {
								base.name = "Helmet of Luck";
								base.Description = "Ten 100-gp gems adorn this helmet. \n ";
								base.cost = 40;
								base.isDestroyed = false;
								base.Part = "Head";
								base.Type = "Helmet";
								CharacterStats temp = new CharacterStats ();
								temp.setCHA (1);
								temp.setCON (1);
								temp.setINT (1);
								temp.setDEX (2);
								temp.setSTR (1);
								temp.setWIS (1);
								base.bonus = temp;
							}
							
						}
					}
				}
			}
		}}
} 

