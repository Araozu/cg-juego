using System;
using System.Collections;
using UnityEngine;

public class MonitorGameCamp : MonoBehaviour
{
    public float sensitivity = 10.0f;

    // rotacion en el frame anterior
    private Vector3? _rotacionInicial = null;

    //Datos de entrada
    public float fuerza = 1;
    private Vector2 _mouseDelta = Vector2.zero;
    private Vector2 _amount = Vector2.zero;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Asi clic en la tecla espacio reiniciamos la rotacion
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _amount = Vector2.zero;
        }

        ComputeRotationWithSensor();
    }

    private void ComputeRotationWithSensor()
    {
        var rotationActual = Fix(DeviceRotation.Get().eulerAngles);

        // La rotacion en el frame inicial es el punto de referencia
        if (_rotacionInicial == null)
        {
            _rotacionInicial = rotationActual;
            return;
        }

        var diferenciaRotacion = Dif(_rotacionInicial.Value, rotationActual);

        if (diferenciaRotacion.x is <= 1 and >= -1 
            && diferenciaRotacion.y is <= 1 and >= -1 
            && diferenciaRotacion.z is <= 1 and >= -1
            )
        {
            return;
        }

        // Debug.Log( _rotacionInicial + " : " + rotationActual + " - " + diferenciaRotacion);

        _rigidbody.AddForce(diferenciaRotacion * fuerza, ForceMode.Acceleration);
    }

    // Convierte espacio del celular a espacio de Unity
    private static Quaternion GyroToUnity(Quaternion q)
    {
        return Quaternion.Euler(90, 0, 0) * new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    private static Vector3 Fix(Vector3 input)
    {
        var x = input.x;
        var z = input.z;

        if (x > 180)
        {
            x = (x - 180) - 180;
        }
        if (x < -180)
        {
            x = (180 - x) + 180;
        }

        if (z > 180)
        {
            z = (z - 180) - 180;
        }
        if (z < -180)
        {
            z = (180 - z) + 180;
        }

        return new Vector3(z, 0, -x);
    }
    
    private static Vector3 Dif(Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.x - v2.x, 0, v1.z - v2.z);
    }

}
