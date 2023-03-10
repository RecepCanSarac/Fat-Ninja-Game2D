using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public  float speed;
    public float distance;
    private bool moveinRight = true;
    public Transform groundControl;
    
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemyMove()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D ground = Physics2D.Raycast(groundControl.position,Vector2.down, distance);

        if (ground.collider == true)
        {
            transform.Rotate(0,0,0);
        }
        else if(ground.collider == false)
        {
            transform.Rotate(0, 180, 0);
        }
    }

   
}
