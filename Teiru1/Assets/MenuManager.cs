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

	public void Start()
	{
		ShowMenu (CurrentMenu);
		obj = GameObject.FindGameObjectWithTag ("Back");
		obj.SetActive (false);
		//STR = GameObject.Find ("Str").GetComponent<InputField>();
	//	DEX = GameObject.Find ("Dex").GetComponentInChildren<Text>();
	//	CON = GameObject.Find ("Con").GetComponentInChildren<Text>();
	//	INT = GameObject.Find ("Int").GetComponentInChildren<Text>();
	//	WIS = GameObject.Find ("Wis").GetComponentInChildren<Text>();
	//	CHA = GameObject.Find ("Cha").GetComponentInChildren<Text>();
	//	PTS = GameObject.Find ("PointsYouHave").GetComponentInChildren<Text>();
		PTS.text = pointsToGive.ToString();
		STR.text = "8";
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

		STR.text = "1";
	}

	public void IncreaseCHA(){
		
		CHA.text = "1";
	}

	public void IncreaseINT(){
		
		INT.text = "1";
	}

	public void IncreaseDEX(){
		
		DEX.text = "1";
	}

	public void IncreaseWIS(){
		
		WIS.text = "1";
	}

	public void IncreaseCON(){
		
		CON.text = "1";
	}

	public void DecreaseSTR(){
		
		STR.text = "1";
	}

	public void Check(Text temp )
	{
		int parsedInt = 0;
		if (int.TryParse(temp.text, out parsedInt))
		{

			if ((parsedInt-8)>0 &&(parsedInt-8)<=3) // 8-11
			{
				if (pointsToGive >= (parsedInt-8)*3)
				{
			//		Debug.Log ("1");
				pointsToGive =- (parsedInt-8)*3;
					//Debug.Log (pointsToGive);
				PTS.text = pointsToGive.ToString();
				
				}
			}
			else if ((parsedInt-8)==4) //12
			{
			//	Debug.Log ("2");
				if (pointsToGive >= 9 + 4)
				{
					pointsToGive =- 13;
					PTS.text =pointsToGive.ToString();
				}
			}
			else if ((parsedInt-8)==5)//13
			{
			//	Debug.Log ("3");
				if (pointsToGive >= 9 + 9)
				{
					pointsToGive =- 18;
					PTS.text =pointsToGive.ToString();
				}
			}
			else if ((parsedInt-8)==6)//14
			{
			//	Debug.Log ("4");
				if (pointsToGive >= 9 + 15)
				{
					pointsToGive =- 24;
					PTS.text =pointsToGive.ToString();
				}
			}
			else if ((parsedInt-8)==7)//15
			{
				Debug.Log ("5");
				if (pointsToGive >= 9 + 23)
				{
					pointsToGive =- 32;
					PTS.text = pointsToGive.ToString();
				}
			}
			else 
			{
			//	Debug.Log ("6");
				temp.text = "8";
			}

		}
		else
		{
		//	Debug.Log ("8");
			temp.text = "8";
		}
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

