using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25; // this could be made with only 1 variable, but it was split to benefit the designer's life
    [SerializeField] int goldPenalty = 25;

    Bank bank;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold() {
        if(bank == null) { return; }
        bank.Deposit(goldReward);
    }

    public void StealGold() {
        if(bank == null) { return; }
        bank.Withdraw(goldReward);
        Debug.Log("-" + goldReward + " of gold");
    }
}
