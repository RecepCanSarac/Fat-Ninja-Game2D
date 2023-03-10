using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MeleeEnemy : MonoBehaviour
{
    public float Distance;
    private Transform Target;
    public float FallowSpeed;
    EnemyIA enemyIA;
    PlayerStat stat;
    public Transform raycastHit;
    Animator animator;
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyIA =GetComponent<EnemyIA>();
        animator = GetComponent<Animator>();    
        stat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStat>();
    }

    
    void Update()
    {
        EnemyActive();
    }

    void EnemyActive()
    {
        RaycastHit2D enemyActive = Physics2D.Raycast(raycastHit.position, transform.right,Distance);

        if (enemyActive.collider != null)
        {
            Debug.DrawLine(raycastHit.position,enemyActive.point, Color.red);
            EnemyFallow();
        }
        if (enemyActive.collider == null)
        {
            Debug.DrawLine(raycastHit.position, enemyActive.point, Color.green);
            enemyIA.EnemyMove();
        }
    }
    void EnemyFallow()
    {
        Vector3 targetPos = new Vector3(Target.position.x, gameObject.transform.position.y, Target.position.x);
        transform.position = Vector2.MoveTowards(transform.position, targetPos, FallowSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyIA.speed = 0;
            FallowSpeed = 0;
            animator.SetBool("Touched",true);
           
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        enemyIA.speed = 1;
        FallowSpeed = 3;
        animator.SetBool("Touched", false);
    }
    public void DamagePlayer()
    {
        stat.TakeDamage(15);
    }
}
