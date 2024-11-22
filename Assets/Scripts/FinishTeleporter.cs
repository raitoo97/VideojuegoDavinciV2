using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishTeleporter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print(collision.name);
            SceneManager.LoadScene(2);
        }
    }
}
