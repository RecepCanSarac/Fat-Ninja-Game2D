using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FatEnemyScripts : MonoBehaviour
{
    public float Distance;
    public float Radius;
    public Transform Target;
    public float FallowSpeed;
    EnemyIA enemyIA;
    Vector2 direction;
    private bool Detected = false;
    Rigidbody2D enemyRB;
    public float Force;
    private int JumpNum;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,Radius);
    }
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        enemyIA = GetComponent<EnemyIA>();
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyTrigger();
    }

    private void EnemyTrigger()
    {
        RaycastHit2D trigger = Physics2D.Raycast(transform.position, transform.right,Distance);

        if (trigger.collider != null)
        {
            Debug.DrawLine(transform.position,trigger.point,Color.red);
            EnemyFallow();
            JumpFatEnemy();
        }
        if (trigger.collider == null)
        {
            Debug.DrawLine(transform.position, trigger.point, Color.green);
            enemyIA.EnemyMove();
            Detected = false;
        }
    }
    void EnemyFallow()
    {
        Vector3 targetPos = new Vector3(Target.position.x, gameObject.transform.position.y, Target.position.x);
        transform.position = Vector2.MoveTowards(transform.position, targetPos, FallowSpeed * Time.deltaTime);
    }

    private void JumpFatEnemy()
    {
        Vector2 targetPos = Target.position;
        direction = targetPos - (Vector2)transform.position;
        RaycastHit2D jumpArea = Physics2D.Raycast(transform.position,direction,Radius);

        if (jumpArea)
        {
            if (jumpArea.collider.gameObject.CompareTag("Player"))
            {
                if (Detected == false)
                {
                    Detected = true;
                    Debug.Log("Ýçeride");
                    FallowSpeed = 0;
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                    Debug.Log("Diþarýda");
                    JumpNum = 0;
                }
            }

        }

        if (Detected == true)
        {
            if (JumpNum == 0)
            {
                FallowSpeed = 1.5f;
                enemyRB.AddForce(direction * Force);
                JumpNum = 1;
            }
        }

    }
}
