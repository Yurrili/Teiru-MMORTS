using UnityEngine;
using System.Collections;

public class Chest : Item {



	public Chest(int a)
	{
		base.itemDD = a;
		if (a == 0) {
						base.name = "Armor of the Celestial Battalion";
						base.Description = "This chainmail is so fine and light that it can be \n " +
											"worn under normal clothing without revealing its presence.\n";							;
						base.cost = 20;
						base.isDestroyed = false;
						base.Part = "Chest";
						base.Type = "Light armor";
						CharacterStats temp = new CharacterStats ();
						temp.setCHA (0);
						temp.setCON (1);
						temp.setINT (0);
						temp.setDEX (3);
						temp.setSTR (0);
						temp.setWIS (0);
						base.bonus = temp;
				} else {
						if (a == 1) {
								base.name = "Elven Chain";
								base.Description = "This extremely light chainmail is made of very fine mithral links. \n " +
										"It has a maximum Dexterity bonus of +3 and Inteligent bonus +2 .";
								base.cost = 40;
								base.isDestroyed = false;
								base.Part = "Chest";
								base.Type = "Light armor";
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
										base.name = "Warlord’s Breastplate";
					base.Description = "This mithral breastplate allows the wearer \nto attract and lead a number of followers \n" +
										"as if he or she had the Leadership feat .";
												 
										base.cost = 60;
										base.isDestroyed = false;
										base.Part = "Chest";
										base.Type = "Light armor";
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
												base.name = "Demon Armor";
												base.Description = "This plate armor is fashioned to make the wearer appear \n" + 
														"to be a demon. The picture on the chest is shaped to look like a horned demon head," + 
														" and its wearer looks out of the open, tooth-filled mouth." + 
														"gives a wearer a enhancted bonus +2 to strengh and + 1 to condition";
												base.cost = 20;
												base.isDestroyed = false;
												base.Part = "Chest";
												base.Type = "Heavy armor";
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
														base.name = "Dragonskin Armor";
														base.Description = "This full plate armor is crafted from the hide of a great wyrm dragon.\n" +
																" At the wearer’s command, the armor sprouts enormous dragon wings, \n" +
																"allowing the wearer to fly . The armor also grants immunity to a specific type of energy,\n" +
																" based on the color of dragon that supplied the armor.\n Gives wearer a bonus + 4 to strength and +2 to condition and +1 to charisma";
														base.cost = 60;
														base.isDestroyed = false;
														base.Part = "Chest";
														base.Type = "Heavy armor";
														CharacterStats temp = new CharacterStats ();
														temp.setCHA (1);
														temp.setCON (2);
														temp.setINT (0);
														temp.setDEX (0);
														temp.setSTR (4);
														temp.setWIS (0);
														base.bonus = temp;
												} else {
														if (a == 4) {
																base.name = "Banded Mail of Luck";
																base.Description = "Ten 100-gp gems adorn this banded mail. \n " + "Gives wearer a bonus + 3 to strength and +1 to condition ";
																base.cost = 40;
																base.isDestroyed = false;
																base.Part = "Chest";
																base.Type = "Heavy armor";
																CharacterStats temp = new CharacterStats ();
																temp.setCHA (0);
																temp.setCON (1);
																temp.setINT (0);
																temp.setDEX (0);
																temp.setSTR (3);
																temp.setWIS (0);
																base.bonus = temp;
														}
				
												}
										}
								}
						}
				}}
		} 

