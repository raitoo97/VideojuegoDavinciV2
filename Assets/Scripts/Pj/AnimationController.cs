using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public enum POSITION
{
    UP, DOWN, LEFT, RIGHT
}
public class AnimationController : MonoBehaviour
{
    public static AnimationController Instance;
    [SerializeField] private POSITION positionSprite;
    private PlayerController spritePj;
    private SpriteRenderer spriteRenderer;
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
    }
    private void Start()
    {
        spritePj = GameObject.FindObjectOfType<PlayerController>();
        if (spritePj == null) return;
        spriteRenderer = spritePj.gameObject.GetComponent<SpriteRenderer>();
        positionSprite = POSITION.UP;
    }
    private void Update()
    {
        UpdateAnimation();
    }
    private void UpdateAnimation()
    {
        if (spriteRenderer == null) return;
        switch (positionSprite)
        {
            case POSITION.UP:
                spriteRenderer.flipY = false;
                spriteRenderer.flipX = false;
                break;
            case POSITION.DOWN:
                spriteRenderer.flipY = true;
                spriteRenderer.flipX = false;
                break;
            case POSITION.LEFT:
                spriteRenderer.flipX = true;
                spriteRenderer.flipY = false;
                break;
            case POSITION.RIGHT:
                spriteRenderer.flipX = false;
                spriteRenderer.flipY = false;
                break;
        }
    }
    public void ChangeAnimation(POSITION currentPoistion)
    {
        positionSprite = currentPoistion;
    }
}
