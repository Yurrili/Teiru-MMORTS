using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ShowACharacter : MonoBehaviour {

	static public Text SpellButton1;
	static public Text SpellButton2;
	static public Text SpellButton3;
	static public Text SpellButton4;
	static public Text SpellButton5;

	static public GameObject Rank1But;
	static public GameObject Rank2But;
	static public GameObject Rank3But;
	static public GameObject Rank4But;
	static public GameObject Rank5But;
	static public GameObject helmets;
<<<<<<< HEAD
	static public PlayersCharacter a;
=======
>>>>>>> Boniedzialaloboktosmicommitowal

	static public PlayersCharacter a;

	private static Sprite[] sprites;


	// Use this for initialization
	void Start () {
		SpellButton1 = GameObject.Find ("Spell1").GetComponentInChildren<Text>();
		SpellButton2 = GameObject.Find ("Spell2").GetComponentInChildren<Text>();
		SpellButton3 = GameObject.Find ("Spell3").GetComponentInChildren<Text>();
		SpellButton4 = GameObject.Find ("Spell4").GetComponentInChildren<Text>();
		SpellButton5 = GameObject.Find ("Spell5").GetComponentInChildren<Text>();
		Rank1But = GameObject.Find ("Rank1");
		Rank2But = GameObject.Find ("Rank2");
		Rank3But = GameObject.Find ("Rank3");
		Rank4But = GameObject.Find ("Rank4");
		Rank5But = GameObject.Find ("Rank5");

		helmets = GameObject.Find ("HelmToggleGroup");
		sprites = Resources.LoadAll<Sprite>("avatars"); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	static public void DoSth(){
		a = MenuManager._Character_;
		setData ();
		ShowonRankButtons ();
		ShowEqu ();

		ChangeAvatar ();
		SetSkill ();
			
	}

	static public void SetSkill(){
		Skill[] d = a.Class_.AvaibleSkills.ToArray ();

		try
		{
			SpellButton1.text = d [0].getSkillName ();
		}
		catch (Exception e){
			SpellButton1.text = "";
		}
		SpellButton2.text = "";
		SpellButton3.text = "";
		SpellButton4.text = "";
		SpellButton5.text = "";
	}

	static public void ChangeAvatar(){
		char d = a.Avatar.ToCharArray () [2];
		int number = int.Parse(d+"");

		GameObject.Find ("A1").GetComponent<Image> ().sprite = sprites[number];
	}

	static public void setData(){
		GameObject.Find ("STRStats").GetComponentInChildren<Text>().text = a.Statistics.getSTR()+"";
		GameObject.Find ("DEXStats").GetComponentInChildren<Text>().text = a.Statistics.getDEX ()+"";
		GameObject.Find ("CONStats").GetComponentInChildren<Text>().text = a.Statistics.getCON()+"";
		GameObject.Find ("INTStats").GetComponentInChildren<Text>().text = a.Statistics.getINT()+"";
		GameObject.Find ("WISStats").GetComponentInChildren<Text>().text = a.Statistics.getWIS()+"";
		GameObject.Find ("CHAStats").GetComponentInChildren<Text>().text = a.Statistics.getCHA()+"";
		GameObject.Find ("NameText").GetComponentInChildren<Text> ().text = a.DName;
		GameObject.Find ("ClassText").GetComponentInChildren<Text> ().text = a.Class_.getClass ();
		GameObject.Find ("LevelText").GetComponentInChildren<Text> ().text = a.Class_.getLvl()+"";
	}

	static public void ShowEqu(){

		if (a.Equ [0].itemDD != 0) {
			GameObject.Find ("h1").SetActive (false);
		}

		if (a.Equ [0].itemDD != 1) {
			GameObject.Find ("h2").SetActive (false);
		}

		if (a.Equ [0].itemDD != 2) {
			GameObject.Find ("h3").SetActive (false);
		}

		if (a.Equ [0].itemDD != 3) {
			GameObject.Find ("h4").SetActive (false);
		}

		if (a.Equ [0].itemDD != 4) {
			GameObject.Find ("h5").SetActive (false);
		}

		if (a.Equ [0].itemDD != 5) {
			GameObject.Find ("h6").SetActive (false);
		}

		if (a.Equ [1].itemDD != 0) {
			GameObject.Find ("c1").SetActive (false);
		}

		if (a.Equ [1].itemDD != 1) {
			GameObject.Find ("c2").SetActive (false);
		}

		if (a.Equ [1].itemDD != 2) {
			GameObject.Find ("c3").SetActive (false);
		}

		if (a.Equ [1].itemDD != 3) {
			GameObject.Find ("c4").SetActive (false);
		}

		if (a.Equ [1].itemDD != 4) {
			GameObject.Find ("c5").SetActive (false);
		}

		if (a.Equ [1].itemDD != 5) {
			GameObject.Find ("c6").SetActive (false);
		}

		if (a.Equ [2].itemDD != 0) {
			GameObject.Find ("b1").SetActive (false);
		}

		if (a.Equ [2].itemDD != 1) {
			GameObject.Find ("b2").SetActive (false);
		}
		
		if (a.Equ [2].itemDD != 2) {
			GameObject.Find ("b3").SetActive (false);
		}

		if (a.Equ [2].itemDD != 3) {
			GameObject.Find ("b4").SetActive (false);
		}

		if (a.Equ [2].itemDD != 4) {
			GameObject.Find ("b5").SetActive (false);
		}

		if (a.Equ [2].itemDD != 5) {
			GameObject.Find ("b6").SetActive (false);
		}

		if (a.Equ [3].itemDD != 0) {
			GameObject.Find ("w1").SetActive (false);
		}

		if (a.Equ [3].itemDD != 1) {
			GameObject.Find ("w2").SetActive (false);
		}

		if (a.Equ [3].itemDD != 2) {
			GameObject.Find ("w3").SetActive (false);
		}

		if (a.Equ [3].itemDD != 3) {
			GameObject.Find ("w4").SetActive (false);
		}

		if (a.Equ [3].itemDD != 4) {
			GameObject.Find ("w5").SetActive (false);
		}

		if (a.Equ [3].itemDD != 5) {
			GameObject.Find ("w6").SetActive (false);
		}
	}


	static public void ShowonRankButtons(){
		
		Rank2But.GetComponent<Button> ().interactable = false;
		Rank3But.GetComponent<Button> ().interactable = false;
		Rank4But.GetComponent<Button> ().interactable = false;
		Rank5But.GetComponent<Button> ().interactable = false;

	}


}
