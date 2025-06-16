using UnityEngine;

public class MovimentoCorrida : MonoBehaviour
{
    private float esquerda = 15f;
    private float meio = 12.75f;
    private float direita = 10.50f;

    private float alvoZ;
    private float velocidadeZ = 10f;

    private int posicaoAtual = 1;

    public float velocidadeX = f;  // velocidade constante no eixo X

    void Start()
    {
        alvoZ = meio;
        transform.position = new Vector3(transform.position.x, transform.position.y, alvoZ);
    }

    void Update()
    {
        // Movimento lateral no Z (A e D)
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (posicaoAtual > 0)
            {
                posicaoAtual--;
                AtualizaAlvo();
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (posicaoAtual < 2)
            {
                posicaoAtual++;
                AtualizaAlvo();
            }
        }

        // Movimento suave no Z
        Vector3 pos = transform.position;
        pos.z = Mathf.MoveTowards(pos.z, alvoZ, velocidadeZ * Time.deltaTime);

        // Movimento contínuo no X
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
}
