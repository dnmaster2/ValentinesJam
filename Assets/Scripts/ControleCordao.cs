using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCordao : MonoBehaviour
{
    #region variaveis
    //joints são os dois jogadores + dois empties servindo de nós
    public List<DistanceJoint2D> joints;
    //preciso do rigidbody para ligar uma joint nele
    Rigidbody2D noCordaoPlayer1, noCordaoPlayer2;
    //ter acesso ao lugar exato do jogador e acessar rapidamente cada derivado do mesmo
    GameObject player1, player2;
    //renderiza a linha entre os jogadores
    LineRenderer lr;
    //forca com que um jogador puxa o outro
    public float forcaPuxar;
    //distancia maxima que um jogador pode puxar o outro
    public float distanciaMaxPuxar = 20;
    //booleanda para fazer só uma vez isso
    public bool controleDesativar = false;
    #endregion


    void Start()
    {
        //preenchendo as variaveis
        joints.Add(GameObject.Find("NoCordaoPlayer1").GetComponent<DistanceJoint2D>());
        joints.Add(GameObject.Find("NoCordaoPlayer2").GetComponent<DistanceJoint2D>());
        joints.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<DistanceJoint2D>());
        joints.Add(GameObject.FindGameObjectWithTag("Player2").GetComponent<DistanceJoint2D>());
        noCordaoPlayer1 = GameObject.Find("NoCordaoPlayer1").GetComponent<Rigidbody2D>();
        noCordaoPlayer2 = GameObject.Find("NoCordaoPlayer2").GetComponent<Rigidbody2D>();
        player1 = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        lr = GetComponent<LineRenderer>();
        //coloca limite nas posicoes do render para 2 (os dois jogadores)
        lr.positionCount = 2;
        //Desativa as joints
        AtivarCordao();
    }
    
    void Update()
    {
        if (player1 != null && player2 != null)
        {
            //verifica se a distancia entre os jogadores é maior que a distancia maxima(escolhida)
            if (Vector2.Distance(player1.transform.position, player2.transform.position) <= distanciaMaxPuxar)
            {
                //player2 controla a corda (esquerda)
                if (Input.GetKeyDown(KeyCode.CapsLock))
                {
                    //ativa as joints
                    AtivarCordao();
                    //congela o jogador para ele não ser puxado por si mesmo
                    player2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                }
                if (Input.GetKey(KeyCode.CapsLock))
                {
                    //diminui a distancia entre as duas joints que ligam os jogadores
                    joints[0].distance -= forcaPuxar * Time.deltaTime;
                    joints[1].distance -= forcaPuxar * Time.deltaTime;
                }
                if (Input.GetKeyUp(KeyCode.CapsLock))
                {
                    //desativa as joints
                    AtivarCordao();
                    //libera o jogador
                    player2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                }
                //player1 controla a corda (direita)
                if (Input.GetKeyDown(KeyCode.RightShift))
                {
                    //ativa as joints
                    AtivarCordao();
                    //congela o jogador para ele não ser puxado por si mesmo
                    player1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                }
                if (Input.GetKey(KeyCode.RightShift))
                {
                    //diminui a distancia entre as duas joints que ligam os jogadores
                    joints[0].distance -= forcaPuxar * Time.deltaTime;
                    joints[1].distance -= forcaPuxar * Time.deltaTime;
                }
                if (Input.GetKeyUp(KeyCode.RightShift))
                {
                    //desativa as joints
                    AtivarCordao();
                    //libera o jogador
                    player1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                }
            }
            //renderiza a linha entre os jogadores
            RenderLine();
        }
        else
        {
            //se tiver apenas um jogador na cena desativa TUDO
            if (!controleDesativar)
            {
                for (int i = 0; i < joints.Count; i++)
                {
                    if (joints[i] != null)
                    {
                        joints[i].enabled = false;
                    }
                }
                if (noCordaoPlayer1 != null)
                {
                    noCordaoPlayer1.bodyType = RigidbodyType2D.Kinematic;
                }
                if (noCordaoPlayer2 != null)
                {
                    noCordaoPlayer2.bodyType = RigidbodyType2D.Kinematic;
                }
                lr.enabled = false;
                controleDesativar = true;
            }
        }
    }
    void AtivarCordao()
    {
        //ciclo entre cada joint para inverter o estado dela
        for (int i = 0; i < joints.Count; i++)
        {
            joints[i].enabled = !joints[i].enabled;
        }
        //coloca a distancia das joints sendo a distancia entre jogadores - 1 (para cada) devido ao espaço entre os mesmos e a joint em si
        joints[0].distance = DistanciaEntreJogadores() - 2;
        joints[1].distance = DistanciaEntreJogadores() - 2;
        //volta o tipo de rigidbody para dynamic para não precisar calcular e deixar a física fazer o trabalho dela
        if (noCordaoPlayer1.isKinematic)
        {
            noCordaoPlayer1.bodyType = RigidbodyType2D.Dynamic;
        }
        //muda o tipo de rigidbody do cordao para que ele não caia infinitamente
        else
        {
            noCordaoPlayer1.bodyType = RigidbodyType2D.Kinematic;
        }
        //volta o tipo de rigidbody para dynamic para não precisar calcular e deixar a física fazer o trabalho dela
        if (noCordaoPlayer2.isKinematic)
        {
            noCordaoPlayer2.bodyType = RigidbodyType2D.Dynamic;
        }
        //muda o tipo de rigidbody do cordao para que ele não caia infinitamente
        else
        {
            noCordaoPlayer2.bodyType = RigidbodyType2D.Kinematic;
        }
    }
    //funcao que volta a distancia entre os jogadores para ser mais legivel
    float DistanciaEntreJogadores()
    {
        return Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, GameObject.FindGameObjectWithTag("Player2").transform.position);
    }
    //funcao de renderizar a linha
    void RenderLine()
    {
        //a cada frame(update) as posicoes são atualizadas pela posicao de cada jogador, com isso a linha sempre irá estar ligando os jogadores
        lr.SetPosition(0, player1.transform.position);
        lr.SetPosition(1, player2.transform.position);
    }
}
