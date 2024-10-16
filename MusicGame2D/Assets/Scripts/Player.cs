using UnityEngine;

public class Player : MonoBehaviour
{
    // Referência ao objeto do jogador
    public Transform playerTransform; // Atribua o transform do jogador no Inspector

    void Update()
    {
        // Verifica se a tecla "1" está sendo pressionada
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TeleportPlayer(new Vector3(-8.3f, 2.25f, 0)); 
        }
        // Verifica se a tecla "2" está sendo pressionada
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TeleportPlayer(new Vector3(-8.3f, 0, 0));
        }
        // Verifica se a tecla "3" está sendo pressionada
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TeleportPlayer(new Vector3(-8.3f, -2.25f, 0));
        }
    }

    // Método para teletransportar o jogador
    private void TeleportPlayer(Vector3 newPosition)
    {
        playerTransform.position = newPosition; // Altera a posição do jogador
    }
}
