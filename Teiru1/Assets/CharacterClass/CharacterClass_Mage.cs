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
	

	public void CreateSkillList(){
		
		base.setSkillListEle(0,0, new Skill ("E Elements", 1, "standard", "standard action, Resistance 5 ( + 5 HP ) to all elements \n until absorbed 5 dmg or encounter ends)", 0, 0, ""));
		base.setSkillListEle(0,1, new Skill ("Wd's Blessing", 1, "buff", " swift, you gain extra round ", 0, 0, ""));
		base.setSkillListEle(0,2, new Skill ("Sner's Shot", 1, "attack", " standard action, one shot from a bow that \nthreatens double damage", 2, 6, ""));
		base.setSkillListEle(0,3, new Skill ("Blades ents", 1, "attack", " swift, melee weapons deal +1d6 fire or acid \n damage until next round ", 1, 6, ""));
		base.setSkillListEle(0,4,  null);
		base.setSkillListEle(1,2, new Skill ("E", 1, "standard", "standard action, Resistance 5 ( + 5 HP ) to all elements \n until absorbed 5 dmg or encounter ends)", 0, 0, ""));
		base.setSkillListEle(2,1, new Skill ("F", 1, "buff", " swift, you gain extra round ", 0, 0, ""));
	}
}
