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
    public float lado;
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
    int index;

    //Variaveis para vitória/derrota
    public static int playersNaSaida;
    public int thisIndex;
    //Variveis de Animação
    public PlayerAnimationScript playerAnimation;
    void Awake()
    {
        //Loading dos componentes
        rb = GetComponent<Rigidbody2D>();
        partners = GetComponent<PartnersFunctionsScript>();
        playerAnimation = GetComponent<PlayerAnimationScript>();
        //Registro das variaveis importantes
        totalCount = counter;
        corzinha = new Color(0.4185208f, 0.7152144f, 0.9339623f);
        thisIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (playersNaSaida == 2)
        {
            //Detecta se há 2 players na saida, se sim, passa para o proximo nivel
            SceneManager.LoadScene(thisIndex + 1);
        }

        //O Código é beeeem repetitivo pela falta de tempo de otimização.
        //Peço perdão pelo vacilo
     
        //Movimentação base do jogador
        rb.velocity = new Vector2(lado * velocity, rb.velocity.y);
        //Seleção do player um
        if (p1)
        {
            //Grava de que lado o input foi registrado
            if (Input.GetButtonDown("Horizontal"))
            {
                playerAnimation.Walk(true);
                lado = Input.GetAxisRaw("Horizontal");
            }
            //Aumenta a velocidade gradualmente até o seu maximo.
            if (Input.GetButton("Horizontal"))
            {
                if (velocity <= maxVelocity)
                {
                    velocity++;
                }
            }
            //Freia o personagem aos poucos, deixando um controle em o quão rapido ele pode parar
            else
            {
                playerAnimation.Walk(false);
                if (velocity >= stopVelocity)
                {
                    velocity -= stopVelocity;
                }
            }
            //Checando se ele está no chão desenhando um circulo
            estaNoChao = Physics2D.OverlapCircle(sensor.position, .15f, pulavel);
            //A booleana de pulo sempre é o inverso do sensor.
            isJumping = !estaNoChao;

            //Instrução do pulo
            if (estaNoChao && Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerAnimation.Jump();
                rb.velocity = transform.up * jumpHeight;
            }

            //O pulo é relativo ao tempo de pressionamento da tecla, quanto mais tempo segura, mais você sobe.
            if (isJumping && Input.GetKey(KeyCode.UpArrow))
            {
                if (counter > 0)
                {
                    rb.velocity = transform.up * jumpHeight;
                    counter -= Time.deltaTime;
                }
                else
                {
                    playerAnimation.Fall();
                }
            }
            //Reinicio do contador que trava o pulo carregado
            if (estaNoChao)
            {
                playerAnimation.Land();
                counter = totalCount;
            }
            //Se ele estiver com o parceiro nas costas e apertar enter, ele larga ele no cenário.
            if (comParceiro && Input.GetKey(KeyCode.Return))
            {
                partners.ResetPartners(index, new Vector2(transform.position.x + 1, transform.position.y + 1));
                comParceiro = false;
                gameObject.name = "Player";
            }
        }

        if (p2)
        {
            //Grava de que lado o input foi registrado
            if (Input.GetButtonDown("Horizontal2"))
            {
                playerAnimation.Walk(true);
                lado = Input.GetAxisRaw("Horizontal2");
            }

            //Aumenta a velocidade gradualmente até o seu maximo.
            if (Input.GetButton("Horizontal2"))
            {
                if (velocity <= maxVelocity)
                {
                    velocity++;
                }
            }
            //Freia o personagem aos poucos, deixando um controle em o quão rapido ele pode parar
            else
            {
                playerAnimation.Walk(false);
                if (velocity >= 0.25f)
                {
                    velocity -= 0.25f;
                }
            }

            //O player2 pode escalar, então o check de pulo é somente se ele não esta escalando
            if (!isClimbing)
            {
                //Checando se ele está no chão desenhando um circulo
                estaNoChao = Physics2D.OverlapCircle(sensor.position, .15f, pulavel);
                //A booleana de pulo sempre é o inverso do sensor.
                isJumping = !estaNoChao;

                //Instrução do pulo
                if (estaNoChao && Input.GetKeyDown(KeyCode.W))
                {
                    playerAnimation.Jump();
                    rb.velocity = transform.up * jumpHeight;
                }

                //O pulo é relativo ao tempo de pressionamento da tecla, quanto mais tempo segura, mais você sobe.
                if (isJumping && Input.GetKey(KeyCode.W))
                {
                    if (counter > 0)
                    {
                        rb.velocity = transform.up * jumpHeight;
                        counter -= Time.deltaTime;
                    }
                    else
                    {
                        playerAnimation.Fall();
                    }
                }

                //Reinicio do contador que trava o pulo carregado
                if (estaNoChao)
                {
                    playerAnimation.Land();
                    counter = totalCount;
                }
            }
        }
        //Se ele ativar a escalada
        if (isClimbing)
        {
            //Gravidade é desligada para que ele não caia
            rb.gravityScale = 0f;
            //O controle da escalada é simplificado, com um botão ele sobe tudo, com outro ele desce tudo.
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = Vector2.up * 5f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = Vector2.down * 5f;
            }
        }
        //Se ele estiver com o parceiro nas costas e apertar enter, ele larga ele no cenário.
        if (comParceiro && Input.GetKey(KeyCode.Q))
        {
            //Instrução de instantiate, gera uma coordenada distante suficiente do player e
            //Aponta qual parceiro está desmontando
            float direction = -Input.GetAxisRaw("Horizontal2");
            partners.ResetPartners(index, new Vector2(transform.position.x + direction, transform.position.y + direction));
            comParceiro = false;
            gameObject.name = "Player2";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Se chegarem no espelho, o numero de players na saida aumenta. É uma variavel estática então consegue ser somada
        if (other.CompareTag("Espelho"))
        {
            playersNaSaida++;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //Trocando para o modo de escalada com LShift próximo a uma parede
        if (Input.GetKeyDown(KeyCode.LeftShift) && collision.gameObject.CompareTag("Parede") && p2)
        {
            isClimbing = true;
            GetComponent<SpriteRenderer>().color = new Color(0.1921569f, 0.3294118f, 0.4313726f);
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Se ele sai da parede, as variaveis voltam ao default
        if (collision.gameObject.CompareTag("Parede") && p2)
        {
            isClimbing = false;
            rb.gravityScale = 2f;
            GetComponent<SpriteRenderer>().color = corzinha;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Interação com os parceiros, cada um dos inputs quando reconhecidos, rodam uma função num script separado.
        if ((Input.GetKeyDown(KeyCode.Return) && p1) || (Input.GetKeyDown(KeyCode.Q) && p2) && !comParceiro)
        {
            if (collision.gameObject.CompareTag("Velocidade"))
            {
                StartCoroutine(partners.ParceiroVelocidadeOn());
                index = 1;
                return;
            }
            if (collision.gameObject.CompareTag("Antiespinho"))
            {
                StartCoroutine(partners.ParceiroAntiespinhoOn());
                index = 0;
                return;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Retira o contador caso um dos players saiam do espelho
        if (other.CompareTag("Espelho"))
        {
            playersNaSaida--;
        }
    }
}
