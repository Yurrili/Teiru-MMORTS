using UnityEngine;
using System.Collections;

public class CharacterClass_Ranger : CharacterClass {

	private int[] Arts;//amount of skills in every lvl of Ranger Arts

	public CharacterClass_Ranger(int CON_)
		:base(1,2,2,0,6+CON_, "Ranger")//6+CON (mod z CON)
	{
		Arts = new int[5];
		Arts [0] = 1;

		for (int i = 1; i < Arts.Length; i++) {
			Arts[i] = 0;	
		}
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
				Arts[base.getLvl()-3]=2;
				Arts[base.getLvl()-2]=1;
			}  else {
				if(base.getLvl () == 8) {
					Arts[4] = 2;
				}
			}


		}
	}
}
