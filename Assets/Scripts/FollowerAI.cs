using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class FollowerAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;

    void Start()
    {
        // On récupère le composant NavMeshAgent attaché à cet ennemi
        agent = GetComponent<NavMeshAgent>();

        // On trouve le joueur dans la scène grâce à son tag "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
    }

    void Update()
    {
        // Si le joueur existe, on dit à l'agent de se diriger vers sa position
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
