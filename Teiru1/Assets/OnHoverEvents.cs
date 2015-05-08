using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class OnHoverEvents : MonoBehaviour {


	CharacterClass classCha;
	Text text;
	// Use this for initialization
	void Start () 
	{

		text = GameObject.Find ("AboutSkill").GetComponentInChildren<Text>();
	}

	private void classchoose(string a){

		switch(a)
		{
		case "Ranger":
			classCha = new CharacterClass_Ranger(0);

			//print ("Ranger");
			break;
		case "Mage":
			classCha = new CharacterClass_Mage(0);

			//print ("Mage");
			break;
		case "Knight":
			classCha = new CharacterClass_Knight(0);

		//	print ("Knight");
			break;
		case "Mystic":
			classCha = new CharacterClass_Mystiq(0);

		//	print ("Mystic");
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		classchoose(GameObject.Find ("ClassTextPlace").GetComponent<Text>().text);
	}

	public void onToggle11IsEntered()
	{
		text.text = classCha.getSkillDescription (0, 0);
	}

	public void onToggle12IsEntered()
	{
		text.text = classCha.getSkillDescription (0, 1);
	}

	public void onToggle13IsEntered()
	{
		text.text = classCha.getSkillDescription (0, 2);
	}

	public void onToggle14IsEntered()
	{
		text.text = classCha.getSkillDescription (0, 3);
	}

	public void onToggle15IsEntered()
	{
		text.text = classCha.getSkillDescription (0, 4);
	}

	//2

	
	public void onToggle21IsEntered()
	{
		text.text = classCha.getSkillDescription (1, 0);
	}
	
	public void onToggle22IsEntered()
	{
		text.text = classCha.getSkillDescription (1, 1);
	}
	
	public void onToggle23IsEntered()
	{
		text.text = classCha.getSkillDescription (1, 2);
	}
	
	public void onToggle24IsEntered()
	{
		text.text = classCha.getSkillDescription (1, 3);
	}
	
	public void onToggle25IsEntered()
	{
		text.text = classCha.getSkillDescription (1, 4);
	}

	//3

	
	public void onToggle31IsEntered()
	{
		text.text = classCha.getSkillDescription (2, 0);
	}
	
	public void onToggle32IsEntered()
	{
		text.text = classCha.getSkillDescription (2, 1);
	}
	
	public void onToggle33IsEntered()
	{
		text.text = classCha.getSkillDescription (2, 2);
	}
	
	public void onToggle34IsEntered()
	{
		text.text = classCha.getSkillDescription (2, 3);
	}
	
	public void onToggle35IsEntered()
	{
		text.text = classCha.getSkillDescription (2, 4);
	}

	//4

	
	public void onToggle41IsEntered()
	{
		text.text = classCha.getSkillDescription (3, 0);
	}
	
	public void onToggle42IsEntered()
	{
		text.text = classCha.getSkillDescription (3, 1);
	}
	
	public void onToggle43IsEntered()
	{
		text.text = classCha.getSkillDescription (3, 2);
	}
	
	public void onToggle44IsEntered()
	{
		text.text = classCha.getSkillDescription (3, 3);
	}
	
	public void onToggle45IsEntered()
	{
		text.text = classCha.getSkillDescription (3, 4);
	}

	//5

	
	public void onToggle51IsEntered()
	{
		text.text = classCha.getSkillDescription (4, 0);
	}
	
	public void onToggle52IsEntered()
	{
		text.text = classCha.getSkillDescription (4, 1);
	}
	
	public void onToggle53IsEntered()
	{
		text.text = classCha.getSkillDescription (4, 2);
	}
	
	public void onToggle54IsEntered()
	{
		text.text = classCha.getSkillDescription (4, 3);
	}
	
	public void onToggle55IsEntered()
	{
		text.text = classCha.getSkillDescription (4, 4);
	}
}
