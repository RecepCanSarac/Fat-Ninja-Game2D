using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public Vector2 pos1, pos2;
    public float leftRightSpeed;
    private float oldPosition;

  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void EnemyMove()
    {
        transform.position = Vector3.Lerp(pos1,pos2,Mathf.PingPong(Time.time * leftRightSpeed,1.0f));

        if (transform.position.x > oldPosition)
        {
            transform.localRotation = Quaternion.Euler(0,0,0);
        }
        if (transform.position.x < oldPosition)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        oldPosition = transform.position.x; 
    }

   
}
