using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowACharacter : MonoBehaviour {

	public Text SpellButton1;
	public Text SpellButton2;
	public Text SpellButton3;
	public Text SpellButton4;
	public Text SpellButton5;

	public GameObject Rank1But;
	public GameObject Rank2But;
	public GameObject Rank3But;
	public GameObject Rank4But;
	public GameObject Rank5But;

	private GameObject[] RanksButtons;

	private CharacterClass ActiveCharacter = new CharacterClass_Ranger(8);

	// Use this for initialization
	void Start () {
		SpellButton1.text = "";
		SpellButton2.text = "a";
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void setData(){
		GameObject.Find ("STRStats").GetComponentInChildren<Text>() = ActiveCharacter;
		GameObject.Find ("DEXStats").GetComponentInChildren<Text>();
		GameObject.Find ("CONStats").GetComponentInChildren<Text>();
		GameObject.Find ("INTStats").GetComponentInChildren<Text>();
		GameObject.Find ("WISStats").GetComponentInChildren<Text>();
		GameObject.Find ("CHAStats").GetComponentInChildren<Text>();
	}

	private void setDesactivatedRanksButton(int a){

	}

	public void ShowonRankButtons(){
		
		Rank2But.SetActive (false);
		Rank3But.SetActive (false);
		Rank4But.SetActive (false);
		Rank5But.SetActive (false);

	}


}
