using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

	static private PlayersCharacter a;

	static private GameObject[] RanksButtons;

	static private CharacterClass ActiveCharacter = new CharacterClass_Ranger(8);

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
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	static public void DoSth(){
		a = MenuManager._Character_;
		setData ();
		ShowonRankButtons ();
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
		GameObject.Find ("LevelText").GetComponentInChildren<Text> ().text = a.Class_.getLvl ()+"";
	}


	static public void ShowonRankButtons(){
		
		Rank2But.SetActive (false);
		Rank3But.SetActive (false);
		Rank4But.SetActive (false);
		Rank5But.SetActive (false);

	}


}
