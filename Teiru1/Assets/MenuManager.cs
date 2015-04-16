using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour {

	public Menu CurrentMenu;
	public int pointsToGive = 32;
	GameObject obj;
	GameObject obj1;
	public Text STR;
	public Text DEX;
	public Text CON;
	public Text INT;
	public Text WIS;
	public Text CHA;
	public Text PTS;//summary points
	public Text Name;
	public CharacterStats stats;

	public void Start()
	{
		ShowMenu (CurrentMenu);
		obj = GameObject.FindGameObjectWithTag ("Back");
		obj.SetActive (false);

		stats = new CharacterStats ();
		PTS.text = stats.getPTS().ToString();
		STR.text = stats.getSTR().ToString();
		CHA.text = stats.getCHA().ToString();
		INT.text = stats.getINT().ToString();
		DEX.text = stats.getDEX().ToString();
		WIS.text = stats.getWIS().ToString();
		CON.text = stats.getCON().ToString();
		ChangeInputFieldText("None");
	}

	public void Update()
	{
		/*if (CurrentMenu.name == "SelectMenu") {
			Check (STR);	
			Check (DEX);	
			Check (CON);	
			Check (INT);	
			Check (WIS);	
			Check (CHA);
			PTS.text = pointsToGive.ToString();
		}*/
	}

	public void IncreaseSTR(){

		STR.text = stats.increaseSTR().ToString();
		PTS.text = stats.getPTS().ToString();
	}

	public void IncreaseCHA(){
		
		CHA.text = stats.increaseCHA().ToString();
		PTS.text = stats.getPTS().ToString();
	}

	public void IncreaseINT(){
		
		INT.text = stats.increaseINT().ToString();
		PTS.text = stats.getPTS().ToString();
	}

	public void IncreaseDEX(){
		
		DEX.text = stats.increaseDEX().ToString();
		PTS.text = stats.getPTS().ToString();
	}

	public void IncreaseWIS(){
		
		WIS.text = stats.increaseWIS().ToString();
		PTS.text = stats.getPTS().ToString();
	}

	public void IncreaseCON(){
		
		CON.text = stats.increaseCON().ToString();
		PTS.text = stats.getPTS().ToString();
	}

	public void DecreaseSTR(){
		
		STR.text = stats.decreaseSTR().ToString();
		PTS.text = stats.getPTS().ToString();
	}

	public void DecreaseDEX(){
		
		DEX.text = stats.decreaseDEX().ToString();
		PTS.text = stats.getPTS().ToString();
	}

	public void DecreaseWIS(){
		
		WIS.text = stats.decreaseWIS().ToString();
		PTS.text = stats.getPTS().ToString();
	}

	public void DecreaseCON(){
		
		CON.text = stats.decreaseCON().ToString();
		PTS.text = stats.getPTS().ToString();
	}

	public void DecreaseCHA(){
		
		CHA.text = stats.decreaseCHA().ToString();
		PTS.text = stats.getPTS ().ToString ();
	}

	public void DecreaseInt(){
		
		INT.text = stats.decreaseINT().ToString();
		PTS.text = stats.getPTS().ToString();
	}

	public bool Check()
	{
		if (stats.getPTS () > 0) {
			return false;
		}

		Text NAME = GameObject.Find ("NameText").GetComponentInChildren<Text>();


		return true;
		
	}

	public void ShowMenu(Menu menu)
	{

			if (CurrentMenu != null)
				CurrentMenu.isOpen = false;

			CurrentMenu = menu;
			CurrentMenu.isOpen = true;

	}

	public void OnMouseDown()
	{
		if (obj)
			obj.SetActive (false);
		
	}

	public void OnMouseDown1()
	{
		if (obj)
			obj.SetActive (true);
		
	}

	public void OnMouseDownLog()// Registration button hide
	{
		obj1 = GameObject.FindGameObjectWithTag ("Registration");
		if (obj1)
			obj1.SetActive (false);
		
	}
	
	public void OnMouseDownLOg1()
	{
		if (obj1)
			obj1.SetActive (true);
		
	}

	public void PushedB()
	{
		ChangeInputFieldText ("Ranger");
	}

	public void PushedF()
	{
		ChangeInputFieldText ("Mage");
	}

	public void PushedR()
	{
		ChangeInputFieldText ("Knight");
	}

	public void PushedW()
	{
		ChangeInputFieldText ("Mystic");
	}

	void ChangeInputFieldText(string IFname){
		
		Text BAB = GameObject.Find ("BABText").GetComponentInChildren<Text>();
		Text FORT = GameObject.Find ("FORTText").GetComponentInChildren<Text>();
		Text REF = GameObject.Find ("REFText").GetComponentInChildren<Text>();
		Text WILL = GameObject.Find ("WILLText").GetComponentInChildren<Text>();
		//if(textscript == null){Debug.LogError("Script not found");return;}
		switch (IFname)
		{
		case "None":
			BAB.text = "0";
			FORT.text = "0";
			REF.text = "0";
			WILL.text = "0";
			break;
		case "Ranger":
			BAB.text = "1";
			FORT.text = "2";
			REF.text = "2";
			WILL.text = "0";
			break;
		case "Mage":
			BAB.text = "1";
			FORT.text = "2";
			REF.text = "2";
			WILL.text = "0";
			break;
		case "Knight":
			BAB.text = "1";
			FORT.text = "2";
			REF.text = "0";
			WILL.text = "1";
			break;
		case "Mystic":
			BAB.text = "0";
			FORT.text = "2";
			REF.text = "0";
			WILL.text = "2";
			break;
		default: 
			BAB.text = "0";
			FORT.text = "0";
			REF.text = "0";
			WILL.text = "0";
			break;
		}
	}

	

	
}

