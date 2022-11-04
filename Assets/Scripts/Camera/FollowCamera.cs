using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //components
    [SerializeField] private Transform _target;
    private Camera _camera;

    //offset
    [SerializeField] private Vector3 _offset;

    //camera smoothing
    private float _speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, _target.position + _offset, Time.deltaTime * _speed);

    }
}
