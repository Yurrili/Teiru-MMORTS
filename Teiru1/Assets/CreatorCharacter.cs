using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreatorCharacter : MonoBehaviour {

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
	//

	public Toggle[] rank1; 
	public Toggle[] rank2;
	public Toggle[] rank3;
	public Toggle[] rank4;
	public Toggle[] rank5;
	
	public CharacterStats stats = new CharacterStats (); //statystyki
	public CharacterClass classCha; // element  postaci
	public int Characterchooseclass; // wybor klasy postaci

	void Start () 
	{
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
	}
	
	// Update is called once per frame
	void Update () {
		
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
	
	public void DecreaseCHA(){ //testowane
		
		CHA.text = stats.decreaseCHA().ToString();
		PTS.text = stats.getPTS ().ToString ();
	}
	
	public void DecreaseInt(){ //testowane
		
		INT.text = stats.decreaseINT().ToString();
		PTS.text = stats.getPTS().ToString();
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
			print ("Ranger");
			break;
		case 2:
			classCha = new CharacterClass_Mage(stats.getCON());
			ClassYou.text = "Mage";
			print ("Mage");
			break;
		case 3:
			classCha = new CharacterClass_Knight(stats.getCON());
			ClassYou.text = "Knight";
			print ("Knight");
			break;
		case 4:
			classCha = new CharacterClass_Mystiq(stats.getCON());
			ClassYou.text = "Mystic";
			print ("Mystic");
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
			
			GameObject.Find ("STRTextPlace").GetComponent<Text>().text = stats.getSTR() + "";
			GameObject.Find ("DEXTextPlace").GetComponent<Text>().text = stats.getDEX() + "";
			GameObject.Find ("CONTextPlace").GetComponent<Text>().text = stats.getCON() + "";
			GameObject.Find ("INTTextPlace").GetComponent<Text>().text = stats.getINT() + "";
			GameObject.Find ("WISTextPlace").GetComponent<Text>().text = stats.getWIS() + "";
			GameObject.Find ("CHATextPlace").GetComponent<Text>().text = stats.getCHA() + "";
			

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

	public void change(int a, int b){

		if(Ranks [a,b] == true ){ //--Ranks
			if(ArtPoints != classCha.getArts(0)){
				Ranks [a,b] = false;

				if(ArtPoints==0){
					makeinteractable1();
					Prevent ();
				}

				ArtPoints++;
			}
		} else {
		
			if(Ranks [a,b] == false ){ //++Ranks
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
	

}
