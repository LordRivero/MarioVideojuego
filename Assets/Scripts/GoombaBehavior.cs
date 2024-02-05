using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GoombaBehavior : MonoBehaviour
{
    public GameObject target;
    public float speed;

    private void Start()
    {
        target = FindObjectOfType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = 
            Vector2.MoveTowards(transform.position, new Vector2(target.transform.position.x, transform.position.y), speed * Time.deltaTime);   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
            {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<PlayerMovement>().ResetPlayer();
        }
    }

    public void StartDeath()
    {
        GetComponent<Animator>().Play("Death");
    }

    public void DestroyGoomba()
    {
        Destroy(gameObject);
    }
}