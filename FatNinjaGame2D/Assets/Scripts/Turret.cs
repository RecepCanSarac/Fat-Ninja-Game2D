using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float Radius;
    public Transform Target;
    public Transform Gun;
    public Transform shootPoint;
    Vector2 Direction;
    private bool Detected = false;
    public float fireRate;
    private float nextTimeFireRate;
    public GameObject bullet;
    public float Force;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,Radius);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TriggerTurret();
    }

    private void TriggerTurret()
    {
        Vector2 newPos = Target.position;
        Direction = newPos - (Vector2)transform.position;

        RaycastHit2D AreaControl = Physics2D.Raycast(transform.position, Direction,Radius);

        if (AreaControl)
        {
            if (AreaControl.collider.gameObject.CompareTag("Player"))
            {
                if (Detected == false)
                {
                    Detected = true;
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                }
            }
            if (Detected == true)
            {
                if (Time.time > nextTimeFireRate)
                {
                    Gun.right = -Target.position;
                    nextTimeFireRate = Time.time + 1 / fireRate;
                    Shoot();
                }
            }
        }
    }

    private void Shoot()
    {
        GameObject newBullet =  Instantiate(bullet,shootPoint.position,Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
        Destroy(newBullet,2f);
    }
}
