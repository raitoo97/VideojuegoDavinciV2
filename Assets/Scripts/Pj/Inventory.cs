using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public List<int> oil;
    public List<int> blood;
    public List<int> fire;
    public Button craftBomb;
    [SerializeField]public int CountOilToBomb;
    [SerializeField]public int CountbloodToBomb;
    [SerializeField]public int CountfireToBomb;
    private void Start()
    {
        CountOilToBomb = 5;
        CountbloodToBomb = 10;
        CountfireToBomb = 8;
        craftBomb.onClick.AddListener(CraftBomb);
    }
    public void CraftBomb()
    {
        if (GetOilCount() >= CountOilToBomb && GetBloodCount() >= CountbloodToBomb && GetFireCount() >= CountfireToBomb)
        {
            print("Felicitaciones por despercidar el tiempo haicnedo esta bomba de mierda:");
            RemoveOil(CountOilToBomb);
            RemoveBlood(CountbloodToBomb);
            RemoveFire(CountfireToBomb);
        }
        else
        {
            print("Materiales insuficientes");
            print($"Aceite requerido {CountOilToBomb} / Disponible : {GetOilCount()}");
            print($"Sangre requerida {CountbloodToBomb} / Disponible : {GetBloodCount()}");
            print($"Fuego requerido {CountfireToBomb} / Disponible : {GetFireCount()}");
        }
    }
    public int GetBloodCount()
    {
        return blood.Count;
    }
    public int GetOilCount()
    {
        return oil.Count;
    }
    public int GetFireCount()
    {
        return fire.Count;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        oil = new List<int>();
        blood = new List<int>();
        fire = new List<int>();
    }

    private void Update()
    {
        PruebaItemsAdd();
    }
    public void AddBlood()
    {
        int count = Random.Range(1, 4);
        for (int i = 0; i < count; i++)
        {
            blood.Add(count);
        }
        print($"Conseguiste {count} de Sangre");
    }
    public void AddFire()
    {
        int count = Random.Range(1, 4);
        for (int i = 0; i < count; i++)
        {
            fire.Add(count);
        }
        print($"Conseguiste {count} de Fuego");
    }
    public void AddOil()
    {
        int count = Random.Range(1, 4);
        for (int i = 0; i < count; i++)
        {
            oil.Add(count);
        }
        print($"Conseguiste {count} de Aceite");
    }
    public int RemoveOil(int necessaryAmount)
    {
        if(oil.Count >= necessaryAmount)
        {
            for (int i = 0; i < necessaryAmount; i++)
            {
                oil.RemoveAt(0);
            }
            print($"La nueva count de aceite es de {oil.Count}");
            return necessaryAmount;
        }
        else
        {
            print($"No tienes suficiente aceite ya que necesitas {necessaryAmount} y La count de aceite disponible es de {oil.Count}");
            return 0;
        }
    }
    public int RemoveBlood(int necessaryAmount)
    {
        if (blood.Count >= necessaryAmount)
        {
            for (int i = 0; i < necessaryAmount; i++)
            {
                blood.RemoveAt(0);
            }
            print($"La nueva count de sangre es de {blood.Count}");
            return necessaryAmount;
        }
        else
        {
            print($"No tienes suficiente sangre ya que necesitas {necessaryAmount} y La count de aceite disponible es de {blood.Count}");
            return 0;
        }
    }
    public int RemoveFire(int necessaryAmount)
    {
        if (fire.Count >= necessaryAmount)
        {
            for (int i = 0; i < necessaryAmount; i++)
            {
                fire.RemoveAt(0);
            }
            print($"La nueva count de aceite es de {fire.Count}");
            return necessaryAmount;
        }
        else
        {
            print($"No tienes suficiente aceite ya que necesitas {necessaryAmount} y La count de aceite disponible es de {fire.Count}");
            return 0;
        }
    }
    public void PruebaItemsAdd()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddBlood();
            AddFire();
            AddOil();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            print($"Total sangre: {GetBloodCount()}");
            print($"Total Fuego: {GetFireCount()}");
            print($"Total Aceite: {GetOilCount()}");
        }
    }
    //ESTA FUNCION EN EL FUTURO REEMPLAZA LAS TRES DE ADDX ME QUEDO UN XD TRISTE PERO NO ERA LA INTENCION SIU.
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Material"))
    //    {
    //        materialCount++;
    //    }
    //}
}
