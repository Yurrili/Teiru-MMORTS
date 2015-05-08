using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreatorCharacter : MonoBehaviour {

	//
	
	bool [,] Ranks = new bool[5, 5];

	public static Item [] Equ = new Item[4];

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


	public GameObject heads;
	public GameObject chests;
	public GameObject boots;
	public GameObject weapons;
	
	public GameObject Rank1But;
	public GameObject Rank2But;
	public GameObject Rank3But;
	public GameObject Rank4But;
	public GameObject Rank5But;
	
	//Statystyki
	public int ArtPoints;
	public int pointsToGive = 32;
	public Text STR;
	public Text DEX;
	public Text CON;
	public Text INT;
	public Text WIS;
	public Text CHA;
	public Text PTS;//summary points
	public Text ClassYou;

	public Toggle[] ChesttoggleGroup;
	public Toggle[] HelmettoggleGroup;
	public Toggle[] BootstoggleGroup;
	public Toggle[] WeapontoggleGroup;
	//

	public Text Gold;
	
	private int GoldDD;

	public Toggle[] rank1; 
	public Toggle[] rank2;
	public Toggle[] rank3;
	public Toggle[] rank4;
	public Toggle[] rank5;
	
	public static CharacterStats stats = new CharacterStats (); //statystyki
	public static CharacterClass classCha; // element  postaci
	public static int Characterchooseclass; // wybor klasy postaci

	public static string Avatar;

	public static int aA = -1; //rank
	public static int bB = -1;//skill

	public int STRSUM;
	public int DEXSUM;
	public int CONSUM;
	public int INTSUM;
	public int WISSUM;
	public int CHASUM;

	void Start () 
	{

		GoldDD = 40;
		Gold.text = GoldDD + "";

		//Elementary Equ
		Equ [0] = new Helmet(0);
		Equ [1] = new Chest (0);
		Equ [2] = new Boots(0);
		Equ [3] = new Weapon(0);



		PTS.text = stats.getPTS().ToString();
		STR.text = stats.getSTR().ToString();
		CHA.text = stats.getCHA().ToString();
		INT.text = stats.getINT().ToString();
		DEX.text = stats.getDEX().ToString();
		WIS.text = stats.getWIS().ToString();
		CON.text = stats.getCON().ToString();

		GameObject g = GameObject.Find ("SkillToggleGroup");
		rank1 = g.GetComponentsInChildren<Toggle> ();

		g = GameObject.Find ("SkillToggleGroup2");
		rank2 = g.GetComponentsInChildren<Toggle> ();
		
		g = GameObject.Find ("SkillToggleGroup3");
		rank3 = g.GetComponentsInChildren<Toggle> ();
			
		g = GameObject.Find ("SkillToggleGroup4");
		rank4 = g.GetComponentsInChildren<Toggle> ();
			
		g = GameObject.Find ("SkillToggleGroup5");
		rank5 = g.GetComponentsInChildren<Toggle> ();

		Rank1But = GameObject.Find ("Rank1Button");
		Rank2But = GameObject.Find ("Rank2Button");
		Rank3But = GameObject.Find ("Rank3Button");
		Rank4But = GameObject.Find ("Rank4Button");
		Rank5But = GameObject.Find ("Rank5Button");

		g = GameObject.Find ("ItemsToggleGroup");
		HelmettoggleGroup = g.GetComponentsInChildren<Toggle> ();
		
		g = GameObject.Find ("ItemsToggleGroup2");
		ChesttoggleGroup = g.GetComponentsInChildren<Toggle> ();
		
		g = GameObject.Find ("ItemsToggleGroup3");
		BootstoggleGroup = g.GetComponentsInChildren<Toggle> ();
		
		g = GameObject.Find ("ItemsToggleGroup4");
		WeapontoggleGroup = g.GetComponentsInChildren<Toggle> ();

		onPartofBodyClick ();
	
	}

	public void RefreshGold(){
		CalculateBonusStats ();
		Gold.text = GoldDD + "";
		BlockItems ();
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void CalculateBonusStats(){
	
		int strB, conB, chaB, intB, wisB, dexB;

		strB = conB = chaB = intB = dexB = wisB = 0;
		if (Equ [0] != null) {
			strB += Equ[0].getBonus().getSTR();
			conB += Equ[0].getBonus().getCON();
			chaB += Equ[0].getBonus().getCHA();
			intB += Equ[0].getBonus().getINT();
			wisB += Equ[0].getBonus().getWIS();
			dexB += Equ[0].getBonus().getDEX();
		}
	
		if (Equ [1] != null) {

			strB += Equ[1].getBonus().getSTR();
			conB += Equ[1].getBonus().getCON();
			chaB += Equ[1].getBonus().getCHA();
			intB += Equ[1].getBonus().getINT();
			wisB += Equ[1].getBonus().getWIS();
			dexB += Equ[1].getBonus().getDEX();
		}
		if (Equ [2] != null) {
			
			strB += Equ[2].getBonus().getSTR();
			conB += Equ[2].getBonus().getCON();
			chaB += Equ[2].getBonus().getCHA();
			intB += Equ[2].getBonus().getINT();
			wisB += Equ[2].getBonus().getWIS();
			dexB += Equ[2].getBonus().getDEX();
		}

			
		if (Equ [3] != null) {
			
			strB += Equ[3].getBonus().getSTR();
			conB += Equ[3].getBonus().getCON();
			chaB += Equ[3].getBonus().getCHA();
			intB += Equ[3].getBonus().getINT();
			wisB += Equ[3].getBonus().getWIS();
			dexB += Equ[3].getBonus().getDEX();
		}

		Text A = GameObject.Find ("STRTextBONUS").GetComponentInChildren<Text>();
		Text B = GameObject.Find ("CONTextBONUS").GetComponentInChildren<Text>();
		Text C = GameObject.Find ("CHATextBONUS").GetComponentInChildren<Text>();
		Text D = GameObject.Find ("INTTextBONUS").GetComponentInChildren<Text>();
		Text E = GameObject.Find ("WISTextBONUS").GetComponentInChildren<Text>();
		Text F = GameObject.Find ("DEXTextBONUS").GetComponentInChildren<Text>();

		A.text = stats.getSTR() + " +" + strB;
		B.text = stats.getCON() + " +" + conB;
		C.text = stats.getCHA() + " +" + chaB;
		D.text = stats.getINT() + " +" + intB;
		E.text = stats.getWIS() + " +" + wisB;
		F.text = stats.getDEX() + " +" + dexB;

		STRSUM = stats.getSTR() + strB;
		DEXSUM = stats.getCON() + conB;
		CONSUM = stats.getCHA() + chaB;
		INTSUM = stats.getINT() + intB;
		WISSUM = stats.getWIS() + wisB;
		CHASUM = stats.getDEX() + dexB;

	}

	
	public void PushedB()
	{
		ChangeInputFieldText ("Ranger");
		classchoose ();

	}
	
	public void PushedF()
	{
		ChangeInputFieldText ("Mage");
		classchoose ();
	}
	
	public void PushedR()
	{
		ChangeInputFieldText ("Knight");
		classchoose ();
	}
	
	public void PushedW()
	{
		ChangeInputFieldText ("Mystic");
		classchoose ();
	}
	
	void ChangeInputFieldText(string IFname){
		
		Text BAB = GameObject.Find ("BABText").GetComponentInChildren<Text>();
		Text FORT = GameObject.Find ("FORTText").GetComponentInChildren<Text>();
		Text REF = GameObject.Find ("REFText").GetComponentInChildren<Text>();
		Text WILL = GameObject.Find ("WILLText").GetComponentInChildren<Text>();
		//if(textscript == null){Debug.LogError("Script not found");return;}
		switch (IFname)
		{
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
		}
	}

	public void IncreaseSTR(){
		
		STR.text = stats.increaseSTR().ToString();
		PTS.text = stats.getPTS().ToString();
		CalculateBonusStats ();
	}
	
	public void IncreaseCHA(){
		
		CHA.text = stats.increaseCHA().ToString();
		PTS.text = stats.getPTS().ToString();
		CalculateBonusStats ();
	}
	
	public void IncreaseINT(){
		
		INT.text = stats.increaseINT().ToString();
		PTS.text = stats.getPTS().ToString();
		CalculateBonusStats ();
	}
	
	public void IncreaseDEX(){
		
		DEX.text = stats.increaseDEX().ToString();
		PTS.text = stats.getPTS().ToString();
		CalculateBonusStats ();
	}
	
	public void IncreaseWIS(){
		
		WIS.text = stats.increaseWIS().ToString();
		PTS.text = stats.getPTS().ToString();
		CalculateBonusStats ();
	}
	
	public void IncreaseCON(){
		
		CON.text = stats.increaseCON().ToString();
		PTS.text = stats.getPTS().ToString();
		CalculateBonusStats ();
	}
	
	public void DecreaseSTR(){
		
		STR.text = stats.decreaseSTR().ToString();
		PTS.text = stats.getPTS().ToString();
		CalculateBonusStats ();
	}
	
	public void DecreaseDEX(){
		
		DEX.text = stats.decreaseDEX().ToString();
		PTS.text = stats.getPTS().ToString();
		CalculateBonusStats ();
	}
	
	public void DecreaseWIS(){
		
		WIS.text = stats.decreaseWIS().ToString();
		PTS.text = stats.getPTS().ToString();
		CalculateBonusStats ();
	}
	
	public void DecreaseCON(){
		
		CON.text = stats.decreaseCON().ToString();
		PTS.text = stats.getPTS().ToString();
		CalculateBonusStats ();
	}
	
	public void DecreaseCHA(){ //testowane
		
		CHA.text = stats.decreaseCHA().ToString();
		PTS.text = stats.getPTS ().ToString ();
		CalculateBonusStats ();
	}
	
	public void DecreaseInt(){ //testowane
		
		INT.text = stats.decreaseINT().ToString();
		PTS.text = stats.getPTS().ToString();
		CalculateBonusStats ();
	}

	public bool check() //testowane
	{
		
		if (Characterchooseclass == 0 || PTS.text != "0" || GameObject.Find ("NameTAG").GetComponent<InputField>().textComponent.text == "" ) {
			return false;
		} else {
			return true;
		}
	}
	
	private void classchoose(){
		classCha = null;
		switch(Characterchooseclass)
		{
		case 1:
			classCha = new CharacterClass_Ranger(stats.getCON());
			ClassYou.text = "Ranger";
			//print ("Ranger");
			break;
		case 2:
			classCha = new CharacterClass_Mage(stats.getCON());
			ClassYou.text = "Mage";
		//	print ("Mage");
			break;
		case 3:
			classCha = new CharacterClass_Knight(stats.getCON());
			ClassYou.text = "Knight";
		//	print ("Knight");
			break;
		case 4:
			classCha = new CharacterClass_Mystiq(stats.getCON());
			ClassYou.text = "Mystic";
		//	print ("Mystic");
			break;
		}
		Prevent ();
	}

	public void ShowMenu(Menu menu) //testowane
	{
		if (MenuManager.getCurrentMenu() != null)
			MenuManager.setCurrentMenuOpenFalse();
		
		MenuManager.setCurrentMenu(menu);
		MenuManager.setCurrentMenuOpenTrue ();


	}
	
	public void moveOn(Menu menu){
		
		if (check ()) {

			print (classCha.getClass());
			classchoose ();
			ArtPoints = classCha.getArts(0);
			GameObject.Find ("RemainingSkillPointsText").GetComponent<Text>().text = ArtPoints + "";
			GameObject.Find ("NameTextPlace").GetComponent<Text>().text = GameObject.Find ("NameTAG").GetComponent<InputField>().textComponent.text;
			
			GameObject.Find ("ClassTextPlace").GetComponent<Text>().text = classCha.getClass();
			GameObject.Find ("LevelTextPlace").GetComponent<Text>().text = classCha.getLvl()+ "";
			
			GameObject.Find ("STRTextPlace").GetComponent<Text>().text = STRSUM + "";
			GameObject.Find ("DEXTextPlace").GetComponent<Text>().text = DEXSUM + "";
			GameObject.Find ("CONTextPlace").GetComponent<Text>().text = CONSUM + "";
			GameObject.Find ("INTTextPlace").GetComponent<Text>().text = INTSUM + "";
			GameObject.Find ("WISTextPlace").GetComponent<Text>().text = WISSUM + "";
			GameObject.Find ("CHATextPlace").GetComponent<Text>().text = CHASUM + "";
			

			ShowMenu(menu);
			onRank1Click ();
		
			
		} else {
			//print(GameObject.Find ("NameTAG"). GetComponent<InputField>().textComponent.text);
			print("validation failed");
		}
	}
	
	
	
	public void ShowonRankButtons(){
		
		if (checkRankPart (0) == false) {
			Rank1But.SetActive (false);
		} else {
			Rank1But.SetActive (true);
		}
		
		if (checkRankPart (1) == false) {
			Rank2But.SetActive (false);
		} else {
			Rank2But.SetActive (true);
		}
		
		if (checkRankPart (2) == false) {
			Rank3But.SetActive (false);
		} else {
			Rank3But.SetActive (true);
		}
		
		if (checkRankPart (3) == false) {
			Rank4But.SetActive (false);//utyka tu, why ?
		}  else {
			Rank4But.SetActive (true);
		}
		
		if (checkRankPart (4) == false) {
			Rank5But.SetActive (false);
		}  else {
			Rank5But.SetActive (true);
		}
	}



	
	public void onRank1Click()
	{
		toggleGroup1.SetActive (true);
		toggleGroup2.SetActive (false);
		toggleGroup3.SetActive (false);
		toggleGroup4.SetActive (false);
		toggleGroup5.SetActive (false);

		ShowonRankButtons ();

		if (classCha.getSkillName (0, 0) != "") {

			GameObject.Find ("Skill1").SetActive (true);
			GameObject.Find ("Skill1").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (0, 0);
			//GameObject.Find ("Skill1").GetComponent<Toggle> ().interactable = false;
		} else {

			GameObject.Find ("Skill1").SetActive (false);	
		}
		
		if (classCha.getSkillName (0, 1) != "") {
			GameObject.Find ("Skill2").SetActive (true);
			GameObject.Find ("Skill2").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (0, 1);
		} else {
		
			GameObject.Find ("Skill2").SetActive (false);
		}
		
		if (classCha.getSkillName (0, 2) != "") {

			GameObject.Find ("Skill3").SetActive (true);
			GameObject.Find ("Skill3").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (0, 2);
		} else {
		
			GameObject.Find ("Skill3").SetActive (false);
		}
		if (classCha.getSkillName (0, 3) != "") {

			GameObject.Find ("Skill4").SetActive (true);
			GameObject.Find ("Skill4").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (0, 3);
		} else {
		
			GameObject.Find ("Skill4").SetActive (false);
		}
		
		if (classCha.getSkillName (0, 4) != "") {
		
			GameObject.Find ("Skill5").SetActive (true);
			GameObject.Find ("Skill5").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (0, 4);
		} else {

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

			GameObject.Find ("Skill1").SetActive (true);
			GameObject.Find ("Skill1").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (1, 0);
		} else {
			GameObject.Find ("Skill1").SetActive (false);	
		}
		
		if (classCha.getSkillName (1, 1) != "") {

			GameObject.Find ("Skill2").SetActive (true);
			GameObject.Find ("Skill2").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (1, 1);
		} else {
			GameObject.Find ("Skill2").SetActive (false);	
		}
		
		if (classCha.getSkillName (1, 2) != "") {

			GameObject.Find ("Skill3").SetActive (true);
			GameObject.Find ("Skill3").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (1, 2);
		} else {
			GameObject.Find ("Skill3").SetActive (false);
		}
		if (classCha.getSkillName (1, 3) != "") {

			GameObject.Find ("Skill4").SetActive (true);
			GameObject.Find ("Skill4").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (1, 3);
		} else {
			GameObject.Find ("Skill4").SetActive (false);
		}
		
		if (classCha.getSkillName (1, 4) != "") {
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

			GameObject.Find ("Skill1").SetActive (true);
			GameObject.Find ("Skill1").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (2, 0);
		} else {
			GameObject.Find ("Skill1").SetActive (false);	
		}
		
		if (classCha.getSkillName (2, 1) != "") {

			GameObject.Find ("Skill2").SetActive (true);
			GameObject.Find ("Skill2").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (2, 1);
		} else {
			GameObject.Find ("Skill2").SetActive (false);	
		}
		
		if (classCha.getSkillName (2, 2) != "") {
			GameObject.Find ("Skill3").SetActive (true);
			GameObject.Find ("Skill3").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (2, 2);
		} else {
			GameObject.Find ("Skill3").SetActive (false);
		}
		if (classCha.getSkillName (2, 3) != "") {

			GameObject.Find ("Skill4").SetActive (true);
			GameObject.Find ("Skill4").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (2, 3);
		} else {
			GameObject.Find ("Skill4").SetActive (false);
		}
		
		if (classCha.getSkillName (2, 4) != "") {

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

			GameObject.Find ("Skill1").SetActive (true);
			GameObject.Find ("Skill1").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (3, 0);
		} else {
			GameObject.Find ("Skill1").SetActive (false);	
		}
		
		if (classCha.getSkillName (3, 1) != "") {

			GameObject.Find ("Skill2").SetActive (true);
			GameObject.Find ("Skill2").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (3, 1);
		} else {
			GameObject.Find ("Skill2").SetActive (false);	
		}
		
		if (classCha.getSkillName (3, 2) != "") {
			GameObject.Find ("Skill3").SetActive (true);
			GameObject.Find ("Skill3").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (3, 2);
		} else {
			GameObject.Find ("Skill3").SetActive (false);
		}
		if (classCha.getSkillName (3, 3) != "") {

			GameObject.Find ("Skill4").SetActive (true);
			GameObject.Find ("Skill4").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (3, 3);
		} else {
			GameObject.Find ("Skill4").SetActive (false);
		}
		
		if (classCha.getSkillName (3, 4) != "") {

			GameObject.Find ("Skill5").SetActive (true);
			GameObject.Find ("Skill5").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (3, 4);
		} else {
			GameObject.Find ("Skill5").SetActive (false);
		}
	}
	
	public bool checkRankPart(int row){
		
		bool a = false;
		
		for (int i = 0; i < 5; i++) {
			if(classCha.getSkillName (row,i) != ""){
				a = true;
				break;
			}
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
			GameObject.Find ("Skill1").SetActive (true);
			GameObject.Find ("Skill1").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (4, 0);

		} else {
			GameObject.Find ("Skill1").SetActive (false);	
		}
		
		if (classCha.getSkillName (4, 1) != "") {
			GameObject.Find ("Skill2").SetActive (true);
			GameObject.Find ("Skill2").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (4, 1);
		} else {
			GameObject.Find ("Skill2").SetActive (false);	
		}
		
		if (classCha.getSkillName (4, 2) != "") {
			GameObject.Find ("Skill3").SetActive (true);
			GameObject.Find ("Skill3").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (4, 2);
		} else {
			GameObject.Find ("Skill3").SetActive (false);
		}
		if (classCha.getSkillName (4, 3) != "") {
			GameObject.Find ("Skill4").SetActive (false);
			GameObject.Find ("Skill4").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (4, 3);
		} else {
			GameObject.Find ("Skill4").SetActive (false);
		}
		
		if (classCha.getSkillName (4, 4) != "") {
			GameObject.Find ("Skill5").SetActive (true);
			GameObject.Find ("Skill5").GetComponent<Toggle> ().GetComponentInChildren<Text> ().text = classCha.getSkillName (4, 4);
		} else {
			GameObject.Find ("Skill5").SetActive (false);

		}
	}

	public void change(int a, int b)
	{
		if(Ranks [a,b] == true )
		{ //--Ranks
			aA = -1;
			bB = -1;
			if(ArtPoints != classCha.getArts(0)){
				Ranks [a,b] = false;

				if(ArtPoints==0){
					makeinteractable1();
					Prevent ();
				}

				ArtPoints++;
			}
		} else {
		
			if(Ranks [a,b] == false )
			{ //++Ranks
				aA = a;
				bB = b;
				if( ArtPoints > 0 ){
					Ranks [a,b] = true;
					ArtPoints--;
					if(ArtPoints==0){
						makeNOTinteractable1();
					}
				}
			}
		}



		GameObject.Find ("RemainingSkillPointsText").GetComponent<Text>().text = ArtPoints + "";
	}

	public void Prevent(){

		if (classCha.getArts (1) == 0) {
			for (int i = 0; i < rank2.Length; i++) {
				if(Ranks[1,i] == false){
					rank2[i].interactable = false;
				}
			}
		}

		if (classCha.getArts (2) == 0) {
			for (int i = 0; i < rank3.Length; i++) {
				if(Ranks[2,i] == false){
					rank3[i].interactable = false;
				}
			}
		}

		if (classCha.getArts (3) == 0) {
			for (int i = 0; i < rank4.Length; i++) {
				if(Ranks[3,i] == false){
					rank4[i].interactable = false;
				}
			}
		}
		if (classCha.getArts (4) == 0) {
			for (int i = 0; i < rank5.Length; i++) {
				if(Ranks[4,i] == false){
					rank5[i].interactable = false;
				}
			}
		}
	}

	public void makeNOTinteractable1() {//not working


		for (int i = 0; i < rank1.Length; i++) {
				if(Ranks[0,i] == false){
					rank1[i].interactable = false;
				}
		}

	
		for (int i = 0; i < rank2.Length; i++) {
			if(Ranks[1,i] == false){
				rank2[i].interactable = false;
			}
		}


		
		for (int i = 0; i < rank3.Length; i++) {
			if(Ranks[2,i] == false){
				rank3[i].interactable = false;
			}
		}

	
		
		for (int i = 0; i < rank4.Length; i++) {
			if(Ranks[3,i] == false){
				rank4[i].interactable = false;
			}
		}

	
		
		for (int i = 0; i < rank5.Length; i++) {
			if(Ranks[4,i] == false){
				rank5[i].interactable = false;
			}
		}
		
	}

	public void makeinteractable1() {//not working
		

		for (int i = 0; i < rank1.Length; i++) {
			if(Ranks[0,i] == false){
				rank1[i].interactable = true;
			}
		}
		
	
		for (int i = 0; i < rank2.Length; i++) {
			if(Ranks[1,i] == false){
				rank2[i].interactable = true;
			}
		}
		

		
		for (int i = 0; i < rank3.Length; i++) {
			if(Ranks[2,i] == false){
				rank3[i].interactable = true;
			}
		}
		

		
		for (int i = 0; i < rank4.Length; i++) {
			if(Ranks[3,i] == false){
				rank4[i].interactable = true;
			}
		}
		
	
		for (int i = 0; i < rank5.Length; i++) {
			if(Ranks[4,i] == false){
				rank5[i].interactable = true;
			}
		}
		
	}
	
	public void onValueChanged11()
	{
		change (0, 0);
		print ("lal");
	}
	
	public void onValueChanged12()
	{
		change (0, 1);
		print ("lal");
	}
	
	public void onValueChanged13()
	{
		change (0, 2);
		print ("lal");
	}
	
	public void onValueChanged14()
	{
		change (0, 3);
		print ("lal");
	}
	
	public void onValueChanged15()
	{
		change (0, 4);
		print ("lal");
	}
	
	
	public void onValueChanged21()
	{
		change (1, 0);
		print ("Clouuuudy");
	}
	
	public void onValueChanged22()
	{
		change (1, 1);
		print ("lal");
	}
	
	public void onValueChanged23()
	{
		change (1, 2);
		print ("lal");
	}
	
	public void onValueChanged24()
	{
		change (1, 3);
		print ("lal");
	}
	
	public void onValueChanged25()
	{
		change (1, 4);
		print ("lal");
	}
	
	public void onValueChanged31()
	{
		change (2, 0);
		print ("lal");
	}
	
	public void onValueChanged32()
	{
		change (2, 1);
		print ("lal");
	}
	
	public void onValueChanged33()
	{
		change (2, 2);
		print ("lal");
	}
	
	public void onValueChanged34()
	{
		change (2, 3);
		print ("lal");
	}
	
	public void onValueChanged35()
	{
		change (2, 4);
		print ("lal");
	}
	
	public void onValueChanged41()
	{
		change (3, 0);
		print ("lal");
	}
	
	public void onValueChanged42()
	{
		change (3, 1);
		print ("lal");
	}
	
	public void onValueChanged43()
	{
		change (3, 2);
		print ("lal");
	}
	
	public void onValueChanged44()
	{
		change (3, 3);
		print ("lal");
	}
	
	public void onValueChanged45()
	{
		change (3, 4);
		print ("lal");
	}
	
	public void onValueChanged51()
	{
		change (4, 0);
		print ("lal");
	}
	
	public void onValueChanged52()
	{
		change (4, 1);
		print ("lal");
	}
	
	public void onValueChanged53()
	{
		change (4, 2);
		print ("lal");
	}
	
	public void onValueChanged54()
	{
		change (4, 3);
		print ("lal");
	}
	
	public void onValueChanged55()
	{
		change (4, 4);
		print ("lal");
	}

	//avatars

	public void onAvatarChanged1()
	{
		Avatar = "av1";
	}

	public void onAvatarChanged2()
	{
		Avatar = "av2";
	}
	
	public void onAvatarChanged3()
	{
		Avatar = "av3";
	}

	public void onAvatarChanged4()
	{
		Avatar = "av4";
	}

	public void onAvatarChanged5()
	{
		Avatar = "av5";
	}

	public void onAvatarChanged6()
	{
		Avatar = "av6";
	}

	public void onAvatarChanged7()
	{
		Avatar = "av7";
	}

	public void onAvatarChanged8()
	{
		Avatar = "av8";
	}

	public void onAvatarChanged9()
	{
		Avatar = "av9";
	}

	public void onAvatarChanged10()
	{
		Avatar = "av10";
	}

	public void onAvatarChanged11()
	{
		Avatar = "av11";
	}

	public void onAvatarChanged12()
	{
		Avatar = "av12";
	}

	//Interactions on part of equ 

	public void onPartofBodyClick()
	{
		heads.SetActive (true);
		chests.SetActive (false);
		boots.SetActive (false);
		weapons.SetActive (false);

	}
	public void onPartofBodyClick1()
	{
		heads.SetActive (false);
		chests.SetActive (true);
		boots.SetActive (false);
		weapons.SetActive (false);
		
	}

	public void onPartofBodyClick2()
	{
		heads.SetActive (false);
		chests.SetActive (false);
		boots.SetActive (true);
		weapons.SetActive (false);
		
	}

	public void onPartofBodyClick3()
	{
		heads.SetActive (false);
		chests.SetActive (false);
		boots.SetActive (false);
		weapons.SetActive (true);
		
	}



	//Interaction with equ elements

	public void BlockItems(){
		int i;

		if (GoldDD > 40) {

			for(i = 0; i < HelmettoggleGroup.Length; i++){
				HelmettoggleGroup[i].interactable = true;
			}
			
			for(i = 0; i < ChesttoggleGroup.Length; i++){
				ChesttoggleGroup[i].interactable = true;
			}
			
			for( i = 0; i < BootstoggleGroup.Length; i++){
				BootstoggleGroup[i].interactable = true;
			}
			
			for(i = 0; i < WeapontoggleGroup.Length; i++){
				WeapontoggleGroup[i].interactable = true;
			}
		} else {

			if (GoldDD > 20 && GoldDD <= 40) {
				HelmettoggleGroup[1].interactable = true;
				HelmettoggleGroup[4].interactable = true;
				HelmettoggleGroup[2].interactable = false;
				HelmettoggleGroup[5].interactable = false;

				ChesttoggleGroup[1].interactable = true;
				ChesttoggleGroup[4].interactable = true;
				ChesttoggleGroup[2].interactable = false;
				ChesttoggleGroup[5].interactable = false;

				BootstoggleGroup[1].interactable = true;
				BootstoggleGroup[4].interactable = true;
				BootstoggleGroup[2].interactable = false;
				BootstoggleGroup[5].interactable = false;

				WeapontoggleGroup[1].interactable = true;
				WeapontoggleGroup[4].interactable = true;
				WeapontoggleGroup[2].interactable = false;
				WeapontoggleGroup[5].interactable = false;
			} else {

				if (GoldDD > 0 && GoldDD <= 20) {
					HelmettoggleGroup[1].interactable = false;
					HelmettoggleGroup[4].interactable = false;
					HelmettoggleGroup[2].interactable = false;
					HelmettoggleGroup[5].interactable = false;
					
					ChesttoggleGroup[2].interactable = false;
					ChesttoggleGroup[5].interactable = false;
					ChesttoggleGroup[1].interactable = false;
					ChesttoggleGroup[4].interactable = false;
					
					BootstoggleGroup[2].interactable = false;
					BootstoggleGroup[5].interactable = false;
					BootstoggleGroup[1].interactable = false;
					BootstoggleGroup[4].interactable = false;
					
					WeapontoggleGroup[2].interactable = false;
					WeapontoggleGroup[5].interactable = false;
					WeapontoggleGroup[1].interactable = false;
					WeapontoggleGroup[4].interactable = false;
				} else {
			

					if (GoldDD == 0) {

						for(i = 0; i < HelmettoggleGroup.Length; i++){
							HelmettoggleGroup[i].interactable = false;
						}

						for(i = 0; i < ChesttoggleGroup.Length; i++){
							ChesttoggleGroup[i].interactable = false;
						}

						for(i = 0; i < BootstoggleGroup.Length; i++){
							BootstoggleGroup[i].interactable = false;
						}

						for(i = 0; i < WeapontoggleGroup.Length; i++){
							WeapontoggleGroup[i].interactable = false;
						}

					}
				}
			}
		}
		if(Equ[0]!=null)
			HelmettoggleGroup[Equ[0].itemDD].interactable = true;

		if(Equ[1]!=null)
			ChesttoggleGroup[Equ[1].itemDD].interactable = true;

		if(Equ[2]!=null)
			BootstoggleGroup[Equ[2].itemDD].interactable = true;

		if(Equ[3]!=null)
			WeapontoggleGroup[Equ[3].itemDD].interactable = true;
	}
	//Chest

	public void tryEqu1(Item a, int index){
	
		if(Equ[index] != null ){
			if (Equ [index].getName () == a.getName ()) {

				GoldDD = GoldDD + Equ[index].getCost();
				Equ[index] = null;
			} else {
				if(Equ [index].getName () != a.getName ()){

					GoldDD += Equ[index].getCost() - a.getCost();
					Equ[index] = a;
				}
			}
		} else {
			if(Equ[index] == null ){

				GoldDD -= a.getCost();
				Equ[index] = a;
			}
		}

		RefreshGold ();
	}
	
	public void onToggleChest1()
	{
		Chest a = new Chest (0);
		tryEqu1 (a, 1);
	}
	
	public void onToggleChest2()
	{
		Chest a = new Chest (1);
		tryEqu1 (a , 1);
	}
	
	public void onToggleChest3()
	{
		Chest a = new Chest (2);
		tryEqu1 (a, 1);
	}
	
	public void onToggleChest4()
	{
		Chest a = new Chest (3);
		tryEqu1 (a ,1);
	}
	
	public void onToggleChest5()
	{
		Chest a = new Chest (4);
		tryEqu1 (a ,1);
	}
	
	
	public void onToggleChest6()
	{
		Chest a = new Chest (5);
		tryEqu1 (a, 1);
	}
//BOoots
	public void onToggleBoots1()
	{
		Boots a = new Boots (0);
		tryEqu1 (a, 2);
	}
	
	public void onToggleBoots2()
	{
		Boots a = new Boots (1);
		tryEqu1 (a, 2);
	}
	
	public void onToggleBoots3()
	{
		Boots a = new Boots (2);
		tryEqu1 (a, 2);
	}
	
	public void onToggleBoots4()
	{
		Boots a = new Boots (3);
		tryEqu1 (a, 2);
	}
	
	public void onToggleBoots5()
	{
		Boots a = new Boots (4);
		tryEqu1 (a, 2);
	}
	
	
	public void onToggleBoots6()
	{
		Boots a = new Boots (5);
		tryEqu1 (a, 2);
	}

	//Helmet
	public void onToggleHelmet1()
	{
		Helmet a = new Helmet (0);
		tryEqu1 (a, 0);
	}
	
	public void onToggleHelmet2()
	{
		Helmet a = new Helmet (1);
		tryEqu1 (a, 0);
	}
	
	public void onToggleHelmet3()
	{
		Helmet a = new Helmet (2);
		tryEqu1 (a, 0);
	}
	
	public void onToggleHelmet4()
	{
		Helmet a = new Helmet (3);
		tryEqu1 (a, 0);
	}
	
	public void onToggleHelmet5()
	{
		Helmet a = new Helmet (4);
		tryEqu1 (a, 0);
	}
	
	
	public void onToggleHelmet6()
	{
		Helmet a = new Helmet (5);
		tryEqu1 (a, 0);
	}

	//	Weapon
	public void onToggleWeapont1()
	{
		Weapon a = new Weapon (0);
		tryEqu1 (a, 3);
	}
	
	public void onToggleWeapon2()
	{
		Weapon a = new Weapon (1);
		tryEqu1 (a, 3);
	}
	
	public void onToggleWeapon3()
	{
		Weapon a = new Weapon (2);
		tryEqu1 (a, 3);
	}
	
	public void onToggleWeapon4()
	{
		Weapon a = new Weapon (3);
		tryEqu1 (a, 3);
	}
	
	public void onToggleWeapon5()
	{
		Weapon a = new Weapon (4);
		tryEqu1 (a, 3);
	}
	
	
	public void onToggleWeapon6()
	{
		Weapon a = new Weapon (5);
		tryEqu1 (a, 3);
	}

}
