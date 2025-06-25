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

    // Cette fonction est appel�e chaque fois que le joueur heurte un autre collider
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // �TAPE 1: On v�rifie si l'objet que nous avons heurt� a bien le tag "Chevalet"
        if (hit.gameObject.CompareTag("Borne"))
        {
            // �TAPE 2: On cherche le composant Light qui est un enfant de l'objet heurt�.
            // GetComponentInChildren est parfait pour �a, car il cherche sur l'objet lui-m�me ET sur tous ses enfants.
            Light lumiereDuChevalet = hit.gameObject.GetComponentInChildren<Light>();

            // �TAPE 3: On v�rifie qu'on a bien trouv� une lumi�re (c'est une bonne pratique pour �viter les erreurs)
            if (lumiereDuChevalet != null)
            {
                // �TAPE 4: On change la couleur de la lumi�re en rouge.
                lumiereDuChevalet.color = Color.red;
                nbPoints++;

                // Optionnel : un message pour confirmer que �a a fonctionn�
                Debug.Log("La lumi�re du chevalet est pass�e au rouge !");
            }
            else
            {
                Debug.LogWarning("Le chevalet a �t� touch�, mais aucune lumi�re enfant n'a �t� trouv�e.");
            }
        }
    }

    public void AddDisquette()
    {
        nbDisquettes++;
    }
}
