using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.U2D;

public class Material : MonoBehaviour
{
    public enum MATERIALS
    {
        BLOOD, OIL, FIRE
    }

    public MATERIALS materialType;
    SpriteRenderer materialRenderer;
    public Sprite defaultSprite;

    public void OnCreatedMaterial(MATERIALS type)
    {
        materialType = type;
        materialRenderer = GetComponent<SpriteRenderer>();
        if (materialRenderer != null)
        {
            materialRenderer.sprite = defaultSprite;

            switch (materialType)
            {
                case MATERIALS.BLOOD:
                    materialRenderer.color = Color.red;
                    
                    break;
                case MATERIALS.OIL:
                    materialRenderer.color = Color.black;                  
                    
                    break;
                case MATERIALS.FIRE:
                    materialRenderer.color = Color.blue;                                     
                    
                    break;
                default:
                    Debug.LogWarning("Tipo de material inválido.");
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddMaterial(materialType);
            Destroy(gameObject);
        }
    }

}