using UnityEngine;
using UnityEngine.SceneManagement;

public class Abyss : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Character character))
            SceneManager.LoadScene("Level");
        else
            Destroy(collision.gameObject);
    }
}