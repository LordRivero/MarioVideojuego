using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed, radius, jumpForce;
    public KeyCode rightKey, leftKey, jumpKey;
    public LayerMask groundLayer;
    [HideInInspector]
    public bool isWalking = false;
    public bool isJumping = false;

    private Rigidbody2D _rb;
    private Vector2 _dir, _initialPos;
    private bool _intentionToJump = false;
    private Vector3 _pos;
    private SpriteRenderer _rend;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rend = GetComponent<SpriteRenderer>();
        _initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _dir = Vector2.zero;
        isWalking = false;
        if (Input.GetKey(leftKey))
        {
            _dir = Vector2.left;
            isWalking = true;
            _rend.flipX = true;
        }
        else if (Input.GetKey(rightKey))
        {
            _rend.flipX = false;
            _dir = Vector2.right;
            isWalking = true;
        }

        _intentionToJump = false;
        if (Input.GetKeyDown(jumpKey))
        {
            _intentionToJump = true;
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        Vector2 nVel = _dir * speed;
        nVel.y = _rb.velocity.y;
        _rb.velocity = nVel;
        print(IsGrounded());
        if(_intentionToJump && IsGrounded())
        {
            //_rb.velocity = new Vector2(_rb.velocity.x,0)
            //_rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse)
            Jump(jumpForce);
        }
        _intentionToJump = false;
    }

    public void Jump(float jF)
    {
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        _rb.AddForce(Vector2.up * jF, ForceMode2D.Impulse);
    }

    private void OnDrawGizmos()
    {
        Vector3 circlePos = transform.position;
        circlePos.y -= GetComponent<SpriteRenderer>().bounds.size.y / 2;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(circlePos, radius);
    }

    bool IsGrounded()
    {
        Vector3 circlePos = transform.position;
        circlePos.y -= _rend.bounds.size.y / 2;
        RaycastHit2D hit = Physics2D.CircleCast(circlePos, radius, Vector2.down, 0, groundLayer);

        return hit;
    }
   
    public void ResetPlayer()
    {
        transform.position = _initialPos;
    }
}