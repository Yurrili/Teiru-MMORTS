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

	}

	public void Update()
	{
		if (Input.GetKey(KeyCode.KeypadEnter)  || Input.GetKey ("enter") || (Input.GetKey(KeyCode.Return)))
		{
			print ("enter");
			ExecuteEvents.Execute (loginButton, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
		}
	}

	public bool check()
	{

		//|| GameObject.Find ("NameTAG").GetComponent<InputField>().textComponent.text == ""

		//if (Characterchooseclass == 0 || PTS.text != "0"  ) {
		//	return false;
		//} else {
			return true;
		//}
	}

	public void moveOn(Menu menu){

		//if (check ()) {
		print ("enter");
			switch(Characterchooseclass)
			{
			case 1:
				classCha = new CharacterClass_Ranger(stats.getCON());
			print ("Ranger");
				break;
			case 2:
				classCha = new CharacterClass_Mage(stats.getCON());
			print ("Mage");
				break;
			case 3:
				classCha = new CharacterClass_Knight(stats.getCON());
				break;
			case 4:
				classCha = new CharacterClass_Mystiq(stats.getCON());
				break;
			}

			GameObject.Find ("NameTextPlace").GetComponent<Text>().text = GameObject.Find ("NameTAG").GetComponent<InputField>().textComponent.text;
			
			GameObject.Find ("ClassTextPlace").GetComponent<Text>().text = classCha.getClass();
			GameObject.Find ("LevelTextPlace").GetComponent<Text>().text = classCha.getLvl()+ "";

			GameObject.Find ("STRTextPlace").GetComponent<Text>().text = stats.getSTR() + "";
			GameObject.Find ("DEXTextPlace").GetComponent<Text>().text = stats.getDEX() + "";
			GameObject.Find ("CONTextPlace").GetComponent<Text>().text = stats.getCON() + "";
			GameObject.Find ("INTTextPlace").GetComponent<Text>().text = stats.getINT() + "";
			GameObject.Find ("WISTextPlace").GetComponent<Text>().text = stats.getWIS() + "";
			GameObject.Find ("CHATextPlace").GetComponent<Text>().text = stats.getCHA() + "";

			onRank1Click ();
			ShowMenu(menu);
		//
		//} else {
			//print(GameObject.Find ("NameTAG"). GetComponent<InputField>().textComponent.text);
			//print("validation failed");
		//}
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
			Characterchooseclass = 0;
			break;
		case "Ranger":
			BAB.text = "1";
			FORT.text = "2";
			REF.text = "2";
			WILL.text = "0";
			Characterchooseclass = 1;
			break;
		case "Mage":
			BAB.text = "1";
			FORT.text = "2";
			REF.text = "2";
			WILL.text = "0";
			Characterchooseclass = 2;
			break;
		case "Knight":
			BAB.text = "1";
			FORT.text = "2";
			REF.text = "0";
			WILL.text = "1";
			Characterchooseclass = 3;
			break;
		case "Mystic":
			BAB.text = "0";
			FORT.text = "2";
			REF.text = "0";
			WILL.text = "2";
			Characterchooseclass = 4;
			break;
		default: 
			BAB.text = "0";
			FORT.text = "0";
			REF.text = "0";
			WILL.text = "0";
			Characterchooseclass = 0;
			break;
		}
	}

	public void ShowonRankButtons(){

		if (checkRankPart (0) == false) {
			GameObject.Find ("Rank1Button").SetActive (false);
		}
		
		if (checkRankPart (1) == false) {
			GameObject.Find ("Rank2Button").SetActive (false);
		}
		
		if (checkRankPart (2) == false) {
			GameObject.Find ("Rank3Button").SetActive (false);
		}
		
		if (checkRankPart (3) == false) {
			GameObject.Find ("Rank4Button").SetActive (false);
		}
		
		if (checkRankPart (4) == false) {
			GameObject.Find ("Rank5Button").SetActive (false);
		}
	}
	
	public void onRank1Click()
	{
		ShowonRankButtons ();
		toggleGroup1.SetActive (true);
		toggleGroup2.SetActive (false);
		toggleGroup3.SetActive (false);
		toggleGroup4.SetActive (false);
		toggleGroup5.SetActive (false);

		if (classCha.getSkillName (0, 0) != "") {
			if(GameObject.Find ("Skill1").activeSelf == false)
				GameObject.Find ("Skill1").SetActive (true);
			GameObject.Find ("Skill1").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (0, 0);
		} else {
			if(GameObject.Find ("Skill1").activeSelf == true)
				GameObject.Find ("Skill1").SetActive (false);	
		}

		if (classCha.getSkillName (0, 1) != "") {
			if(GameObject.Find ("Skill2").activeSelf == false)
				GameObject.Find ("Skill2").SetActive (true);
			GameObject.Find ("Skill2").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (0, 1);
		} else {
			if(GameObject.Find ("Skill2").activeSelf == true)
				GameObject.Find ("Skill2").SetActive (false);
		}

		if (classCha.getSkillName (0, 2) != "") {
			if(GameObject.Find ("Skill3").activeSelf == false)
				GameObject.Find ("Skill3").SetActive (true);
			GameObject.Find ("Skill3").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (0, 2);
		} else {
			if(GameObject.Find ("Skill3").activeSelf == true)
				GameObject.Find ("Skill3").SetActive (false);
		}
		if (classCha.getSkillName (0, 3) != "") {
			if(GameObject.Find ("Skill4").activeSelf == false)
				GameObject.Find ("Skill4").SetActive (true);
			GameObject.Find ("Skill4").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (0, 3);
		} else {
			if(GameObject.Find ("Skill4").activeSelf == true)
				GameObject.Find ("Skill4").SetActive (false);
		}

		if (classCha.getSkillName (0, 4) != "") {
			if(GameObject.Find ("Skill5").activeSelf == false)
				GameObject.Find ("Skill5").SetActive (true);
			GameObject.Find ("Skill5").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (0, 4);
		} else {
			if(GameObject.Find ("Skill5").activeSelf == true)
				GameObject.Find ("Skill5").SetActive (false);
		}
	}
	
	public void onRank2Click()
	{

		toggleGroup1.SetActive (false);
		toggleGroup2.SetActive (true);
		toggleGroup3.SetActive (false);
		toggleGroup4.SetActive (false);
		toggleGroup5.SetActive (false);

		
		if (classCha.getSkillName (1, 0) != "") {
			if(GameObject.Find ("Skill1").activeSelf == false)
				GameObject.Find ("Skill1").SetActive (true);
			GameObject.Find ("Skill1").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (1, 0);
		} else {
			GameObject.Find ("Skill1").SetActive (false);	
		}
		
		if (classCha.getSkillName (1, 1) != "") {
			if(GameObject.Find ("Skill2").activeSelf == false)
				GameObject.Find ("Skill2").SetActive (true);
			GameObject.Find ("Skill2").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (1, 1);
		} else {
			GameObject.Find ("Skill2").SetActive (false);	
		}
		
		if (classCha.getSkillName (1, 2) != "") {
			if(GameObject.Find ("Skill3").activeSelf == false)
				GameObject.Find ("Skill3").SetActive (true);
			GameObject.Find ("Skill3").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (1, 2);
		} else {
			GameObject.Find ("Skill3").SetActive (false);
		}
		if (classCha.getSkillName (1, 3) != "") {
			if(GameObject.Find ("Skill4").activeSelf == false)
				GameObject.Find ("Skill4").SetActive (true);
			GameObject.Find ("Skill4").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (1, 3);
		} else {
			GameObject.Find ("Skill4").SetActive (false);
		}
		
		if (classCha.getSkillName (1, 4) != "") {
			if(GameObject.Find ("Skill5").activeSelf == false)
				GameObject.Find ("Skill5").SetActive (true);
			GameObject.Find ("Skill5").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (1, 4);
		} else {
			GameObject.Find ("Skill5").SetActive (false);
		}
	}
	
	public void onRank3Click()
	{
		toggleGroup1.SetActive (false);
		toggleGroup2.SetActive (false);
		toggleGroup3.SetActive (true);
		toggleGroup4.SetActive (false);
		toggleGroup5.SetActive (false);

		if (classCha.getSkillName (2, 0) != "") {
			if(GameObject.Find ("Skill1").activeSelf == false)
				GameObject.Find ("Skill1").SetActive (true);
			GameObject.Find ("Skill1").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (2, 0);
		} else {
			GameObject.Find ("Skill1").SetActive (false);	
		}
		
		if (classCha.getSkillName (2, 1) != "") {
			if(GameObject.Find ("Skill2").activeSelf == false)
				GameObject.Find ("Skill2").SetActive (true);
			GameObject.Find ("Skill2").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (2, 1);
		} else {
			GameObject.Find ("Skill2").SetActive (false);	
		}
		
		if (classCha.getSkillName (2, 2) != "") {
			if(GameObject.Find ("Skill3").activeSelf == false)
				GameObject.Find ("Skill3").SetActive (true);
			GameObject.Find ("Skill3").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (2, 2);
		} else {
			GameObject.Find ("Skill3").SetActive (false);
		}
		if (classCha.getSkillName (2, 3) != "") {
			if(GameObject.Find ("Skill4").activeSelf == false)
				GameObject.Find ("Skill4").SetActive (true);
			GameObject.Find ("Skill4").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (2, 3);
		} else {
			GameObject.Find ("Skill4").SetActive (false);
		}
		
		if (classCha.getSkillName (2, 4) != "") {
			if(GameObject.Find ("Skill5").activeSelf == false)
				GameObject.Find ("Skill5").SetActive (true);
			GameObject.Find ("Skill5").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (2, 4);
		} else {
			GameObject.Find ("Skill5").SetActive (false);
		}
	}
	
	public void onRank4Click()
	{
		toggleGroup1.SetActive (false);
		toggleGroup2.SetActive (false);
		toggleGroup3.SetActive (false);
		toggleGroup4.SetActive (true);
		toggleGroup5.SetActive (false);

		if (classCha.getSkillName (3, 0) != "") {
			if(GameObject.Find ("Skill1").activeSelf == false)
				GameObject.Find ("Skill1").SetActive (true);
			GameObject.Find ("Skill1").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (3, 0);
		} else {
			GameObject.Find ("Skill1").SetActive (false);	
		}
		
		if (classCha.getSkillName (3, 1) != "") {
			if(GameObject.Find ("Skill2").activeSelf == false)
				GameObject.Find ("Skill2").SetActive (true);
			GameObject.Find ("Skill2").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (3, 1);
		} else {
			GameObject.Find ("Skill2").SetActive (false);	
		}
		
		if (classCha.getSkillName (3, 2) != "") {
			//GameObject.Find ("Skill3").SetActive (true);
			GameObject.Find ("Skill3").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (3, 2);
		} else {
			GameObject.Find ("Skill3").SetActive (false);
		}
		if (classCha.getSkillName (3, 3) != "") {
			if(GameObject.Find ("Skill4").activeSelf == false)
				GameObject.Find ("Skill4").SetActive (true);
			GameObject.Find ("Skill4").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (3, 3);
		} else {
			GameObject.Find ("Skill4").SetActive (false);
		}
		
		if (classCha.getSkillName (3, 4) != "") {
			if(GameObject.Find ("Skill5").activeSelf == false)
				GameObject.Find ("Skill5").SetActive (true);
			GameObject.Find ("Skill5").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (3, 4);
		} else {
			GameObject.Find ("Skill5").SetActive (false);
		}
	}

	public bool checkRankPart(int row){

		bool a = false;

		for (int i = 0; i < 5; i++) {
			if(classCha.getSkillName (row,i) != "")
				a = true;
		}

		return a;
	}
	
	public void onRank5Click()
	{
		toggleGroup1.SetActive (false);
		toggleGroup2.SetActive (false);
		toggleGroup3.SetActive (false);
		toggleGroup4.SetActive (false);
		toggleGroup5.SetActive (true);

		if (classCha.getSkillName (4, 0) != "") {
			//GameObject.Find ("Skill1").SetActive (true);
			GameObject.Find ("Skill1").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (4, 0);
		} else {
			GameObject.Find ("Skill1").SetActive (false);	
		}
		
		if (classCha.getSkillName (4, 1) != "") {
			//GameObject.Find ("Skill2").SetActive (true);
			GameObject.Find ("Skill2").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (4, 1);
		} else {
			GameObject.Find ("Skill2").SetActive (false);	
		}
		
		if (classCha.getSkillName (4, 2) != "") {
			//GameObject.Find ("Skill3").SetActive (true);
			GameObject.Find ("Skill3").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (4, 2);
		} else {
			GameObject.Find ("Skill3").SetActive (false);
		}
		if (classCha.getSkillName (4, 3) != "") {
			//GameObject.Find ("Skill4").SetActive (false);
			GameObject.Find ("Skill4").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (4, 3);
		} else {
			GameObject.Find ("Skill4").SetActive (false);
		}
		
		if (classCha.getSkillName (4, 4) != "") {
			//GameObject.Find ("Skill5").SetActive (true);
			GameObject.Find ("Skill5").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (4, 4);
		} else {
			GameObject.Find ("Skill5").SetActive (false);
		}
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

