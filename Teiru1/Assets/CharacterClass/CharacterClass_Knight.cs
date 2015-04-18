using UnityEngine;
using System.Collections;

public class CharacterClass_Knight : CharacterClass {

	private int[] Arts;//amount of skills in every lvl of Ranger Arts

	public CharacterClass_Knight(int CON_)
		:base(1,2,0,2,10+CON_, "Mage")//6+CON modyficator z CON
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
				base.increaseWILL();
			} else {
				base.increaseBAB();
			}
			
			if(base.getLvl() == 3 || base.getLvl() == 6){
				base.increaseREF();
			}

			//Knight Arts increasing
			if(base.getLvl() == 3 || base.getLvl() == 5 || base.getLvl () == 7 ){
				Arts[base.getLvl()-3]=2;
				Arts[base.getLvl()-2]=1;

				if( base.getLvl() == 5 ) {
					Arts[0] = 3;
				}

			}  else {
				if(base.getLvl () == 8) {
					Arts[4] = 2;
				}
			}
		}
	}
}
