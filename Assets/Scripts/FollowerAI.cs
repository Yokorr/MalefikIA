using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class FollowerAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;
    private Vector3 startingPosition;

    [Header("Paramètres de l'IA")]
    public float aggroRange = 15f;

    void Start()
    {
        // On récupère le composant NavMeshAgent attaché à cet ennemi
        agent = GetComponent<NavMeshAgent>();
        startingPosition = transform.position;

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
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            if (distanceToPlayer <= aggroRange)
            {
                // Le joueur est assez proche, donc on met à jour la destination de l'ennemi.
                agent.SetDestination(playerTransform.position);
            }
            else
            {
                float distanceToStart = Vector3.Distance(transform.position, startingPosition);
                // Le joueur est trop loin. L'ennemi s'arrête de le suivre.
                
                if (distanceToStart >= 0.5f)
                {
                    agent.SetDestination(startingPosition);
                }
            }
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
