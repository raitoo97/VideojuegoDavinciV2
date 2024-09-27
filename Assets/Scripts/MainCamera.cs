using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    Transform playerPosition;
    Vector3 vectorPj;
    void Start()
    {
        
    }

    
    void Update()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        vectorPj = new Vector3(playerPosition.position.x, playerPosition.position.y,-200);
        
    }

    private void LateUpdate()
    {
        this.gameObject.transform.position = vectorPj;
    }
}
