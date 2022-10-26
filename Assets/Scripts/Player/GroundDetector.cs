using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{

    //components
    private Collider2D _collider;

    //ground layer mask
    [SerializeField] private LayerMask _groundLayer;

    //mobile platforms tag
    private string _mobileElement = "MobileElement";


    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    public bool IsGrounded()
    {
        bool isGrounded = false;
        transform.SetParent(null, true);

        Vector3 origin = _collider.bounds.center - new Vector3(0, 0.1f, 0);
        Vector3 originRight = _collider.bounds.center - new Vector3(0 + 0.1f, 0.1f, 0);
        Vector3 originLeft = _collider.bounds.center - new Vector3(0 - 0.1f, 0.1f, 0);


        Color rayColor = Color.red;


        //Center Raycast
        RaycastHit2D raycast = Physics2D.Raycast(origin, Vector2.down,
            _collider.bounds.extents.y, _groundLayer);

        if(raycast.collider != null)
        {
            rayColor = Color.green;
            if (raycast.collider.tag == _mobileElement)
            {
                transform.SetParent(raycast.collider.transform, true);
            }
            isGrounded = true;
        }
        Debug.DrawRay(origin, Vector2.down * (_collider.bounds.extents.y), rayColor);

        //Left Raycast
        RaycastHit2D raycastRight = Physics2D.Raycast(originRight, Vector2.down,
                _collider.bounds.extents.y, _groundLayer);

        if (raycastRight.collider != null)
        {
            rayColor = Color.green;
            if (raycastRight.collider.tag == _mobileElement)
            {
                transform.SetParent(raycastRight.collider.transform, true);
            }
            isGrounded = true;
        }
        Debug.DrawRay(originRight, Vector2.down * (_collider.bounds.extents.y), rayColor);

        //Right Raycast
        RaycastHit2D raycastLeft = Physics2D.Raycast(originLeft, Vector2.down,
                _collider.bounds.extents.y, _groundLayer);

        if (raycastLeft.collider != null)
        {
            rayColor = Color.green;
            if (raycastLeft.collider.tag == _mobileElement)
            {
                transform.SetParent(raycastLeft.collider.transform, true);
            }
            isGrounded = true;
        }
        Debug.DrawRay(originLeft, Vector2.down * (_collider.bounds.extents.y), rayColor);

        return isGrounded;
    }


    
}
