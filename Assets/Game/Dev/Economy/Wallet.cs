using System;
using System.Collections.Generic;

namespace Economy{

  public enum Currency{
    USD, EUR, GBP, Coin, Potato
  }

  public sealed class Wallet{
    public event EventHandler<OnMoneyChangedEventArgs> OnMoneyChanged;

    public class OnMoneyChangedEventArgs : EventArgs{
      public Currency changedCurrency;
      public int      newAmount;
    }

    readonly Dictionary<Currency, int> currencyAmountDic = new Dictionary<Currency, int>();

    public Wallet(IReadOnlyDictionary<Currency, int> currencyAmountDic){
      foreach (Currency currency in Enum.GetValues(typeof(Currency))){
        this.currencyAmountDic[currency] = currencyAmountDic.TryGetValue(currency, out int amount) ? amount : 0;
      }
    }

  #region Indexer
    public int this[Currency currency]{
      get => currencyAmountDic.ContainsKey(currency) ? currencyAmountDic[currency] : default;
      private set{
        currencyAmountDic[currency] = value;
        OnMoneyChanged?.Invoke(this, new OnMoneyChangedEventArgs
        { changedCurrency = currency,
          newAmount       = this[currency] });
      }
    }
  #endregion

  #region Settlers
    public void Add(Currency currency, int amount){
      this[currency] += amount;
    }

    public void Spend(Currency currency, int amount){
      if (this[currency] >= amount){
        this[currency] -= amount;
      }
      else{
        Console.WriteLine("Not enough " + currency + " to spend " + amount);
      }
    }

    public void Set(Currency currency, int amount){
      this[currency] = amount;
    }
  #endregion
  }

}