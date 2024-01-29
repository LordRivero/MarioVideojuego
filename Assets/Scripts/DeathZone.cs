using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement pm = collision.GetComponent<PlayerMovement>();
        if (pm)
        {
            //es el player
            pm.ResetPlayer();
        }
        else
        {
            //es cualquier otra cosa
            Destroy(collision.gameObject);
        }
    }
}
