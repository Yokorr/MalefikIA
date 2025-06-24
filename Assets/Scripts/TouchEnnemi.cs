using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchEnnemi : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Ennemi"))
        {
            Debug.Log("Le Joueur (avec Character Controller) a touché l'ennemi !");

            SceneManager.LoadScene("Menu");
        }
    }
}
