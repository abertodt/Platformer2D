using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private GroundDetector _groundDetector;
    private float _force = 1000;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _groundDetector = GetComponent<GroundDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_groundDetector.IsGrounded == true && Input.GetButtonDown("Jump"))
        {
            _rigidBody.AddForce(new Vector2(0, _force));
        }
    }
}
