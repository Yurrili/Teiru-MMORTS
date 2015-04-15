using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DBManager : MonoBehaviour {
	
	public InputField username ,email,password , password2;
	public Text errorText;
	public Menu CurrentMenu;
	
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

	public void RegisterButtonClicked(Menu menu)
	{
		string usernameStr = username.text.ToString ();
		string passwordStr = password.text.ToString ();
		string password2Str = password2.text.ToString ();
		string emailStr = email.text.ToString ();
		if (usernameStr == "" || passwordStr == "" || password2Str == "" || emailStr == "") 
		{
			errorText.text = "There is some empty fields, please try again";

		}
		else
		{
			if (password2Str==passwordStr)
			{
				WWWForm form = new WWWForm();
				form.AddField("username",usernameStr);
				form.AddField("password",passwordStr);
				form.AddField("email",emailStr);
				WWW w = new WWW("http://localhost/tutorial/register.php",form);
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
			errorText.text = "Return";

		}
		else
		{
			errorText.text = "Not return";

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
