using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed, rayDistance, jumpForce;
    public KeyCode rightKey, leftKey, jumpKey;
    public LayerMask groundMask;
    public AudioClip jumpClip;

    private Rigidbody2D _rb;
    private Vector2 _dir, _initialPos;
    private bool _intentionToJump;
    private Vector3 _pos;
    private SpriteRenderer _rend;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rend = GetComponent<SpriteRenderer>();
        _initialPos = transform.position;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        print(GameManager.instance.GetTime());
        _dir = Vector2.zero;
        if (Input.GetKey(leftKey))
        {
            _dir = new Vector2(-1, 0);
            //isWalking = true;
            _rend.flipX = true;
        }
        else if (Input.GetKey(rightKey))
        {
            _rend.flipX = false;
            _dir = Vector2.right;
            //isWalking = true;
        }

        //_intentionToJump = false;
        if (Input.GetKeyDown(jumpKey))
        {
            _intentionToJump = true;
            //isJumping = true;
        }

        if (_dir != Vector2.zero)
        {
            _animator.SetBool("isWalking", true);//estamos andando.
        }
        else
        {
            _animator.SetBool("isWalking", false);//estamos parados.
        }
    }


    private void FixedUpdate()
    {
        bool grnd = IsGrounded();
        {
            float currentYVel = _rb.velocity.y;
            Vector2 nVel = _dir * speed;
            nVel.y = currentYVel;

            _rb.velocity = nVel;
        }

        if (_intentionToJump && grnd)
        {
            _animator.Play("jumpAnimation");
            _rb.velocity = new Vector2(_rb.velocity.x, 0);
            _rb.AddForce(Vector2.up * jumpForce * _rb.gravityScale, ForceMode2D.Impulse);
            _intentionToJump = false;
            AudioManager.instance.PlayAudio(jumpClip, "jumpSound");
        }

        _animator.SetBool("isGrounded", grnd);
    }

    private bool IsGrounded()
    {
        RaycastHit2D collision = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundMask);
        if (collision)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }

    public void ResetPlayer()
    {
        transform.position = _initialPos;
    }
}
    //Vector2 nVel = _dir * speed;
    //nVel.y = _rb.velocity.y;
    //_rb.velocity = nVel;
    //print(IsGrounded());
    //if(_intentionToJump && IsGrounded())

    //_rb.velocity = new Vector2(_rb.velocity.x,0)
    //_rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse)
    //Jump(jumpForce);

    //_intentionToJump = false;
    //AudioManager.instance.PlayAudio(jumpClip, "jumpSound")
    //_animator.SetBool("isGrounded", grnd);



    //public void Jump(float jF)
    
        //_rb.velocity = new Vector2(_rb.velocity.x, 0);
        //_rb.AddForce(Vector2.up * jF, ForceMode2D.Impulse);
    

    //private void OnDrawGizmos()
    
        //Vector3 circlePos = transform.position;
        //circlePos.y -= GetComponent<SpriteRenderer>().bounds.size.y / 2;
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(circlePos, radius);
    

    //bool IsGrounded()
    
        //Vector3 circlePos = transform.position;
        //circlePos.y -= _rend.bounds.size.y / 2;
        //RaycastHit2D hit = Physics2D.CircleCast(circlePos, radius, Vector2.down, 0, groundLayer);

        //return hit;
    
   
   
