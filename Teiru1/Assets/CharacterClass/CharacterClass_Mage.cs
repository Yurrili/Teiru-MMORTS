using UnityEngine;
using System.Collections;

public class CharacterClass_Mage : CharacterClass {

	private int[] Arts;//amount of skills in every lvl of Ranger Arts

	public CharacterClass_Mage(int CON_)
		:base(1,2,2,0,4+CON_, "Mage")//6+CON modyficator z CON
	{
		Arts = new int[5];
		Arts [0] = 2;
		
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
			} else {
				base.increaseBAB();
			}

			if(base.getLvl() == 2 || base.getLvl() == 6){
				base.increaseWILL();
			}

			//Mage Arts increasing
			if(base.getLvl() == 3 || base.getLvl()==5 || base.getLvl ()==7 ){
				Arts[1] += 1;
				Arts[2] = 2;
				if( base.getLvl()==5 || base.getLvl ()==7 ){
					Arts[3] = 2;
					if( base.getLvl () == 7 ) {
						Arts[2] = 3;
						Arts[4] = 2;
					}
				}
			}  else {
				if(base.getLvl () == 8) {
					Arts[3] = 3;
					Arts[4] = 3;
					Arts[5] = 1;
				}
			}
		}
	}
}
