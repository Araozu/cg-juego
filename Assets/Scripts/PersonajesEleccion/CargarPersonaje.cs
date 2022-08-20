using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarPersonaje : MonoBehaviour
{
    public GameObject capitanPersonaje;
    public GameObject flashPersonaje;
    public GameObject issadPersonaje;
    public GameObject peruPersonaje;
    
    public bool capitan;
    public bool flash;
    public bool issad;
    public bool peru;
    
    public void Update(){
    	capitan=PlayerPrefs.GetInt("capitanSelec")==1;
	flash=PlayerPrefs.GetInt("flashSelec")==1;
	issad=PlayerPrefs.GetInt("issadSelec")==1;
	peru=PlayerPrefs.GetInt("peruSelec")==1;
	
	if(capitan==true){
		capitanPersonaje.SetActive(true);
		Destroy(flashPersonaje);
		Destroy(issadPersonaje);
		Destroy(peruPersonaje);
	}
	if(flash==true){
		flashPersonaje.SetActive(true);
		Destroy(capitanPersonaje);
		Destroy(issadPersonaje);
		Destroy(peruPersonaje);
	}
	if(issad==true){
		issadPersonaje.SetActive(true);
		Destroy(capitanPersonaje);
		Destroy(flashPersonaje);
		Destroy(peruPersonaje);
	}
	if(peru==true){
		peruPersonaje.SetActive(true);
		Destroy(capitanPersonaje);
		Destroy(issadPersonaje);
		Destroy(flashPersonaje);
	}
		
    }
}
