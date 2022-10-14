using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    //Boolean to detect if player is grounded
    private bool _isGrounded;


    //If player is staying on a platform
    private void OnTriggerStay2D(Collider2D collision)
    {
        _isGrounded = true;
    }

    //If player jumps of a platform
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isGrounded = false;
    }

    public bool IsGrounded()
    {
        return _isGrounded;
    }

    
}
