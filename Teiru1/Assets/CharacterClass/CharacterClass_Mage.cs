using UnityEngine;
using System.Collections;

public class CharacterClass_Mage : CharacterClass {



	public CharacterClass_Mage(int CON_)
		:base(1,2,2,0,4+CON_, "Mage")//6+CON modyficator z CON
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
				base.increaseREF();
			} else {
				base.increaseBAB();
			}

			if(base.getLvl() == 2 || base.getLvl() == 6){
				base.increaseWILL();
			}

			//Mage Arts increasing
			if(base.getLvl() == 3 || base.getLvl()==5 || base.getLvl ()==7 ){
				base.setArts(1, base.getArts(1) + 1);
				base.setArts(2, 2);
				if( base.getLvl()==5 || base.getLvl ()==7 ){
					base.setArts(3, 2);
					if( base.getLvl () == 7 ) {
						base.setArts(2, 3);
						base.setArts(4, 2);
					}
				}
			}  else {
				if(base.getLvl () == 8) {
					base.setArts(3, 3);
					base.setArts(4, 3);
					base.setArts(5, 1);
				}
			}
		}
	}
	
	
	public void setLvl(int a) {
		for( base.getLvl(); base.getLvl() < a; LVLup() );
	}

	public void setSkill(string name){
		
		for (int i = 0; i < 5; i++) {
			for(int j = 0; j < 5; j++){
				if( base.getSkillListEle(i,j) != null){
					if( base.getSkillListEle(i,j).getSkillName() == name)
					AvaibleSkills.Add (base.getSkillListEle(i,j));
				}
			}
		}
		
	}

	public void CreateSkillList(){
		
		base.setSkillListEle(0,0, new Skill ("Grease", 1, "buff", "standard action, A grease spell covers a solid surface \nwith a layer of slippery grease. \nAny creature in the area when the spell is cast must \nmake a successful Reflex save or fall. \nThis save is repeated on your turn each round \n that the creature remains within the area.", 1, 6, "REF"));
		base.setSkillListEle(0,1, new Skill ("Mage Armor", 1, "buff", " standard action, An invisible but tangible field \nof force surrounds the subject of a mage armor spell, \nproviding a +4 armor bonus to AC(KP).", 1, 4, "AC"));
		base.setSkillListEle(0,2, new Skill ("Chill Touch", 1, "attack", " standard actiob, Each touch channels \nnegative energy that deals 1d6 points of damage.", 1, 6, ""));
		base.setSkillListEle(0,3, new Skill ("Magic Weapon", 1, "attack", "standart action, during time: 10 round/level.\n Magic weapon gives a weapon a +1d4 bonus on attack .", 1, 4, ""));
		base.setSkillListEle(0,4, new Skill ("Cat’s Grace",2, "buff", "standard action, \nSubject gains +4 to Dex for 10 rounds. ", 1,4, "DEX"));

		base.setSkillListEle(1,0, new Skill ("Scorching Ray",2,"attack","sstandart action, range: 25ft, hit and deals 4d6\npoints of fire damage",4,6,""));
		base.setSkillListEle(1,1, new Skill ("Gust of Wind",2,"attack","standart action, duration: 1 round, creatures are unable to move forward against the force of the wind", 0,0,"STUN"));
		base.setSkillListEle(1,2, new Skill ("Acid Arrow",2, "buff", "standard action, A magical arrow of acid \ndeals 2d4 points of acid damage .", 2,4, ""));
		base.setSkillListEle(1,3, new Skill ("Fireball",2, "buff", "standard, area: 20ft, \ndeals 1d6 points of fire damage per caster level (maximum 10d4)\n to every creature within the area.", base.getLvl() ,6, "LVL"));
		
		base.setSkillListEle(2,0, new Skill ("Blackflame Shot",3, "attack", "Standard, a shot with +2d6 fire damage.", 2, 6, ""));
		base.setSkillListEle(2,1, new Skill ("Slow",3, "attack", "standard action, duration : 1 round/level. \nAn affected creature moves and attacks at a drastically slowed rate. \nA slowed creature can take only a single move action \nor standard action each turn, but not both (nor may it take full-round actions).\n Additionally, it takes a -1 penalty on attack rolls,\n AC, and Reflex saves.", 0, 0, ""));
		base.setSkillListEle(2,2, new Skill ("Ice Storm",3,"attack","standard action, Great magical hailstones pound down for 1 full round,\n dealing 3d6 points of bludgeoning damage and 2d6 points of cold damage\n to every creature in the area.", 5,6,""));
		base.setSkillListEle(2,3, new Skill ("Wall of Fire",3,"attack","standard action, \nDealing 2d4 points of fire damage to creature under wall.", 2,4,""));

		base.setSkillListEle(3,0, new Skill ("Stoneskin	",4, "multi-attack", "Full-round, a ranged attack vs every enemy in 40ft", 1, 6, ""));
		base.setSkillListEle(3,1, new Skill ("Cone of Cold",4, "attack", "standard, \nIt drains heat, dealing 1d6 points ofcold damage per caster level\n (maximum 15d6).", base.getLvl(), 6, ""));
		base.setSkillListEle(3,2, new Skill ("Fear",4, "buff", "standard acrion, duration: 1 round/lvl. An invisible cone of terror causes that creature to become panicked unless it succeeds on a Will save. If cornered, a panicked creature begins cowering. If the Will save succeeds, the creature is shaken for 1 round.", 0, 0, "WILL"));

		base.setSkillListEle(4,0, new Skill ("Bestow Curse",4, "buff", "Standard, duration: permament, Each turn, the target has a 50% chance to act normally; otherwise, it takes no action, unless it succeds on a Will save.", 0, 0, "WILL"));
	}
}
