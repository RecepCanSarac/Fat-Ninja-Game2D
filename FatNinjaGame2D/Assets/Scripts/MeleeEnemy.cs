using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MeleeEnemy : MonoBehaviour
{
    public float Distance;
    private Transform Target;
    public float FallowSpeed;
    EnemyIA enemyIA;
    public Transform raycastHit;
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyIA =GetComponent<EnemyIA>();
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
}
