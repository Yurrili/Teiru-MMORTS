using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class OnHoverEventsBitch : MonoBehaviour {


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

			print ("Ranger");
			break;
		case "Mage":
			classCha = new CharacterClass_Mage(0);

			print ("Mage");
			break;
		case "Knight":
			classCha = new CharacterClass_Knight(0);

			print ("Knight");
			break;
		case "Mystic":
			classCha = new CharacterClass_Mystiq(0);

			print ("Mystic");
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
}
