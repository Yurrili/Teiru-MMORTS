using UnityEngine;
using System.Collections;

public class CharacterClass_Ranger : CharacterClass {

	public CharacterClass_Ranger(int CON_)
		:base(1,2,2,0,6+CON_, "Ranger")//6+CON modyficator z CON
	{

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
		}
	}
}
