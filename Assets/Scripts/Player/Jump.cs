using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    //References
    private Rigidbody2D _rigidBody;
    private GroundDetector _groundDetector;
    private Animator _animator;

    //Jump force
    private float _force = 900;

    //Coyote time implementation
    private float _coyoteTime = 0.1f;
    private float _coyoteTimeCounter;

    //Jump buffer implementation
    //private float _jumpBufferTime = 0.2f;
    //private float _jumpBufferTimer;


    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _groundDetector = GetComponent<GroundDetector>();
        _animator = GetComponent<Animator>();
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

        if (_coyoteTimeCounter > 0f && Input.GetButtonDown("Jump"))
        {
            _rigidBody.AddForce(new Vector2(0, _force));
        }
    }
}
