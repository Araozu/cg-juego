using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarPersonaje : MonoBehaviour
{
   	public bool capitan;
	public bool flash;
	public bool issad;
	public bool peru;
   private void Awake(){
		capitan=PlayerPrefs.GetInt("capitanSelec")==1;
		flash=PlayerPrefs.GetInt("flashSelec")==1;
		issad=PlayerPrefs.GetInt("issadSelec")==1;
		peru=PlayerPrefs.GetInt("peruSelec")==1;
	}
	//Personaje por default
	private void Update(){
		if(peru==false && capitan == false && issad==false && flash==false){
		peru=true;
		}
	}
	public void CapitanPersonaje(){
		capitan=true;
		flash=false;
		issad=false;
		peru=false;
		Guardar();
	}
	
	public void FlashPersonaje(){
		capitan=false;
		flash=true;
		issad=false;
		peru=false;
		Guardar();
	}
	
	public void IssadPersonaje(){
		capitan=false;
		flash=false;
		issad=true;
		peru=false;
		Guardar();
	}
	public void PeruPersonaje(){
		capitan=false;
		flash=false;
		issad=false;
		peru=true;
		Guardar();
	}
	
	public void Guardar(){
		//Guardamos el valor de cada variable
		PlayerPrefs.SetInt("capitanSelec",capitan?1:0);
		PlayerPrefs.SetInt("flashSelec",flash?1:0);
		PlayerPrefs.SetInt("issadSelec",issad?1:0);
		PlayerPrefs.SetInt("peruSelec",peru?1:0);
	}
}

