using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    public int CoinsCount { get; private set; }

    public event UnityAction ChangedBalance;

    public void ReplenishCoins(int count)
    {
        CoinsCount += count;
        ChangedBalance?.Invoke();
    }
}