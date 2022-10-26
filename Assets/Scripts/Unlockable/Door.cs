using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    private bool _isLocked = true;

    public void SetLocked(bool locked)
    {
        _isLocked = locked;
    }

    public void TryOpen()
    {
        if (!_isLocked)
        {
            _collider.enabled = false;
        }
    }
}
