using UnityEngine;
using System.Collections;

public class Skill {

	private bool Available;

	private string SkillName;
	private int Rank;
	private string Type;
	private string Description;
	private bool Used;
	//dice
	private int AmountOfDice;
	private int SidesOfDice;
	private string Mod;

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
}
