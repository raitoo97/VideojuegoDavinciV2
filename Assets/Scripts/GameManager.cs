using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public GameObject spawn;
    public Canvas uiCanvas; // Referencia al Canvas UI
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Hace que este objeto persista entre escenas
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("GameManager destruido");
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawn = GameObject.FindFirstObjectByType<SpawnEnemies>().gameObject;
        
    }

    private void Update()
    {
        if (spawn == null)
        {
           print("GANASTE EL JUEGO!!");
        }
    }
}
