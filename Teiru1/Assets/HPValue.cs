using UnityEngine;
using System.Collections;

public class HPValue {

	private int CurrentHP; // obecne HP
	private int MAXHP; //laczna ilosc HP z efektami 
	private int HPmod; // modyfikator HP;
	private int HPBasic;// podstawowe HP wyliczone
	private int BonusHP;//bonusowe HP
	
	public HPValue(int basic){
		HPmod = basic;// + mod
		BonusHP = 0;
		CalculateHP ();
		CurrentHP = HPBasic;
	}


	private void CalculateHP(){//to bedzie trzeba przetestowac dobrze
		HPBasic = HPmod;
		MAXHP = HPBasic + BonusHP;
	}
	
	public void setHPmod(int mod){
		HPmod = mod;	
	}

	public int getMAXHP(){
		return MAXHP;
	}

	public int getCurrentHP(){
		return CurrentHP;
	}
	
	public void setMaxHP(int max){
		int temp = MAXHP - max;
		MAXHP = max;
		CurrentHP += temp;
	}

	public void setBonusHP(int bonus){
		BonusHP = bonus;
		CalculateHP ();
	}

	public string getState(){

		if (CurrentHP > 0) {
			return " alive ";	
		} else {

			if(CurrentHP == 0){
				return " wounded"; //W każdej turze postać może wykonać tylko jedną akcję ruchu lub akcję standardową 
									//(ale nie obie i nie ma prawa do akcji Po zakończeniu działania postać otrzymuje jedną ranę.
			}	else {

				if(CurrentHP < 0 && CurrentHP >= -9){
					return " dying"; // Umierający bohater natychmiast traci przytomność i nie może wykonywać żadnych 		akcji.
										//Umierający bohater w każdej rundzie traci 1 punkt wytrzymałości,
				}	else {
					return " dead "; // Kiedy aktualne punkty wytrzymałości bohatera spadną do wartości –10 , umiera. 
									//I przestaje brać udział w pojedynku, nie może zostać już uleczony.
				}

			}
		}
	}

	public void Heal(int add){

		if (CurrentHP <= MAXHP) {
			CurrentHP += add;

			if(CurrentHP > MAXHP){
				CurrentHP = MAXHP;
			}
				
		}
	}

	public string Hit(int damage){
		CurrentHP -= damage;
			return getState ();
	}
}
