using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorGameCamp : MonoBehaviour
{
	public float sensitivity=10.0f;
	//Datos de entrada
	Vector2 mouseDelta=Vector2.zero;
	Vector2 amount=Vector2.zero;
	public float limitMinY=-45;
	public float limitMaxY=45;
	public float limitMinX=-45;
	public float limitMaxX=45;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //Asi clic en la tecla espacio reiniciamos la rotacion
    if(Input.GetKeyUp(KeyCode.Space)){amount=Vector2.zero;}
    //Asignamos a mouseDelta los desplazamientos del raton en cada cuadro de animacion  
    mouseDelta.Set(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y"));
    //Escalamos ese desplazamiento con la sensitivity y acumulamos
    amount +=mouseDelta*sensitivity;
    // Tambien estamos restringiendo el giro en alguno de el eje y
    amount.y=(amount.y>180)?amount.y-360:amount.y;
    amount.y=Mathf.Clamp(amount.y,limitMinY,limitMaxY);
    // Tambien estamos restringiendo el giro en alguno de el eje x
    amount.x=(amount.x>180)?amount.x-360:amount.x;
    amount.x=Mathf.Clamp(amount.x,limitMinX,limitMaxX);
    //Creamos rotacion en el eje horizontal, vertical y lueg lo juntamos
    transform.rotation=Quaternion.AngleAxis(amount.y, Vector3.up)*Quaternion.AngleAxis(amount.x,Vector3.back);
        
    }
}
