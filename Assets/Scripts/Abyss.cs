using UnityEngine;
using IJunior.TypedScenes;

public class Abyss : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Character character))
            Level.Load();
        else
            Destroy(collision.gameObject);
    }
}