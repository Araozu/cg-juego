using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
   public GameObject functions;
   
   public void Cargar(){
   	SceneManager.LoadScene("RotacionCampo");
   	functions.GetComponent<GuardarPersonaje>().Guardar();
   }
   
   public void Retroceder(){
   	SceneManager.LoadScene("ElegirPersonaje");
   }
   
}
