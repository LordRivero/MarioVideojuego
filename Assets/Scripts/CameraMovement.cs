using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target; //Referncia al target, el personaje.
    public float smoothSpeed = 0.125f; //Velocidad de suavizado.

    private void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z); //Calcula la posición deseada de la cámara.

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime); //Interpola suavemente la posicion actual de la camara hacia la posición deseada.

        transform.position = desiredPosition; //Actualiza la posicion de la cámara.
    }
}
    //void Update()
    //{
        //transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
    //}
//}
