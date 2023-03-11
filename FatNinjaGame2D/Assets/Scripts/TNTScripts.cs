using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        StartCoroutine(T�mer());
    }

    // Update is called once per frame
    void Update()
    {
       
       
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

    IEnumerator T�mer()
    {
        yield return new WaitForSeconds(1);
        explode();
        Destroy(gameObject);
        yield return new WaitForSeconds(0.1f);

    }
}
