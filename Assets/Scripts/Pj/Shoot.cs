using UnityEngine;
public class Shoot : MonoBehaviour
{

    void Start()
    {
        InputMannager.instance.interactAction += Shooting;
    }

    private void Shooting()
    {
        print("El jugador dispara");
    }
}
