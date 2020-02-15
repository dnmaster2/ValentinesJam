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
    public float totalCount;
    public Transform sensor;
    public LayerMask pulavel;
    public bool estaNoChao, isJumping, isClimbing;

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

            estaNoChao = Physics2D.OverlapCircle(sensor.position, .15f, pulavel);
            isJumping = !estaNoChao;

            if (estaNoChao && Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.velocity = transform.up * jumpHeight;
            }

            if (isJumping && Input.GetKey(KeyCode.UpArrow))
            {
                if (counter > 0)
                {
                    rb.velocity = transform.up * jumpHeight;
                    counter -= Time.deltaTime;
                }
            }

            if (estaNoChao || Input.GetKeyUp(KeyCode.UpArrow))
            {
                counter = totalCount;
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

            if (!isClimbing)
            {
                estaNoChao = Physics2D.OverlapCircle(sensor.position, .15f, pulavel);
                isJumping = !estaNoChao;

                if (estaNoChao && Input.GetKeyDown(KeyCode.W))
                {
                    rb.velocity = transform.up * jumpHeight;
                }

                if (isJumping && Input.GetKey(KeyCode.W))
                {
                    if (counter > 0)
                    {
                        rb.velocity = transform.up * jumpHeight;
                        counter -= Time.deltaTime;
                    }
                }

                if(estaNoChao || Input.GetKeyUp(KeyCode.W))
                {
                    counter = totalCount;
                }
            }
        }

        if (isClimbing)
        {
            print("yey");
            rb.gravityScale = 0f;
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = Vector2.up * 5f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = Vector2.down * 5f;              
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && collision.gameObject.CompareTag("Parede") && p2)
        {
            print("opaaa");
            isClimbing = true;
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Parede") && p2)
        {
            isClimbing = false;
            rb.gravityScale = 2f;
        }
    }
}
