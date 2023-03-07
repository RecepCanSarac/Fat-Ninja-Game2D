using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D playerRB;
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        playerRB.velocity = new Vector3(horizontalMove * speed * Time.deltaTime,playerRB.velocity.y,0f);
    }
}
