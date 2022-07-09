using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldObserver : MonoBehaviour
{
    [SerializeField] Bank bank;

    TMP_Text text;
    void Awake()
    {
        text = this.GetComponent<TMP_Text>();
    }

    void SynchronizeGoldUIText()
    {
        text.text = "GOLD: " + bank.CurrentBalance;
    }

    void OnEnable()
    {
        bank.onBalanceChange += SynchronizeGoldUIText;
    }
    void OnDisable()
    {
        bank.onBalanceChange -= SynchronizeGoldUIText;
    }
}
