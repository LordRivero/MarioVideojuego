using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaHead : MonoBehaviour
{
    //public float impulse;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();
        if (collision.gameObject.GetComponent<PlayerMovement>()) 
        {
            Destroy(gameObject.transform.parent.gameObject);
            //playerMovement.Jump(impulse);
            //transform.parent.GetComponent<GoombaBehavior>().StartDeath();
            //transform.parent.GetComponent<GoombaBehavior>().enabled = false;
            //Destroy(transform.parent.gameObject);
        }
    }
}
