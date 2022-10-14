using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
    //Grounded horizontal speed
    private float _groundedSpeed = 5f;

    //Air horizontal speed
    private float _airSpeed = 4.5f;

    //References
    private GroundDetector _groundDetector;
    private Animator _animator;

    // Start is called before the first frame update
    private void Start()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if(horizontalInput != 0)
        {
            MoveHorizontal(horizontalInput);
            Flip(horizontalInput);
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }

    //Moves the game object in the horizontal axis
    private void MoveHorizontal(float horizontalInput)
    {
        horizontalInput = _groundDetector.IsGrounded() ? horizontalInput = horizontalInput * _groundedSpeed : horizontalInput = horizontalInput * _airSpeed;

        transform.position += new Vector3(horizontalInput * Time.deltaTime, 0, 0);
    }

    //Flips player in the direction they're moving
    private void Flip(float horizontalInput)
    {
        if(horizontalInput > 0) transform.localScale = new Vector3(1, 1, 1);

        if (horizontalInput < 0) transform.localScale = new Vector3(-1,1,1);
    }
}
