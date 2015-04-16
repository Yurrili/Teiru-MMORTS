using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DBManager : MonoBehaviour {
	
	public InputField username ,email,password , password2;
	public InputField loginUsername, loginPassword;
	public Text errorText,txtLoginMessage;
	private Menu CurrentMenu;
	
	void Start () 
	{
		//username = GameObject.Find ("UsernameReg").GetComponentInChildren<Text>();
		//email = GameObject.Find ("Email").GetComponentInChildren<Text>();
		//password = GameObject.Find ("Password").GetComponentInChildren<Text>();
		//password2 = GameObject.Find ("Password2").GetComponentInChildren<Text>();
		//errorText = GameObject.Find ("Password2").GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoginButtonClicked(Menu menu)
	{
		CurrentMenu = menu;
		WWWForm form = new WWWForm();
		form.AddField("username", loginUsername.text.ToString());
		print (loginUsername.text.ToString());
		form.AddField("password",loginPassword.text.ToString());
		WWW w = new WWW("http://f12-preview.awardspace.net/teiru.ac.dx/login.php",form);
		StartCoroutine(login (w));
	}

	IEnumerator login(WWW w)
	{

		yield return w;

		if (w.error == null) 
		{
			if(w.text == "login-SUCCESS")
			{
				txtLoginMessage.text = "Successfully logged in";
				//	ShowMenu (menu);
			}		
		}
		else
		{
			txtLoginMessage.text = "Login failed";
			
		}
	}


	public void RegisterButtonClicked(Menu menu)
	{
		CurrentMenu = menu;
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
			//	ShowMenu (menu);
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
			errorText.text = "Successfully registered";

		}
		else
		{
			errorText.text = "Registration failed";

		}
	}

	public void ShowMenu(Menu menu)
	{
		if (CurrentMenu != null)
			CurrentMenu.isOpen = false;
		
		CurrentMenu = menu;
		CurrentMenu.isOpen = true;
	}



}
