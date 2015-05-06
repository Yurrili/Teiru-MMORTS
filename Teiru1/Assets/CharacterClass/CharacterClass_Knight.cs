using UnityEngine;
using System.Collections;

public class CharacterClass_Knight : CharacterClass {



	public CharacterClass_Knight(int CON_)
		:base(1,2,0,2,10+CON_, "Mage")//6+CON modyficator z CON
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

			//Knight Arts increasing
			if(base.getLvl() == 3 || base.getLvl() == 5 || base.getLvl () == 7 ){
				base.setArts(base.getLvl()-3,2);
				base.setArts(base.getLvl()-2,1);

				if( base.getLvl() == 5 ) {
					base.setArts(0 ,3);
				}

			}  else {
				if(base.getLvl () == 8) {
					base.setArts(4 ,2);
				}
			}
		}
	}

	
	public void setLvl(int a) {

		for( base.getLvl(); base.getLvl() < a; LVLup() );
	}



	public void CreateSkillList(){
		
		base.setSkillListEle(0,0, new Skill ("Leading Strike", 1, "buff", "sStandard, Melee attack. \nIf hits, all allies get +4 to hit against\n that enemy until next round.", 0, 0, "ALL"));
		base.setSkillListEle(0,1, new Skill ("Mage Armor", 1, "buff", " standard action, An invisible but tangible field \nof force surrounds the subject of a mage armor spell, \nproviding a +4 armor bonus to AC(KP).", 1, 4, "AC"));
		base.setSkillListEle(0,2, new Skill ("Chill Touch", 1, "attack", " standard actiob, Each touch channels \nnegative energy that deals 1d6 points of damage.", 1, 6, ""));
		base.setSkillListEle(0,3, new Skill ("Rooting Strike", 1, "attack", "standard, single melee attack,\n +1d6 points of damage. ", 1, 6, ""));

		base.setSkillListEle(1,0, new Skill ("Devastating Strike",2,"attack","standard make a single melee attack. \nThis attack deals an extra 2d6 points of damage and automatically overcomes \ndamage reduction and hardness.",2,6,""));
		base.setSkillListEle(1,1, new Skill ("Encouraging Shout",2,"buff","Swift, allies gain a +4 to all \ntheir will saves made before next round.", 0,0,"WILL"));
		base.setSkillListEle(1,2, new Skill ("Vanguard Charg",2, "attack", "full-round , charge, deal additional damage equal to 2x character level.", base.getLvl(),6, ""));

		base.setSkillListEle(2,0, new Skill ("Find the Weakness",3, "attack", "standard, Attack, deal a +3d6 damage. \nAll allied attacks deal an additional 2d6 damage \nagainst that enemy.", 5, 6, ""));
		base.setSkillListEle(2,1, new Skill ("Slow",3, "buff", "standard action, duration : 1 round/level. \nAn affected creature moves and attacks at a drastically slowed rate. \nA slowed creature can take only a single move action \nor standard action each turn, but not both (nor may it take full-round actions).\n Additionally, it takes a -1 penalty on attack rolls,\n AC, and Reflex saves.", 0, 0, ""));
		base.setSkillListEle(2,2, new Skill ("Phalanx Defense",3,"buff","move action, Move to an ally and grant them \na +3 bonus to saves and AC.", 1,3,"AC"));
	
		base.setSkillListEle(3,0, new Skill ("Greater Tactical Movement",4, "buff", "move action, An ally gains a full-round", 0, 0, ""));
		base.setSkillListEle(3,1, new Skill ("Disorienting strike",4, "attack", "standard, single melee attack. \nIf it hits, you deal an extra 4d6 points of damage.", 4, 6, ""));
	
		base.setSkillListEle(4,0, new Skill ("Bulwark of Defense",4, "buff", "full-round, Do nothing, but halve the damage any ally takes during the round, as well as gain a +10 HP.", 0, 10, "HP"));

	}
}
