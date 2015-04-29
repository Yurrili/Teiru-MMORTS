using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TabEntermainMenu : MonoBehaviour {
	public GameObject loginButton;
	public InputField inputField;
	public InputField inputFieldUsername;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.KeypadEnter) || Input.GetKey ("enter") || (Input.GetKey (KeyCode.Return)))
		{
			print ("enter");
			ExecuteEvents.Execute (loginButton, new PointerEventData (EventSystem.current), ExecuteEvents.pointerClickHandler);
		} 
		else if (Input.GetKey (KeyCode.Tab) || Input.GetKeyDown (KeyCode.Tab)) 
		{
			if (inputFieldUsername.isFocused)
			{
			print ("rab");
			EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
			inputField.OnPointerClick(new PointerEventData(EventSystem.current));
			}
		}
	}
}
