using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
[RequireComponent (typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{

    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;

    EnemyHealth enemyHealth;
    EnemyMover enemyMover;

    Bank bank;

    void Awake()
    {
        bank = FindObjectOfType<Bank>();
        enemyHealth = this.GetComponent<EnemyHealth>();
        enemyMover = this.GetComponent<EnemyMover>();
    }

    public void RewardGold()
    {
        if (bank == null)
        {
            return;
        }
        bank.Deposit(goldReward);
    }

    public void StealGold()
    {
        if (bank == null)
        {
            return;
        }
        bank.Withdraw(goldPenalty);
    }

    void OnEnable()
    {
        enemyHealth.onEnemyDie += RewardGold;
        enemyMover.onEnemyReachEnd += StealGold;
    }

    void OnDisable()
    {
        enemyHealth.onEnemyDie -= RewardGold;
        enemyMover.onEnemyReachEnd -= StealGold;
    }
}
