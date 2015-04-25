using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnHoverEventsBitch : MonoBehaviour {

	Text text;
	// Use this for initialization
	void Start () 
	{

		text = GameObject.Find ("AboutSkill").GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onToggle11IsEntered()
	{
		text.text = "OLOLO";
	}

	public void onToggle12IsEntered()
	{
		text.text = "OLOLO2222";
	}

	public void onToggle13IsEntered()
	{
		text.text = "Gustaw Ober Folksdojtcz";
	}
}
