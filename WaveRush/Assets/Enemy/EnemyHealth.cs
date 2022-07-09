using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    int currentHP = 0;

    public event Action onEnemyDie;

    // Start is called before the first frame update
    void OnEnable()
    {
        currentHP = maxHP;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit(1);
    }

    void ProcessHit(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            onEnemyDie?.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
