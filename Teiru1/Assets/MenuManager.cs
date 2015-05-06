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
	public string [] values ;


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



	}

	public void Update()
	{
		if (Input.GetKey(KeyCode.KeypadEnter)  || Input.GetKey ("enter") || (Input.GetKey(KeyCode.Return)))
		{
			print ("enter");
			ExecuteEvents.Execute (loginButton, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
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

	
	public void ShowMenuCharacter(Menu menu){

		if( GameObject.Find ("CharacterButton1").GetComponentInChildren<Text>().text != "Character name" )
		{
			GetCharInformation(GameObject.Find ("CharacterButton1").GetComponentInChildren<Text>().text);
			ShowMenu(menu);
		}
	}

	public void ShowMenuCharacter1(Menu menu){
		
		if( GameObject.Find ("CharacterButton2").GetComponentInChildren<Text>().text != "Character name" )
		{
			GetCharInformation(GameObject.Find ("CharacterButton2").GetComponentInChildren<Text>().text);
			ShowMenu(menu);
		}
	}

	public void ShowMenuCharacter2(Menu menu){
		
		if( GameObject.Find ("CharacterButton3").GetComponentInChildren<Text>().text != "Character name" )
		{
			GetCharInformation(GameObject.Find ("CharacterButton3").GetComponentInChildren<Text>().text);
			ShowMenu(menu);
		}
	}

	public void ShowMenuCharacter3(Menu menu){
		
		if(GameObject.Find ("CharacterButton4").GetComponentInChildren<Text>().text!= "Character name" )
		{
			GetCharInformation(GameObject.Find ("CharacterButton4").GetComponentInChildren<Text>().text);
			ShowMenu(menu);
		}
	}
	
	public void ShowMenuCreator(Menu menu){

		if( GameObject.Find ("CharacterButton1").GetComponentInChildren<Text>().text == "Character name" )
		{
			ShowMenu(menu);
		}
	}

	public void ShowMenuCreator1(Menu menu){
		
		if( GameObject.Find ("CharacterButton2").GetComponentInChildren<Text>().text == "Character name" )
		{
			ShowMenu(menu);
		}
	}

	public void ShowMenuCreator2(Menu menu){
		
		if( GameObject.Find ("CharacterButton3").GetComponentInChildren<Text>().text == "Character name" )
		{
			ShowMenu(menu);
		}
	}

	public void ShowMenuCreator3(Menu menu){


		if( DBManager.charButtons[3].GetComponentInChildren<Text>().text == "Character name" )
		{
			ShowMenu(menu);
		}
	}

	public void GetCharInformation(string charName)
	{
		WWWForm form = new WWWForm();
		form.AddField ("username",DBManager.loggedInUser);
		form.AddField ("name",charName);
		WWW w = new WWW("http://f12-preview.awardspace.net/teiru.ac.dx/getCharacterInfo.php",form);
		StartCoroutine(getChars(w));
	}

	IEnumerator getChars(WWW w)
	{
		yield return w;
		if (w.error == null) 
		{
			string data = w.text;
			this.values = data.Split(","[0]);  
			//$row['name'] . "," . $row['class'] . "," . $row['level'] . "," . $row['str'] . "," . $row['dex'] . "," . $row['con'] . "," . $row['int'] . "," . $row['wis'] . "," . $row['cha'] . "," . $row['helm'] . "," . $row['chest'] . "," . $row['sword'] . "," . $row['boot'] . "," . $row['avatar'] . "," . $row['skills'] . ",";
		}
	}

}

