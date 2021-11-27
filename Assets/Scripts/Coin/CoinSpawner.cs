using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _template;

    private void Start() => Spawn();

    private void Spawn() => Instantiate(_template, transform.position, Quaternion.identity);
}