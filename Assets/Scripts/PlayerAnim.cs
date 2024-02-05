using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private PlayerMovement PlayerMovement;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerMovement = GetComponent<PlayerMovement>();
        //_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(PlayerMovement.isWalking)
        {
            //_animator.SetBool("isWalking", true);
        }
        //else
        {
            //_animator.SetBool("isWalking", false);
        }
        //if(PlayerMovement.isJumping)
        {
            //_animator.SetBool("isJumping", true);
        }
        //else
        {
            //_animator.SetBool("isJumping", false);
        }
    }
}
