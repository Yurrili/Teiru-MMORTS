using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class OnHoverEventsItem : MonoBehaviour {


	public Text AboutItem;
	Text Desctext;

	void Start () 
	{

		AboutItem = GameObject.Find ("AboutItem").GetComponentInChildren<Text>();
	
	}

	//Chest

	public void onToggleChest1()
	{
		AboutItem.text = (new Chest (0)).getAllDescription();
	}

	public void onToggleChest2()
	{
		AboutItem.text = (new Chest (1)).getAllDescription();
	}

	public void onToggleChest3()
	{
		AboutItem.text = (new Chest (2)).getAllDescription();
	}

	public void onToggleChest4()
	{
		AboutItem.text = (new Chest (3)).getAllDescription();
	}

	public void onToggleChest5()
	{
		AboutItem.text = (new Chest (4)).getAllDescription();
	}

	
	public void onToggleChest6()
	{
		AboutItem.text = (new Chest (5)).getAllDescription();
	}

	//Helmet

	public void onToggleHelmet1()
	{
		AboutItem.text = (new Helmet (0)).getAllDescription();
	}
	
	public void onToggleHelmet2()
	{
		AboutItem.text = (new Helmet (1)).getAllDescription();
	}
	
	public void onToggleHelmet3()
	{
		AboutItem.text = (new Helmet (2)).getAllDescription();
	}
	
	public void onToggleHelmet4()
	{
		AboutItem.text = (new Helmet (3)).getAllDescription();
	}
	
	public void onToggleHelmet5()
	{
		AboutItem.text = (new Helmet (4)).getAllDescription();
	}
	
	
	public void onToggleHelmet6()
	{
		AboutItem.text = (new Helmet (5)).getAllDescription();
	}


	//Boots

	
	public void onToggleBoots1()
	{
		AboutItem.text = (new Boots (0)).getAllDescription();
	}
	
	public void onToggleBoots2()
	{
		AboutItem.text = (new Boots (1)).getAllDescription();
	}
	
	public void onToggleBoots3()
	{
		AboutItem.text = (new Boots (2)).getAllDescription();
	}
	
	public void onToggleBoots4()
	{
		AboutItem.text = (new Boots (3)).getAllDescription();
	}
	
	public void onToggleBoots5()
	{
		AboutItem.text = (new Boots (4)).getAllDescription();
	}
	
	
	public void onToggleBoots6()
	{
		AboutItem.text = (new Boots (5)).getAllDescription();
	}

	//weapon

	//Helmet
	
	public void onToggleWeapon1()
	{
		AboutItem.text = (new Weapon (0)).getAllDescription();
	}
	
	public void onToggleWeapon2()
	{
		AboutItem.text = (new Weapon (1)).getAllDescription();
	}
	
	public void onToggleWeapon3()
	{
		AboutItem.text = (new Weapon (2)).getAllDescription();
	}
	
	public void onToggleWeapon4()
	{
		AboutItem.text = (new Weapon (3)).getAllDescription();
	}
	
	public void onToggleWeapon5()
	{
		AboutItem.text = (new Weapon (4)).getAllDescription();
	}
	
	
	public void onToggleWeapon6()
	{
		AboutItem.text = (new Weapon (5)).getAllDescription();
	}

}
