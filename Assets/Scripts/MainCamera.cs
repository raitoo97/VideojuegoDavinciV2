using UnityEngine;
public class MainCamera : MonoBehaviour
{
    Transform playerPosition;
    Vector3 vectorPj;
    void Update()
    {
        if (GameManager.instance.player.gameObject != null) 
        {
            playerPosition = GameManager.instance.player.transform;
        }
        if (playerPosition == null) return;
        vectorPj = new Vector3(playerPosition.position.x, playerPosition.position.y, -1);
        Camera.main.orthographicSize = 5;
    }
    private void LateUpdate()
    {
        this.gameObject.transform.position = vectorPj;
    }
}
