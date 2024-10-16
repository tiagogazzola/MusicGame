using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 5f;  // Velocidade do tiro, edit�vel no Inspector

    void Update()
    {
        // Move o tiro para a esquerda
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Destr�i o tiro se sair da tela (opcional)
        if (transform.position.x < -10)  // Ajuste o valor conforme necess�rio
        {
            Destroy(gameObject);
        }
    }
}
