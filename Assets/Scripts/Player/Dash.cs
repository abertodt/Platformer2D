using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    //dash parameters
    private float _dashForce = 500f;
    private int _maxDashCount = 1;
    private float _extraDash = 1;
    private float _recoveryTime = 1;
    private float _gravityScale;

    //components
    private GroundDetector _groundDetector;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _rb = GetComponent<Rigidbody2D>();
        _gravityScale = _rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (_groundDetector.IsGrounded())
        {
            _extraDash += Time.deltaTime / _recoveryTime;
            if(_extraDash > _maxDashCount) _extraDash = _maxDashCount;
        }

        if (Input.GetButtonDown("Dash") && _extraDash >= 1)
        {
            _extraDash--;
            StartCoroutine(DisableGravity());
            _rb.AddForce(new Vector2(_dashForce * transform.localScale.x, 0));
        }
            
    }

    IEnumerator DisableGravity()
    {
        _rb.gravityScale = 0.0f;
        yield return new WaitForSeconds(0.2f);
        _rb.gravityScale = _gravityScale;
    }
}
