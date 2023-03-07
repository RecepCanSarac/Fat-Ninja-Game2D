using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D playerRB;
    private Vector3 Scale;
    private bool lookRight;
    private Animator _animator;
    void Start()
    {
        lookRight = true;
        playerRB = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        playerRB.velocity = new Vector3(horizontalMove * speed * Time.deltaTime,playerRB.velocity.y,0f);
        _animator.SetFloat("Speed", MathF.Abs(horizontalMove));
        if (horizontalMove > 0 && lookRight == false)
        {
            flip();
        }
        else if (horizontalMove < 0 && lookRight == true)
        {
            flip();
        }
    }

    private void flip()
    {
        lookRight = !lookRight;
        Scale = gameObject.transform.localScale;
        Scale.x = Scale.x * -1;
        gameObject.transform.localScale = Scale; 
    }
}
