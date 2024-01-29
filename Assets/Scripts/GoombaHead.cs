using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaHead : MonoBehaviour
{
    public float impulse;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();
        if (playerMovement) 
        {
           playerMovement.Jump(impulse);
            transform.parent.GetComponent<GoombaBehavior>().StartDeath();
            transform.parent.GetComponent<GoombaBehavior>().enabled = false;
            //Destroy(transform.parent.gameObject);
        }
    }
}
