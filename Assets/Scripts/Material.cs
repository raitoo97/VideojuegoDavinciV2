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
        WATER, OIL, METAL, ACID
    }

    SpriteRenderer materialRenderer;

    public Sprite defaultSprite;

    public void OnCreatedMaterial(int type)
    {
        materialRenderer = GetComponent<SpriteRenderer>();
        if (materialRenderer != null)
        {
            materialRenderer.sprite = defaultSprite;

            switch (type)
            {
                case 1:
                    materialRenderer.color = Color.blue;
                    
                    break;
                case 2:
                    materialRenderer.color = Color.black;                  
                    
                    break;
                case 3:
                    materialRenderer.color = Color.cyan;                   
                    
                    break;
                case 4:
                    materialRenderer.color = Color.green;                    
                    
                    break;
                default:
                    Debug.LogWarning("Tipo de material inválido.");
                    break;
            }
        }
    }
}