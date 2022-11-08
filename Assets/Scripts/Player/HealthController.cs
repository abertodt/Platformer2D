using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector2 _knockback;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _transparentColor;
    private int _health = 3;
    private float _recoveryTime = 3f;
    private float _recoveryTimeCounter = 0f;

    public static HealthController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    public void Damage(int damage)
    {
        if(_recoveryTimeCounter <= 0)
        {
            _recoveryTimeCounter = _recoveryTime;
            StartCoroutine(Blink());
            _health -= damage;
            _rb.velocity = _rb.velocity;
            
            _rb.AddForce(_knockback * new Vector2(-gameObject.transform.localScale.x, 1));
        }

        if (_health <= 0) Die();
    }

    private void Update()
    {     
        _recoveryTimeCounter -= Time.deltaTime;
    }

    private IEnumerator Blink()
    {
        SpriteRenderer playerSprite = gameObject.GetComponent<SpriteRenderer>();
        
        while (_recoveryTimeCounter > 0)
        {
            playerSprite.color = _transparentColor;

            yield return new WaitForSeconds(0.3f);

            playerSprite.color = _defaultColor;

            yield return new WaitForSeconds(0.3f);

        }
    }

    private void Die()
    {
        SceneManagerSingleton.Instance.ReloadScene();
    }
}
