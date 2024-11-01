using UnityEngine;
using UnityEngine.UI;
public class MannagerUI : MonoBehaviour
{
    public Text oilCount;
    public Text bloodCount;
    public Text fireCount;
    public Text bombsCount;
    public Text healthPotionCount;
    public Text shieldCount;
    public Button craftBomb;
    public Button craftHealthPotion;
    public Button craftShieldPotion;
    private Inventory inventoryRef;
    private CraftMannager CraftRef;
    private void Start()
    {
        CraftRef = CraftMannager.instance;
        inventoryRef = Inventory.instance;
        //Botones
        craftBomb.onClick.AddListener(CraftRef.CraftBomb);
        craftHealthPotion.onClick.AddListener(CraftRef.CraftHealthPotion);
        craftShieldPotion.onClick.AddListener(CraftRef.CraftShieldPotion);
    }
    void Update()
    {
        CheckInventoryItemsCount();
    }
    private void CheckInventoryItemsCount()
    {
        if (inventoryRef == null) return;
        oilCount.text = inventoryRef.GetOilCount().ToString();
        bloodCount.text = inventoryRef.GetBloodCount().ToString();
        fireCount.text = inventoryRef.GetFireCount().ToString();
        bombsCount.text = CraftRef.GETBOMBS.ToString();
        healthPotionCount.text = CraftRef.GETPOTION.ToString();
        shieldCount.text = CraftRef.GETSHIELDS.ToString();
    }
}
