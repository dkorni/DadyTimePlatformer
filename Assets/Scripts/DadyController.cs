using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadyController : MonoBehaviour
{
    public float MoveSpeed = 1;
    public float JumpSpeed = 1;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    [SerializeField] private Transform point;
    [SerializeField] private float _checkGroundedRadius = .3f;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private bool _isJumpPressed;
    private bool _isFacedToRight;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _isJumpPressed = Input.GetButtonDown("Jump");

        if (_isJumpPressed && _isGrounded)
        {
            Jump();
        }
        AnimateMove();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _isGrounded = IsGrounded();
        Move();
    }

    private void AnimateMove()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && _isGrounded)
        {
            _animator.SetBool("IsMoving",true);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }
    }

    private void Move()
    {
        var x = Input.GetAxis("Horizontal");

        if (x < 0 && _isFacedToRight)
        {
            Flip();
        }

        if (x>0 && !_isFacedToRight)
        {
            Flip();
        }
      

        var velocity = new Vector2(x * MoveSpeed, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = velocity;
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up*JumpSpeed, ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        var isGrounded = false;

        var colliders = Physics2D.OverlapCircleAll(point.position, _checkGroundedRadius);
        foreach (var collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                isGrounded = true;
            }
               
        }

        return isGrounded;
    }

    public void Flip()
    {
        _isFacedToRight = !_isFacedToRight;

        // flipping
        var scale = transform.localScale;
        scale.x *= -1;

        transform.localScale = scale;
    }
}
