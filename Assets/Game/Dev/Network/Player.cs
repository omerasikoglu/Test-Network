using System;
using System.Collections.Generic;
using Economy;
using NaughtyAttributes;
using UnityEngine;

public class Player : MonoBehaviour{

  readonly Dictionary<Currency, int> initialCurrencyAmountDic = new Dictionary<Currency, int>
  { { Currency.EUR, 4 },
    { Currency.USD, 5 } };

  Wallet wallet;

  void Awake(){
    wallet = new Wallet(initialCurrencyAmountDic);
  }

  void Start(){
    wallet.OnMoneyChanged += MoneyChanged;

    Test1();
  }

  void MoneyChanged(object sender, Wallet.OnMoneyChangedEventArgs e){

    Debug.Log($"<color=green>Money Changed{e.changedCurrency}: {e.newAmount}</color>");
  }

  [Button] void IncreaseMoney(){
    wallet.Add(Currency.USD, 1);
  }

  void Test1(){
    Debug.Log(wallet[Currency.EUR]);
    Debug.Log(wallet[Currency.USD]);
  }

}