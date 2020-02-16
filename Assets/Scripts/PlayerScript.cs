using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //Rigidbody e bool de players
    Rigidbody2D rb;
    public bool p1, p2;
    Color corzinha;

    //Variaveis Movimento
    public float velocity;
    public float maxVelocity;
    float lado;
    public float stopVelocity;

    //Variaveis Pulo
    public float jumpHeight;
    public float counter;
    public float totalCount;
    public Transform sensor;
    public LayerMask pulavel;
    public bool estaNoChao, isJumping;

    //Variaveis escalar
    public bool isClimbing;

    //Variaveis Comportamento com Parceiros
    public bool comParceiro;
    PartnersFunctionsScript partners;

    //Variaveis para vitória/derrota
    public static int playersNaSaida;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        partners = GetComponent<PartnersFunctionsScript>();
        totalCount = counter;
        corzinha = new Color(0.4185208f, 0.7152144f, 0.9339623f);
    }

    void Update()
    {
        if (playersNaSaida == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

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
                if (velocity >= stopVelocity)
                {
                    velocity -= stopVelocity;
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

            if (estaNoChao)
            {
                counter = totalCount;
            }

            if (comParceiro && Input.GetKey(KeyCode.Return))
            {
                partners.ResetPartners();
                comParceiro = false;
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

                if (estaNoChao)
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

        if (comParceiro && Input.GetKey(KeyCode.Q))
        {
            partners.ResetPartners();
            comParceiro = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Espelho"))
        {
            playersNaSaida++;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && collision.gameObject.CompareTag("Parede") && p2)
        {
            print("opaaa");
            isClimbing = true;
            GetComponent<SpriteRenderer>().color = new Color(0.1921569f, 0.3294118f, 0.4313726f);
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Parede") && p2)
        {
            isClimbing = false;
            rb.gravityScale = 2f;
            GetComponent<SpriteRenderer>().color = corzinha;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((Input.GetKeyDown(KeyCode.Return) && p1) || (Input.GetKeyDown(KeyCode.Q) && p2) && !comParceiro)
        {
            if (collision.gameObject.CompareTag("Velocidade"))
            {
                partners.ParceiroVelocidadeOn();
            }
            if (collision.gameObject.CompareTag("Antiespinho"))
            {

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Velocidade"))
        {
            comParceiro = true;
        }
        if (other.CompareTag("Espelho"))
        {
            playersNaSaida--;
        }
    }
}
