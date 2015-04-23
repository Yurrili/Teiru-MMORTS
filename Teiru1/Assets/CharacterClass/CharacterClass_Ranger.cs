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


	public void CreateSkillList(){
		
		base.setSkillListEle(0,0, new Skill ("E Elements", 1, "standard", "standard action, Resistance 5 ( + 5 HP ) to all elements \n until absorbed 5 dmg or encounter ends)", 0, 0, ""));
		base.setSkillListEle(0,1, new Skill ("Wd's Blessing", 1, "buff", " swift, you gain extra round ", 0, 0, ""));
		base.setSkillListEle(0,2, new Skill ("Sner's Shot", 1, "attack", " standard action, one shot from a bow that \nthreatens double damage", 2, 6, ""));
		base.setSkillListEle(0,3, new Skill ("Blades ents", 1, "attack", " swift, melee weapons deal +1d6 fire or acid \n damage until next round ", 1, 6, ""));
		base.setSkillListEle(0,4,  null);
		base.setSkillListEle(0,5, new Skill ("E Elements", 1, "standard", "standard action, Resistance 5 ( + 5 HP ) to all elements \n until absorbed 5 dmg or encounter ends)", 0, 0, ""));
		base.setSkillListEle(2,1, new Skill ("Wd's Blessing", 1, "buff", " swift, you gain extra round ", 0, 0, ""));
	}

}
