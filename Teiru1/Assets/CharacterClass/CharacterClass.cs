using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterClass {

	private int BAB;
	private int FORT;
	private int WILL;
	private int REF;
	private HPValue HP;
	private string className;
	private int lvl;

	private int[] Arts;//amount of skills in every lvl of Ranger Arts
	public Skill[,] SkillList;

	public List<Skill> AvaibleSkills = new List<Skill>();

	public CharacterClass(int BAB, int FORT, int REF, int WILL, int HP, string className){
		this.BAB = BAB;
		this.FORT = FORT;
		this.WILL = WILL;
		this.REF = REF;
		this.HP = new HPValue(HP);
		this.className = className;
		this.lvl = 1;

		Arts = new int[5];
		Arts [0] = 1;
		
		for (int i = 1; i < Arts.Length; i++) {
			Arts[i] = 0;	
		}

		SkillList = new Skill[5, 5];
	}

	public string getSkillName(int Rank, int skill){

			if (SkillList [Rank, skill] == null) {
				return "";
			} else {
				return SkillList [Rank, skill].getSkillName ();
			}

	}


	
	public string getSkillDescription(int Rank, int skill){

			return getSkillListEle(Rank ,skill).getDescription();

	}

	public HPValue getHPValue(){
		return HP;
	}

	public int getArts(int a){
				return Arts[a];
	}

	protected void setArts(int a, int b){
		Arts[a] = b;
	}

	protected Skill getSkillListEle(int a, int b){
		return SkillList[a,b];
	}

	protected void setSkillListEle(int a, int b, Skill c){
		SkillList [a,b] = c;
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

	public void takeDamage(int damage){
		HP.Hit (damage);
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

	public void setCurrentHP(int dmg){
		HP.Hit (dmg);
	}


}
