using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FatEnemyScripts : MonoBehaviour
{
    public float Distance;
    public Transform Target;
    public float FallowSpeed;
    EnemyIA enemyIA;
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        enemyIA = GetComponent<EnemyIA>();
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
        }
        if (trigger.collider == null)
        {
            Debug.DrawLine(transform.position, trigger.point, Color.green);
            enemyIA.EnemyMove();
        }
    }
    void EnemyFallow()
    {
        Vector3 targetPos = new Vector3(Target.position.x, gameObject.transform.position.y, Target.position.x);
        transform.position = Vector2.MoveTowards(transform.position, targetPos, FallowSpeed * Time.deltaTime);
    }
}
