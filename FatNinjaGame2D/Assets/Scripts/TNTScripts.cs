using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTScripts : MonoBehaviour
{
    public float radius;
    public float Force;
    public LayerMask LayerHit;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,radius);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            explode();
        }
       
    }
    void explode()
    {
        Collider2D[] rayInfo = Physics2D.OverlapCircleAll(transform.position, radius, LayerHit);

        foreach (Collider2D ray in rayInfo)
        {
            Vector2 Direction = ray.transform.position - transform.position;
            ray.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
        }
    }
}
