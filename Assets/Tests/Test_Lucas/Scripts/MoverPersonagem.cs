using UnityEngine;

public class MovimentoCorrida : MonoBehaviour
{
    private float esquerda = 15f;
    private float meio = 12.75f;
    private float direita = 10.50f;

    private float alvoZ;
    private float velocidadeZ = 10f;

    private int posicaoAtual = 1;

    public float velocidadeX = 5f;  // velocidade constante no eixo X

    public float forcaPulo = 7f;
    public float alturaOriginal = 2f;
    public float alturaEscorrega = 1f;
    public float duracaoEscorrega = 1f;

    private bool estaPulando = false;
    private bool estaEscorregando = false;
    private float tempoEscorrega = 0f;

    private Rigidbody rb;
    private CapsuleCollider col;

    void Start()
    {
        alvoZ = meio;
        transform.position = new Vector3(transform.position.x, transform.position.y, alvoZ);

        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        alturaOriginal = col.height;
    }

    void Update()
    {
        // Movimento lateral (A e D)
        if (Input.GetKeyDown(KeyCode.A) && posicaoAtual > 0)
        {
            posicaoAtual--;
            AtualizaAlvo();
        }
        else if (Input.GetKeyDown(KeyCode.D) && posicaoAtual < 2)
        {
            posicaoAtual++;
            AtualizaAlvo();
        }

        // Pulo (W)
        if (Input.GetKeyDown(KeyCode.W) && !estaPulando && IsGrounded())
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            estaPulando = true;
        }

        // Escorregar (S)
        if (Input.GetKeyDown(KeyCode.S) && !estaEscorregando && IsGrounded())
        {
            estaEscorregando = true;
            tempoEscorrega = duracaoEscorrega;
            col.height = alturaEscorrega;
            col.center = new Vector3(col.center.x, alturaEscorrega / 2f, col.center.z);
        }

        if (estaEscorregando)
        {
            tempoEscorrega -= Time.deltaTime;
            if (tempoEscorrega <= 0f)
            {
                estaEscorregando = false;
                col.height = alturaOriginal;
                col.center = new Vector3(col.center.x, alturaOriginal / 2f, col.center.z);
            }
        }

        // Movimento lateral suave
        Vector3 pos = transform.position;
        pos.z = Mathf.MoveTowards(pos.z, alvoZ, velocidadeZ * Time.deltaTime);

        // Movimento constante no X
        pos.x += velocidadeX * Time.deltaTime;

        transform.position = pos;
    }

    void AtualizaAlvo()
    {
        if (posicaoAtual == 0)
            alvoZ = esquerda;
        else if (posicaoAtual == 1)
            alvoZ = meio;
        else
            alvoZ = direita;
    }

    void OnTriggerEnter(Collider other)
    {
        estaPulando = false;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.4f);
    }
}
