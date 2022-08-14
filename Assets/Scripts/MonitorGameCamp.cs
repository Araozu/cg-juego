using UnityEngine;

/**
 * Este script maneja la rotacion de un GameObject usando el giroscopio.
 * Se debe colocar en un Game Object que tenga como hijos:
 * - El mapa, para rotarlo
 * - La camara, para rotarla junto con el mapa y dar sensacion 2d
 */
public class MonitorGameCamp : MonoBehaviour
{
    public float sensitivity = 10.0f;

    // rotacion en el frame anterior
    private Quaternion _rotacionAnterior;

    //Datos de entrada
    private Vector2 _mouseDelta = Vector2.zero;
    private Vector2 _amount = Vector2.zero;
    public float limitMinY = -45;
    public float limitMaxY = 45;
    public float limitMinX = -45;
    public float limitMaxX = 45;

    private void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    private void Update()
    {
        //Asi clic en la tecla espacio reiniciamos la rotacion
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _amount = Vector2.zero;
        }

        ComputeRotationWithSensor();
    }

    private void ComputeRotationWithMouse()
    {
        //Asignamos a mouseDelta los desplazamientos del raton en cada cuadro de animacion  
        _mouseDelta.Set(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        //Escalamos ese desplazamiento con la sensitivity y acumulamos
        _amount += _mouseDelta * sensitivity;
        // Tambien estamos restringiendo el giro en alguno de el eje y
        _amount.y = (_amount.y > 180) ? _amount.y - 360 : _amount.y;
        _amount.y = Mathf.Clamp(_amount.y, limitMinY, limitMaxY);
        // Tambien estamos restringiendo el giro en alguno de el eje x
        _amount.x = (_amount.x > 180) ? _amount.x - 360 : _amount.x;
        _amount.x = Mathf.Clamp(_amount.x, limitMinX, limitMaxX);

        //Creamos rotacion en el eje horizontal, vertical y lueg lo juntamos
        transform.rotation = Quaternion.AngleAxis(_amount.y, Vector3.up) * Quaternion.AngleAxis(_amount.x, Vector3.back);
    }

    private void ComputeRotationWithSensor()
    {
        var gyro = GyroToUnity(Input.gyro.attitude);

        // Actualizar la rotacion segun el cambio, no la posicion del sensor
        // Diferencia entre quaternion anterior y quaternion nuevo
        var nuevaRotacion = _rotacionAnterior * Quaternion.Inverse(gyro);

        if (nuevaRotacion.x <= 0 && nuevaRotacion.y <= 0 && nuevaRotacion.z <= 0 && nuevaRotacion.w <= 0)
        {
            return;
        }

        // Sumar la diferencia entre rotaciones a la rotacion del game object si hay rotacion
        Debug.Log("Dif:" + nuevaRotacion);
        transform.rotation *= nuevaRotacion;
    }

    // Convierte espacio del celular a espacio de Unity
    private static Quaternion GyroToUnity(Quaternion q)
    {
        return Quaternion.Euler(90, 0, 0) * new Quaternion(q.x, q.y, -q.z, -q.w);
    }

}
