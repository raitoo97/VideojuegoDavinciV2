using UnityEngine;

public class UsableInventory : MonoBehaviour
{
    private CraftMannager CraftRef;
    [SerializeField] GameObject bombPrefab;
    [SerializeField] Transform bombSpawn;

    [SerializeField] private AudioClip activationSound; // Sonido de activación
    private AudioSource audioSource;

    private void Start()
    {
        CraftRef = CraftMannager.instance;

        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource no encontrado en UsableInventory. Asegúrate de agregar uno al GameObject.");
        }
    }

    void Update()
    {
        UseBomb();
        UsePotion();
        UseShield();
    }

    public void UseBomb()
    {
        if (CraftRef == null) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (CraftRef.bombs.Count > 0)
            {
                CraftRef.bombs.RemoveAt(0);
                ThrowBomb();
            }
            else
            {
                Debug.Log("No tienes bombas.");
            }
        }
    }

    void ThrowBomb()
    {
        if (this != null)
        {
            // Crear la bomba
            GameObject bomb = Instantiate(bombPrefab, bombSpawn.position, Quaternion.identity);

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            Vector3 direction = (mouseWorldPos - bombSpawn.position).normalized;
            bomb.transform.up = direction;

            Bomb bombScript = bomb.GetComponent<Bomb>();
            if (bombScript != null)
            {
                // Reproducir sonido de activación
                if (audioSource != null && activationSound != null)
                {
                    audioSource.PlayOneShot(activationSound);
                }
                else
                {
                    Debug.LogWarning("AudioSource o AudioClip no asignados en UsableInventory.");
                }

                bombScript.DetonateBomb();
            }
        }
    }

    public void UsePotion()
    {
        if (CraftRef == null) return;

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (CraftRef.healthPotions.Count > 0)
            {
                CraftRef.healthPotions.RemoveAt(0);
            }
            else
            {
                Debug.Log("No tienes pociones.");
            }
        }
    }

    public void UseShield()
    {
        if (CraftRef == null) return;

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (CraftRef.shieldPotions.Count > 0)
            {
                CraftRef.shieldPotions.RemoveAt(0);
            }
            else
            {
                Debug.Log("No tienes escudos.");
            }
        }
    }
}