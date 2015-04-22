using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MenuManager : MonoBehaviour {

	public static Menu CurrentMenu;
	public Menu initialMenu;
	static GameObject obj;
	static GameObject obj1;
	public static GameObject registrationButton;
	public static GameObject backButton;
	public GameObject loginButton;

	//Statystyki
	public int pointsToGive = 32;
	public Text STR;
	public Text DEX;
	public Text CON;
	public Text INT;
	public Text WIS;
	public Text CHA;
	public Text PTS;//summary points
	//

	public CharacterStats stats; //statystyki
	public CharacterClass classCha; // element  postaci
	public int Characterchooseclass; // wybor klasy postaci

	//
	
	bool [,] Ranks = new bool[5, 5];
	public GameObject toggleGroup1;
	public GameObject toggleGroup2;
	public GameObject toggleGroup3;
	public GameObject toggleGroup4;
	public GameObject toggleGroup5;
	public ToggleGroup toggleGroup1G;
	public ToggleGroup toggleGroup2G;
	public ToggleGroup toggleGroup3G;
	public ToggleGroup toggleGroup4G;
	public ToggleGroup toggleGroup5G;


	public static void setCurrentMenu(Menu menu)
	{
		CurrentMenu = menu;
	}

	public static Menu getCurrentMenu()
	{
		return CurrentMenu;
	}

	public static void setCurrentMenuOpenFalse()
	{
		CurrentMenu.isOpen = false;
	}
	public static void setCurrentMenuOpenTrue()
	{
		CurrentMenu.isOpen = true;
	}

	public void Start()
	{
		setCurrentMenu (initialMenu);
		ShowMenu (CurrentMenu);
		obj = GameObject.FindGameObjectWithTag ("Back");
		backButton = GameObject.FindGameObjectWithTag ("Back");
		obj.SetActive (false);
		registrationButton = GameObject.Find("Registration");
		GameObject.Find ("ClassButton");

		stats = new CharacterStats ();
		PTS.text = stats.getPTS().ToString();
		STR.text = stats.getSTR().ToString();
		CHA.text = stats.getCHA().ToString();
		INT.text = stats.getINT().ToString();
		DEX.text = stats.getDEX().ToString();
		WIS.text = stats.getWIS().ToString();
		CON.text = stats.getCON().ToString();
		onRank1Click ();

	}

	public void Update()
	{
		if (Input.GetKey(KeyCode.KeypadEnter)  || Input.GetKey ("enter") || (Input.GetKey(KeyCode.Return)))
		{
			print ("enter");
			ExecuteEvents.Execute (loginButton, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
		}
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

	public static void ShowRegistrationButton()// Registration button hide
	{
		if (registrationButton)
			registrationButton.SetActive (true);
		
	}

	public  void ShowRegistrationButtonNonStatic()// Registration button hide
	{
		if (registrationButton)
			registrationButton.SetActive (true);
		
	}

	public static void HideRegistrationButton()// Registration button hide
	{
		if (registrationButton)
			registrationButton.SetActive (false);
		
	}
	
	public  void HideRegistrationButtonNonStatic()// Registration button hide
	{
		if (registrationButton)
			registrationButton.SetActive (false);
		
	}

	public static void HideBackButton()// Registration button hide
	{
		if (backButton)
			backButton.SetActive (false);		
	}

	public  void HideBackButtonNonStatic()// Registration button hide
	{
		if (backButton)
			backButton.SetActive (false);		
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
			Characterchooseclass = 0;
			break;
		case "Mage":
			BAB.text = "1";
			FORT.text = "2";
			REF.text = "2";
			WILL.text = "0";
			Characterchooseclass = 1;
			break;
		case "Knight":
			BAB.text = "1";
			FORT.text = "2";
			REF.text = "0";
			WILL.text = "1";
			Characterchooseclass = 2;
			break;
		case "Mystic":
			BAB.text = "0";
			FORT.text = "2";
			REF.text = "0";
			WILL.text = "2";
			Characterchooseclass = 3;
			break;
		default: 
			BAB.text = "0";
			FORT.text = "0";
			REF.text = "0";
			WILL.text = "0";
			classCha = null;
			break;
		}
	}

	
	public void onRank1Click()
	{
		toggleGroup1.SetActive (true);
		toggleGroup2.SetActive (false);
		toggleGroup3.SetActive (false);
		toggleGroup4.SetActive (false);
		toggleGroup5.SetActive (false);
	}
	
	public void onRank2Click()
	{
		toggleGroup1.SetActive (false);
		toggleGroup2.SetActive (true);
		toggleGroup3.SetActive (false);
		toggleGroup4.SetActive (false);
		toggleGroup5.SetActive (false);
	}
	
	public void onRank3Click()
	{
		toggleGroup1.SetActive (false);
		toggleGroup2.SetActive (false);
		toggleGroup3.SetActive (true);
		toggleGroup4.SetActive (false);
		toggleGroup5.SetActive (false);
	}
	
	public void onRank4Click()
	{
		toggleGroup1.SetActive (false);
		toggleGroup2.SetActive (false);
		toggleGroup3.SetActive (false);
		toggleGroup4.SetActive (true);
		toggleGroup5.SetActive (false);
	}
	
	public void onRank5Click()
	{
		toggleGroup1.SetActive (false);
		toggleGroup2.SetActive (false);
		toggleGroup3.SetActive (false);
		toggleGroup4.SetActive (false);
		toggleGroup5.SetActive (true);
	}
	
	public void onValueChanged11()
	{
		Ranks [0, 0] = true;
		print ("lal");
	}
	
	public void onValueChanged12()
	{
		Ranks [0, 1] = true;
		print ("lal");
	}
	
	public void onValueChanged13()
	{
		Ranks [0, 2] = true;
		print ("lal");
	}
	
	public void onValueChanged14()
	{
		Ranks [0, 3] = true;
		print ("lal");
	}
	
	public void onValueChanged15()
	{
		Ranks [0, 4] = true;
		print ("lal");
	}
	
	
	public void onValueChanged21()
	{
		Ranks [1, 0] = true;
		print ("Clouuuudy");
	}
	
	public void onValueChanged22()
	{
		Ranks [1, 1] = true;
		print ("lal");
	}
	
	public void onValueChanged23()
	{
		Ranks [1, 2] = true;
		print ("lal");
	}
	
	public void onValueChanged24()
	{
		Ranks [1, 3] = true;
		print ("lal");
	}
	
	public void onValueChanged25()
	{
		Ranks [1, 4] = true;
		print ("lal");
	}
	
	public void onValueChanged31()
	{
		Ranks [2, 0] = true;
		print ("lal");
	}
	
	public void onValueChanged32()
	{
		Ranks [2, 1] = true;
		print ("lal");
	}
	
	public void onValueChanged33()
	{
		Ranks [2, 2] = true;
		print ("lal");
	}
	
	public void onValueChanged34()
	{
		Ranks [2, 3] = true;
		print ("lal");
	}
	
	public void onValueChanged35()
	{
		Ranks [2, 4] = true;
		print ("lal");
	}
	
	public void onValueChanged41()
	{
		Ranks [3, 0] = true;
		print ("lal");
	}
	
	public void onValueChanged42()
	{
		Ranks [3, 1] = true;
		print ("lal");
	}
	
	public void onValueChanged43()
	{
		Ranks [3, 2] = true;
		print ("lal");
	}
	
	public void onValueChanged44()
	{
		Ranks [3, 3] = true;
		print ("lal");
	}
	
	public void onValueChanged45()
	{
		Ranks [3, 4] = true;
		print ("lal");
	}
	
	public void onValueChanged51()
	{
		Ranks [4, 0] = true;
		print ("lal");
	}
	
	public void onValueChanged52()
	{
		Ranks [4, 1] = true;
		print ("lal");
	}
	
	public void onValueChanged53()
	{
		Ranks [4, 2] = true;
		print ("lal");
	}
	
	public void onValueChanged54()
	{
		Ranks [4, 3] = true;
		print ("lal");
	}
	
	public void onValueChanged55()
	{
		Ranks [4, 4] = true;
		print ("lal");
	}


	
}

