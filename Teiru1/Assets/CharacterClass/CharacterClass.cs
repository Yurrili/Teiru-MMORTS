using UnityEngine;
using System.Collections;

public class CharacterClass {

	private int BAB;
	private int FORT;
	private int WILL;
	private int REF;
	private HPValue HP;
	private string className;
	private int lvl;

	public CharacterClass(int BAB, int FORT, int REF, int WILL, int HP, string className){
		this.BAB = BAB;
		this.FORT = FORT;
		this.WILL = WILL;
		this.REF = REF;
		this.HP = new HPValue(HP);
		this.className = className;
		this.lvl = 1;
	}

	protected void increaseBAB(){
		if(BAB<8)
			BAB++;
	}

	protected void increaseFORT(){
		if(FORT<8)
			FORT++;
	}

	protected void increaseWILL(){
		if(WILL<8)
			WILL++;
	}

	protected void increaseREF(){
		if(REF<8)	
			REF++;
	}

	public int getBAB(){
		return BAB;
	}

	public int getWILL(){
		return WILL;
	}

	public int getFORT(){
		return FORT;
	}

	public int getREF(){
		return BAB;
	}

	public string takeDamage(int damage){
		return HP.Hit (damage);
	}

	public int getLvl(){
		return lvl;
	}

	public void increaseLvl(){
		if (lvl < 8) {
			lvl++;
		}
	}

	public string getClass(){
		return className;
	}

}
