using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;

    [SerializeField] int currentBalance = 150;
    public int CurrentBalance{ get { return currentBalance; } }

    public event Action onBalanceChange;

    void Start()
    {
        currentBalance = startingBalance;
        onBalanceChange?.Invoke();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        onBalanceChange?.Invoke();
        if (currentBalance < 0)
        {
            ReloadScene();
        }
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        onBalanceChange?.Invoke();
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
