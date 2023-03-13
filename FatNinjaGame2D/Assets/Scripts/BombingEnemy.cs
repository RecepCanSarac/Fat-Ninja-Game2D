using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BombingEnemy : MonoBehaviour
{
    public float radius = 2f;
    public Transform target;
    bool Detected = false;
    Vector2 direction;
    public GameObject bomb;
    public Transform bombPoint;
    public float Force;
    public float FireRate;
    private float nextTimeToFire = 0;
    Animator animator;
    EnemyIA enemyIA;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,radius); 
    }
    void Start()
    {
        enemyIA = GetComponent<EnemyIA>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TriggerEnemy();
    }

    void TriggerEnemy()
    {
        Vector2 targetPos = target.position;
        direction = targetPos - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position,direction,radius);

        if (hit)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                if (Detected == false)
                {
                    Debug.Log("iceride");
                    Detected = true;
                }
            }
        }
        else
        {
            if (Detected == true)
            {
                Debug.Log("Diþarida");
                Detected = false;
                animator.SetBool("inside", false);
                enemyIA.speed = 1;
            }
        }
        if (Detected)
        {
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                animator.SetBool("inside",true);
                enemyIA.speed = 0;          
            
            }
        }
    }

    void Shoot()
    {
        GameObject Bomb =  Instantiate(bomb,bombPoint.position,Quaternion.identity);
        Bomb.GetComponent<Rigidbody2D>().AddForce(direction * Force);
        Bomb.GetComponent<Rigidbody2D>().AddForce(transform.up * 250);
    }

}
