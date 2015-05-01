using UnityEngine;
using System.Collections;

public class Item {

	protected string name;
	protected string Description;
	protected string Type;
	protected string Part;
	protected int cost;
	protected CharacterStats bonus;
	protected bool isDestroyed = false;
	public int itemDD;

	public Item(){
		itemDD = 0;
	}

	public string getName(){
		return name;
	}

	public string getType(){
		return Type;
	}

	public int getCost(){
		return cost;
	}

	public CharacterStats getBonus(){
		return bonus;
	}


	public string getCostT(){
		return "Value of this item is " + cost;
	}

	public string getAllDescription(){
		return  "Type of weapon : " + Type + "\n" 
							 + Description + "\n" 
						     + getCostT ()  + "\n" 
							 + bonus.getDescription();
	}

}
