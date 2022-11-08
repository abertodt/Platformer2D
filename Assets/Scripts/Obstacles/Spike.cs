using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private int damage;
    public void DamagePlayer()
    {
        HealthController.Instance.Damage(damage);
    }
}
