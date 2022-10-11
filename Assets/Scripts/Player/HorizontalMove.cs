using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{

    private float _speed;

    private void Start()
    {
        _speed = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
    }

    private void MoveHorizontal()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.position += new Vector3(horizontalInput, 0, 0) * Time.deltaTime * _speed;
    }
}
