using UnityEngine;
using IJunior.TypedScenes;

[RequireComponent(typeof(CharacterMovement))]
public class Character : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Enemy enemy))
            Level.Load();
    }
}