using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private Rigidbody2D rb;
    private GameManager gameManager;
    private TagSystem tagSystem;

    private float moveH;

    public float speed;

    public bool canMove;

    void Start()
    {
        speed = 20f;
        rb = GetComponent<Rigidbody2D>();
        tagSystem = GetComponent<TagSystem>();

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {

        if (gameManager.startGame == true)
        {
            canMove = true;
        }

        if (!canMove)
        {
            return;
        }

        moveH = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.up * speed;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveH * speed, rb.velocity.y);
    }

}
