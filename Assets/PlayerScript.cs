using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Rigidbody
    Rigidbody2D rb;
    public bool p1, p2;
    //Variaveis Movimento
    public float velocity;
    public float maxVelocity;
    float lado;
    //Variaveis Pulo
    public float jumpHeight;
    public float counter;
    float totalCount;
    public Transform sensor;
    public LayerMask chao; 
    public bool estaNoChao, isJumping;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        totalCount = counter;
    }

    void Update()
    {
        rb.velocity = new Vector2(lado * velocity, rb.velocity.y);
        if (p1)
        {
            if (Input.GetButtonDown("Horizontal"))
            {
                lado = Input.GetAxisRaw("Horizontal");
            }

            if (Input.GetButton("Horizontal"))
            {
                if (velocity <= maxVelocity)
                {
                    velocity++;
                }
            }
            else
            {
                if (velocity >= 0.25f)
                {
                    velocity -= 0.25f;
                }
            }

            estaNoChao = Physics2D.OverlapCircle(sensor.position, .15f, chao);
            isJumping = (rb.velocity.y != 0f);

            if (estaNoChao && Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.velocity = Vector2.up * jumpHeight;
                counter = totalCount;
            }

            if (isJumping && Input.GetKey(KeyCode.UpArrow))
            {
                if (counter > 0)
                {
                    rb.velocity = Vector2.up * jumpHeight;
                    counter -= Time.deltaTime;
                }
            }
        }

        if (p2)
        {
            if (Input.GetButtonDown("Horizontal2"))
            {
                lado = Input.GetAxisRaw("Horizontal2");
            }

            if (Input.GetButton("Horizontal2"))
            {
                if (velocity <= maxVelocity)
                {
                    velocity++;
                }
            }
            else
            {
                if (velocity >= 0.25f)
                {
                    velocity -= 0.25f;
                }
            }

            estaNoChao = Physics2D.OverlapCircle(sensor.position, .15f, chao);
            isJumping = (rb.velocity.y != 0f);

            if (estaNoChao && Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.velocity = Vector2.up * jumpHeight;
                counter = totalCount;
            }

            if (isJumping && Input.GetKey(KeyCode.UpArrow))
            {
                if (counter > 0)
                {
                    rb.velocity = Vector2.up * jumpHeight;
                    counter -= Time.deltaTime;
                }
            }
        }
    }
}
