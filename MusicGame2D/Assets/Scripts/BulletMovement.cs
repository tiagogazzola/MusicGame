using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 5f;  // Velocidade do tiro, editável no Inspector

    void Update()
    {
        // Move o tiro para a esquerda
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Destrói o tiro se sair da tela (opcional)
        if (transform.position.x < -10)  // Ajuste o valor conforme necessário
        {
            Destroy(gameObject);
        }
    }
}
