using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionDisquette : MonoBehaviour
{
    public int nbDisquettes = 0;
    public int nbPoints = 0;
    public string endScene = "end";

    private void Update()
    { 
        if(nbPoints == 4)
        {
            SceneManager.LoadScene(endScene);
        }
    }

    // Cette fonction est appelée chaque fois que le joueur heurte un autre collider
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // ÉTAPE 1: On vérifie si l'objet que nous avons heurté a bien le tag "Chevalet"
        if (hit.gameObject.CompareTag("Borne"))
        {
            // ÉTAPE 2: On cherche le composant Light qui est un enfant de l'objet heurté.
            // GetComponentInChildren est parfait pour ça, car il cherche sur l'objet lui-même ET sur tous ses enfants.
            Light lumiereDuChevalet = hit.gameObject.GetComponentInChildren<Light>();

            // ÉTAPE 3: On vérifie qu'on a bien trouvé une lumière (c'est une bonne pratique pour éviter les erreurs)
            if (lumiereDuChevalet != null)
            {
                // ÉTAPE 4: On change la couleur de la lumière en rouge.
                lumiereDuChevalet.color = Color.red;
                nbPoints++;

                // Optionnel : un message pour confirmer que ça a fonctionné
                Debug.Log("La lumière du chevalet est passée au rouge !");
            }
            else
            {
                Debug.LogWarning("Le chevalet a été touché, mais aucune lumière enfant n'a été trouvée.");
            }
        }
    }

    public void AddDisquette()
    {
        nbDisquettes++;
    }
}
