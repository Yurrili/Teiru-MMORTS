﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DBManager : MonoBehaviour {
	
	public InputField username ,email,password , password2;
	public InputField loginUsername, loginPassword;
	public Text errorText,txtLoginMessage;
	public Menu LogedMenu, MainMenu;
	public string loggedInUser;
	
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void createnewCharacter(Menu menu)
	{
		WWWForm form = new WWWForm();
		form.AddField ("username",loggedInUser);
		print (loggedInUser);
		form.AddField ("name",GameObject.Find ("NameTAG").GetComponent<InputField>().textComponent.text);
		form.AddField ("class", CreatorCharacter.Characterchooseclass);
		form.AddField ("level", 1);
		form.AddField ("str",CreatorCharacter.stats.getSTR());
		form.AddField ("dex",CreatorCharacter.stats.getDEX());
		form.AddField ("con",CreatorCharacter.stats.getCON());
		form.AddField ("int",CreatorCharacter.stats.getINT ());
		form.AddField ("wis",CreatorCharacter.stats.getWIS());
		form.AddField ("cha",CreatorCharacter.stats.getCHA());
		form.AddField ("helm", "helmo");
		form.AddField ("chest", "chesto");
		form.AddField ("sword", "tiesto");
		form.AddField ("boot", "franczesto");
		form.AddField ("avatar", "av1"); //CreatorCharacter.Avatar);
		form.AddField ("skills", CreatorCharacter.classCha.getSkillName(CreatorCharacter.aA, CreatorCharacter.bB) );
		WWW w = new WWW("http://f12-preview.awardspace.net/teiru.ac.dx/charCreate.php",form);
		StartCoroutine(createChar(w));
	}

	IEnumerator createChar(WWW w)
	{
		yield return w;
		if (w.error == null) 
		{
			print("Successfully created character");
		}
		else
		{
			print("Registration failed");
			
		}
	}

	public void LoginButtonClicked(Menu menu)
	{
		loggedInUser = loginUsername.text.ToString ();
		WWWForm form = new WWWForm();
		form.AddField("username", loggedInUser);
		form.AddField("password",loginPassword.text.ToString());
		WWW w = new WWW("http://f12-preview.awardspace.net/teiru.ac.dx/login.php",form);
		StartCoroutine(login (w, LogedMenu));

	}

	IEnumerator login(WWW w, Menu menu)
	{

		yield return w;
		if (w.error == null) 
		{
			if(w.text == "login-SUCCESS")
			{
				txtLoginMessage.text = "Successfully logged in";
				ShowMenu (menu);
				txtLoginMessage.text = "";
				loginUsername.text = "";
				loginPassword.text  = "";
				MenuManager.HideRegistrationButton();
			}
			else 
			{
				txtLoginMessage.text = w.text;
			}
		}
		else
		{
			txtLoginMessage.text = "Login failed";
			
		}
	}


	public void RegisterButtonClicked(Menu menu)
	{
	//	CurrentMenu = menu;
		string usernameStr = username.text.ToString ();
		string passwordStr = password.text.ToString ();
		string password2Str = password2.text.ToString ();
		string emailStr = email.text.ToString ();
		if (usernameStr == "" || passwordStr == "" || password2Str == "" || emailStr == "") 
		{
			errorText.text = "There is some empty fields, please try again";

		}
		else if (usernameStr.Length<4)
		{
			errorText.text = "Your username is too short";
		}
		else if (passwordStr.Length<5)
		{
			errorText.text = "Your password is too short";
		}
		else
		{
			if (password2Str==passwordStr)
			{
				WWWForm form = new WWWForm();
				form.AddField("username",usernameStr);
				form.AddField("password",passwordStr);
				form.AddField("email",emailStr);
				WWW w = new WWW("http://f12-preview.awardspace.net/teiru.ac.dx/register.php",form);
				StartCoroutine(register (w));
				

				errorText.text = "";
				username.text = "";
				password.text  = "";
				password2.text  = "";
				email.text  = "";
			}
			else
			{
				errorText.text = "Passwords don't match, please try again";
			}
		}
	}

	//read response
	IEnumerator register(WWW w)
	{
		yield return w;
		if (w.error == null) 
		{
			txtLoginMessage.text = "Successfully registered";
			ShowMenu (MainMenu);
			MenuManager.HideBackButton();
			MenuManager.ShowRegistrationButton();
		}
		else
		{
			errorText.text = "Registration failed";

		}
	}

	public void ShowMenu(Menu menu)
	{
		if (MenuManager.getCurrentMenu() != null)
			MenuManager.setCurrentMenuOpenFalse();
		
		MenuManager.setCurrentMenu(menu);
		MenuManager.setCurrentMenuOpenTrue ();
	}



}
