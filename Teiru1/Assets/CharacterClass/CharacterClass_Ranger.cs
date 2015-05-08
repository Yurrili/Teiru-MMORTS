using UnityEngine;
using System.Collections;

public class CharacterClass_Ranger : CharacterClass {



	public CharacterClass_Ranger(int CON_)
		:base(1,2,2,0,6+CON_, "Ranger")//6+CON (mod z CON)
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
				base.increaseWILL();
			} else {
				base.increaseBAB();
			}
			//Ranger Arts increasing
			if(base.getLvl() == 3 || base.getLvl()==5 || base.getLvl ()==7 ){
				base.setArts(base.getLvl()-3,2);
				base.setArts(base.getLvl()-2,1);
			}  else {
				if(base.getLvl () == 8) {
					base.setArts(4, 2);
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
		
		base.setSkillListEle(0,0, new Skill ("Endure Elements", 1, "standard", "standard action, Resistance 5 ( + 5 HP ) to all elements \n until absorbed 5 dmg or encounter ends)", 5, 0, "HP"));
		base.setSkillListEle(0,1, new Skill ("Wind's Blessing", 1, "buff", " swift, you gain extra round ", 0, 0, ""));
		base.setSkillListEle(0,2, new Skill ("Sniper's Shot", 1, "attack", " standard action, one shot from a bow that \nthreatens double damage", 2, 6, ""));
		base.setSkillListEle(0,3, new Skill ("Blades of Elements", 1, "attack", " swift, melee weapons deal +1d6 fire or acid \n damage until next round ", 1, 6, ""));

		base.setSkillListEle(1,0, new Skill ("Magebane Shot",2,"attack","standard action, ranged,\n +1d4/on going spell \n effect on the target if hit",1,4,""));
		base.setSkillListEle(1,1, new Skill ("Predatory Sense",2,"attack","swift action, +1d6 attack/3 Ranger \nlevels for a round", 1,6,""));
		base.setSkillListEle(1,2, new Skill ("Cat’s Grace",2, "buff", "standard action, \nSubject gains +4 to Dex for 10 rounds. ", 1,4, "DEX"));

		base.setSkillListEle(2,0, new Skill ("Blackflame Shot",3, "attack", "Standard, a shot with +2d6 fire damage.", 2, 6, ""));
		base.setSkillListEle(2,1, new Skill ("Sniper's Shot, Greater",3, "attack", "standard action, one shot from a bow that threatens triple damage", 3, 6, ""));
		base.setSkillListEle(2,2, new Skill ("Bounding Assault",3,"attack","full-round, move in a straight line+meleeattack all enemies adjacent at any point of the move", 1,4,""));

		base.setSkillListEle(3,0, new Skill ("Arrowstorm",4, "multi-attack", "Full-round, a ranged attack vs every enemy in 40ft", 1, 6, ""));
		base.setSkillListEle(3,1, new Skill ("Bladestorm",4, "multi-attack", "Full-round, a melee attack vs every enemy in 40ft", 1, 6, ""));
		base.setSkillListEle(3,2, new Skill ("Swift Strikes",4, "buff", "swift, gain an additional attack/weapon in a full attack", 1, 6, ""));
	}

}
