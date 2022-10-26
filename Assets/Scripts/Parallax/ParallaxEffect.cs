using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    //camera
    private Camera _camera;

    //parallax speed
    [SerializeField] private float _speed;

    //offset
    [SerializeField] private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _camera.transform.position *  _speed + _offset;
    }
}
