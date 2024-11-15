using UnityEngine;
public class UsableInventory : MonoBehaviour
{
    private CraftMannager CraftRef;
    private void Start()
    {
        CraftRef = CraftMannager.instance;
    }
    void Update()
    {
        UseBomb();
        UsePotion();
        UseShield();
    }
    public void UseBomb()
    {
        if(CraftRef == null) return;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(CraftRef.bombs.Count > 0)
            {
                CraftRef.bombs.RemoveAt(0);
            }
            else
            {
                print("No tenes bombas");
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
                print("No tenes pociones");
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
                print("No tenes escudos");
            }
        }
    }
}
