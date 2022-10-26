using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    //References
    private Rigidbody2D _rigidBody;
    private GroundDetector _groundDetector;
    private Animator _animator;
    private Collider2D _collider;

    //Jump force
    private float _force = 900;

    //Coyote time implementation
    private float _coyoteTime = 0.15f;
    private float _coyoteTimeCounter;

    //Jump buffer implementation
    //private float _jumpBufferTime = 0.2f;
    //private float _jumpBufferTimer;

    //raycast paramenters
    private float _extraDistance = 0.1f;
    private float _offset = 0.5f;
    private LayerMask _groundLayer;


    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _groundDetector = GetComponent<GroundDetector>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_groundDetector.IsGrounded())
        {
            _coyoteTimeCounter = _coyoteTime;
            _animator.SetBool("isGrounded", true);
        }
        else
        {
            _coyoteTimeCounter -= Time.deltaTime;
            _animator.SetBool("isGrounded", false);
        }

        if (_coyoteTimeCounter >= 0f && Input.GetButtonDown("Jump"))
        {
            _rigidBody.AddForce(new Vector2(0, _force));
            //EdgeFix();
        }
    }

    //por implementar
    private bool EdgeFix()
    {
        RaycastHit2D raycast = Physics2D.Raycast(_collider.bounds.center * _offset, Vector2.up,
            _collider.bounds.extents.y + _extraDistance, _groundLayer);

        Color rayColor;

        if (raycast.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
            transform.SetParent(null, true);

        }

        Debug.DrawRay(_collider.bounds.center, Vector2.down * (
            _collider.bounds.extents.y + _extraDistance), rayColor);


        return raycast.collider != null;
    }
}
