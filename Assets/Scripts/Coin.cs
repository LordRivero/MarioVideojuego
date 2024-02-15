using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; //Valor de la moneda.

    private void OnTriggerEnter2D(Collider2D other) //M�todo para detectar cuando el jugador entra en contacto con la moneda.
    {
        if (other.gameObject.GetComponent<PlayerMovement>()) //Comprueba si el objeto que colisiona es el jugador.
        {
            CollectCoin(); //Lllama a la funci�n para recolectar la moneda.
        }
    }
   
    private void CollectCoin() //M�todo para recolectar la moneda.
    {
        gameObject.SetActive(false);
    }
}
