using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class FollowerAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;

    void Start()
    {
        // On r�cup�re le composant NavMeshAgent attach� � cet ennemi
        agent = GetComponent<NavMeshAgent>();

        // On trouve le joueur dans la sc�ne gr�ce � son tag "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
    }

    void Update()
    {
        // Si le joueur existe, on dit � l'agent de se diriger vers sa position
        if (playerTransform != null)
        {
            agent.SetDestination(playerTransform.position);
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
