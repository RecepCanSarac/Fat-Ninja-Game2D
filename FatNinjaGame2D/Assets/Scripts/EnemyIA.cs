using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool moveinRight = true;
    public Transform groundControl;

    private Animator animator;
  
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    public void EnemyMove()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D ground = Physics2D.Raycast(groundControl.position,Vector2.down, distance);

        if (ground.collider == false)
        {
            if (moveinRight == true)
            {
                StartCoroutine(Timer1());
            }
            else
            {
                StartCoroutine(Timer2());
            }
           
        }
        
    }

   IEnumerator Timer1()
    {
        speed = 0;
        animator.SetBool("Stop",true);
        yield return new WaitForSeconds(0.7f);
        animator.SetBool("Stop", false);
        transform.eulerAngles = new Vector3(0, -180, 0);
        moveinRight = false;
        speed = 1;
    }
    IEnumerator Timer2()
    {
        speed = 0;
        animator.SetBool("Stop", true);
        yield return new WaitForSeconds(0.7f);
        animator.SetBool("Stop", false);
        transform.eulerAngles = new Vector3(0, 0, 0);
        moveinRight = true;
        speed = 1;
    }
}
