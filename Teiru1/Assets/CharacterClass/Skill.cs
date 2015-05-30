using UnityEngine;
using System.Collections;

public class Skill {

	public bool Available;

	public string SkillName;
	public int Rank;
	public string Type;
	public string Description;
	public bool Used;

	//dice
	public int AmountOfDice;
	public int SidesOfDice;
	public string Mod;

	public Skill(){
	}

	public Skill(string SkillName, int Rank, string Type, string Description, int AmountOfDice, int SidesOfDice, string Mod){
		this.AmountOfDice = AmountOfDice;
		this.Available = false;
		this.Description = Description;
		this.Rank = Rank;
		Used = false;
		this.SkillName = SkillName;
		this.SidesOfDice = SidesOfDice;
		this.Type = Type;
		this.Mod = Mod;
	}

	public string getSkillName(){
		return SkillName;
	}

	public string getDescription(){
		return Description;
	}

	public int getAmountOfDice(){
		return AmountOfDice;
	}

	public int getSidesOfDice(){
		return SidesOfDice;
	}

	public string getMod(){
		return this.Mod;
	}
}
