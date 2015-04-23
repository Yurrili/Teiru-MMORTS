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



	public void CreateSkillList(){
		
		base.setSkillListEle(0,0, new Skill ("E Elements", 1, "standard", "standard action, Resistance 5 ( + 5 HP ) to all elements \n until absorbed 5 dmg or encounter ends)", 0, 0, ""));
		base.setSkillListEle(0,1, new Skill ("Wd's Blessing", 1, "buff", " swift, you gain extra round ", 0, 0, ""));
		base.setSkillListEle(0,2, new Skill ("Sner's Shot", 1, "attack", " standard action, one shot from a bow that \nthreatens double damage", 2, 6, ""));
		base.setSkillListEle(0,3, new Skill ("Blades ents", 1, "attack", " swift, melee weapons deal +1d6 fire or acid \n damage until next round ", 1, 6, ""));
	    base.setSkillListEle(0,4,  null);
	}
}
