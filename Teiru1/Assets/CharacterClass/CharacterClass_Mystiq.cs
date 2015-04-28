using UnityEngine;
using System.Collections;

public class CharacterClass_Mystiq : CharacterClass {
	

	public CharacterClass_Mystiq(int CON_)
		:base(0,2,0,2,6+CON_, "Mage")//6+CON modyficator z CON
	{

		CreateSkillList ();
	}
	
	public void LVLup(){
		
		if(base.getLvl() < 8)
		{
			base.increaseLvl();
			if (base.getLvl() % 2 == 0) {
				base.increaseBAB();
				base.increaseFORT();
				base.increaseWILL();
			} else {
				base.increaseBAB();
			}
			
			if(base.getLvl() == 3 || base.getLvl() == 6){
				base.increaseREF();
			}

			//Mystiq Arts increasing
			if(base.getLvl() == 3 || base.getLvl() == 5 || base.getLvl () == 7 ){
				base.setArts(base.getLvl()-3,2);
				base.setArts(base.getLvl()-2,1);
				
				if( base.getLvl() == 5 || base.getLvl () == 7 ) {
					base.setArts(0, base.getArts(0) + 1);
				}
				
			}  else {
				if(base.getLvl() == 8) {
					base.setArts(4, 2);
					base.setArts(5, 1);
				}
			}
		}
	}



	public void CreateSkillList(){
		
		
		base.setSkillListEle(0,0, new Skill ("Cure Light Wounds", 1, "heal", "When laying your hand upon a living creature,you channel positive energy that cures 1d8 points of damage +1 point per caster level(maximum +5).", 1, 8, ""));
		base.setSkillListEle(0,1, new Skill ("Shield of Faith", 1, "buff", " standard action, An invisible but tangible field \nof force surrounds the subject of a mage armor spell, \nproviding a +4 armor bonus to AC(KP).", 1, 4, "AC"));
		base.setSkillListEle(0,2, new Skill ("Chilly Touch", 1, "attack", " standard actiob, Each touch channels \nnegative energy that deals 1d6 points of damage.", 1, 6, ""));
		base.setSkillListEle(0,3, new Skill ("Produce Flame", 1, "attack", "standard, You can strike an opponent \nwith a melee touch attack, dealing fire damage equal to d6 +1 point per\n caster level (maximum +5). ", 1, 6, ""));
		
		base.setSkillListEle(1,0, new Skill ("Aid",2,"heal","grants the target a +1 morale bonus on attack rolls and saves \nagainst fear effects, plus temporary hit points equal to 1d8 + caster level .\n(standard)",1,8,"HP"));
		base.setSkillListEle(1,1, new Skill ("Bear's Endurance",2,"buff","Swift, allies gain a +4 to all \ntheir will saves made before next round.", 0,0,"WILL"));
		base.setSkillListEle(1,2, new Skill ("Owl's Wisdom",2, "buff", "The transmuted creature becomes wiser. \nThespell grants a +4 enhancement bonus to Wisdom, \nadding the usual benefit toWisdom-related skills. (standard)", 1 ,4, "WIS"));
		base.setSkillListEle(1,3, new Skill ("Cat’s Grace",2, "buff", "standard action, \nSubject gains +4 to Dex for 10 rounds. ", 1,4, "DEX"));
		base.setSkillListEle(1,4, new Skill ("Shield Other",2, "buff", "The subject gains a +1 deflection bonus to AC and\n a +1 resistance bonus on saves.(Standard)", 1, 6, "AC"));

		base.setSkillListEle(2,0, new Skill ("Cure Serious Wounds",3, "buff", "When laying your hand upon a living creature, \nyou channel positive energy that cures 3d8 points of damage +1 point per caster level (maximum +15). \n(standard)", 3, 8, "HP"));
		base.setSkillListEle(2,1, new Skill ("Phalanx Defense",3,"buff","move action, Move to an ally and grant them \na +3 bonus to saves and AC.", 1,3,"AC"));
		base.setSkillListEle(2,2, new Skill ("Protection",3, "buff", "When the spell gives 12 points per caster \nlevel of additional HP . (standard)", 1, 20, "HP"));

		base.setSkillListEle(3,0, new Skill ("Cure Critical Wounds",4, "heal", "When laying your hand upon a living creature,you channel positive energy that cures 4d8points of damage +1 point per caster level (maximum +20).(standard)", 4, 20, "HP"));
		base.setSkillListEle(3,1, new Skill ("Ice Storm",4,"attack","standard action, Great magical hailstones pound down for 1 full round,\n dealing 3d6 points of bludgeoning damage and 2d6 points of cold damage\n to every creature in the area.", 5,6,""));
		base.setSkillListEle(3,2, new Skill ("Wall of Fire",4,"attack","standard action, \nDealing 2d4 points of fire damage to creature under wall.", 2,4,""));

		base.setSkillListEle(4,0, new Skill ("Raise Dead",5, "heal", "You restore life to a deceased creature. You can raise a creature that has been dead for no longer than one tour per caster level. In addition, the subject’s soul must be free and willing to return. If the subject’s soul is not willing to return, the spell does not work; ", 4, 20, "HP"));
		base.setSkillListEle(4,1, new Skill ("Cone of Cold",5, "attack", "standard, \nIt drains heat, dealing 1d6 points ofcold damage per caster level\n (maximum 15d6).", base.getLvl(), 6, ""));

	}
}
