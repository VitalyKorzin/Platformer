using TMPro;
using UnityEngine;

public class DisplayBalance : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _balance;

    private void OnEnable() => _wallet.ChangedBalance += OnChangedBalance;

    private void OnDisable() => _wallet.ChangedBalance -= OnChangedBalance;

    private void OnChangedBalance() => _balance.text = _wallet.CoinsCount.ToString();
}