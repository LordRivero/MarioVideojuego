using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; //Valor de la moneda.

    private void OnTriggerEnter2D(Collider2D other) //Método para detectar cuando el jugador entra en contacto con la moneda.
    {
        if (other.gameObject.GetComponent<PlayerMovement>()) //Comprueba si el objeto que colisiona es el jugador.
        {
            CollectCoin(); //Lllama a la función para recolectar la moneda.
        }
    }
   
    private void CollectCoin() //Método para recolectar la moneda.
    {
        gameObject.SetActive(false);
    }
}
