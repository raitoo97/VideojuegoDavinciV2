using UnityEngine;
using UnityEngine.UI;
public class CraftMannager : MonoBehaviour
{
    private Inventory inventoryRef;
    //Bombas
    public Button craftBomb;
    [SerializeField] public int countOilToBomb;
    [SerializeField] public int countbloodToBomb;
    [SerializeField] public int countfireToBomb;
    public int bombs;
    //Potas
    public Button craftHealthPotion;
    [SerializeField] public int countOilToHealthPotion;
    [SerializeField] public int countBloodToHealthPotion;
    [SerializeField] public int countFireToHealthPotion;
    public int healtPotion;
    //ShieldPotion
    public Button craftShieldPotion;
    [SerializeField] public int countOilToShieldPotion;
    [SerializeField] public int countBloodToShieldPotion;
    [SerializeField] public int countFireToHShieldPotion;
    public int shieldPotion;
    private void Start()
    {
        inventoryRef = Inventory.instance;
        //Bombas
        countOilToBomb = 5;
        countbloodToBomb = 10;
        countfireToBomb = 8;
        //Potas
        countOilToHealthPotion = 0;
        countBloodToHealthPotion = 20;
        countFireToHealthPotion = 0;
        //Escudos
        countOilToShieldPotion = 50;
        countBloodToShieldPotion = 0;
        countFireToHShieldPotion = 100;
        //Botones
        craftBomb.onClick.AddListener(CraftBomb);
        craftHealthPotion.onClick.AddListener(CraftHealthPotion);
        craftShieldPotion.onClick.AddListener(CraftShieldPotion);
    }
    private void Update()
    {
        GetItems();
    }
    public void CraftBomb()
    {
        if (inventoryRef == null) return;
        if (inventoryRef.GetOilCount() >= countOilToBomb && inventoryRef.GetBloodCount() >= countbloodToBomb && inventoryRef.GetFireCount() >= countfireToBomb)
        {
            print("Felicitaciones por despercidar el tiempo haciendo esta bomba de mierda:");
            bombs++;
            print($"Bombas Creadas: {bombs}");
            inventoryRef.RemoveOil(countOilToBomb);
            inventoryRef.RemoveBlood(countbloodToBomb);
            inventoryRef.RemoveFire(countfireToBomb);
        }
        else
        {
            print("Materiales insuficientes");
            print($"Aceite requerido {countOilToBomb} / Disponible : {inventoryRef.GetOilCount()}");
            print($"Sangre requerida {countbloodToBomb} / Disponible : {inventoryRef.GetBloodCount()}");
            print($"Fuego requerido {countfireToBomb} / Disponible : {inventoryRef.GetFireCount()}");
        }
    }
    public void CraftHealthPotion()
    {
        if (inventoryRef == null) return;
        if (inventoryRef.GetOilCount() >= countOilToHealthPotion && inventoryRef.GetBloodCount() >= countBloodToHealthPotion && inventoryRef.GetFireCount() >= countFireToHealthPotion)
        {
            print("Felicitaciones por despercidar el tiempo haciendo esta pocion de mierda:");
            healtPotion++;
            print($"Pociones Creadas: {healtPotion}");
            inventoryRef.RemoveOil(countOilToHealthPotion);
            inventoryRef.RemoveBlood(countBloodToHealthPotion);
            inventoryRef.RemoveFire(countFireToHealthPotion);
        }
        else
        {
            print("Materiales insuficientes");
            print($"Aceite requerido {countOilToHealthPotion} / Disponible : {inventoryRef.GetOilCount()}");
            print($"Sangre requerida {countBloodToHealthPotion} / Disponible : {inventoryRef.GetBloodCount()}");
            print($"Fuego requerido {countFireToHealthPotion} / Disponible : {inventoryRef.GetFireCount()}");
        }
    }
    public void CraftShieldPotion()
    {
        if (inventoryRef == null) return;
        if (inventoryRef.GetOilCount() >= countOilToShieldPotion && inventoryRef.GetBloodCount() >= countBloodToShieldPotion && inventoryRef.GetFireCount() >= countFireToHShieldPotion)
        {
            print("Felicitaciones por despercidar el tiempo haciendo este escudo de mierda:");
            shieldPotion++;
            print($"escudos Creados: {shieldPotion}");
            inventoryRef.RemoveOil(countOilToShieldPotion);
            inventoryRef.RemoveBlood(countBloodToShieldPotion);
            inventoryRef.RemoveFire(countFireToHShieldPotion);
        }
        else
        {
            print("Materiales insuficientes");
            print($"Aceite requerido {countOilToShieldPotion} / Disponible : {inventoryRef.GetOilCount()}");
            print($"Sangre requerida {countBloodToShieldPotion} / Disponible : {inventoryRef.GetBloodCount()}");
            print($"Fuego requerido {countFireToHShieldPotion} / Disponible : {inventoryRef.GetFireCount()}");
        }
    }
    public void GetItems()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            print($"usted tiene {bombs} bombas.");
            print($"usted tiene {healtPotion} Pociones de salud.");
            print($"usted tiene {shieldPotion} Pociones de escudo.");
        }
    }
}
