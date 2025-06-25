using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Spawner : MonoBehaviour
{
    // Le prefab de l'objet "chevalet" que nous voulons faire appara�tre
    public GameObject easelPrefab;

    // La liste de tous les points de spawn possibles.
    // On va la remplir manuellement dans l'inspecteur.
    public List<Transform> spawnPoints;

    // Le nombre de chevalets que nous voulons faire appara�tre
    public int numberOfEaselsToSpawn = 4;


    // La fonction Start est appel�e une seule fois au d�but du jeu
    void Start()
    {
        // On v�rifie qu'on a bien assign� le prefab et les points de spawn
        if (easelPrefab == null)
        {
            Debug.LogError("Le prefab du chevalet n'est pas assign� !");
            return; // On arr�te l'ex�cution pour �viter d'autres erreurs
        }

        if (spawnPoints.Count < numberOfEaselsToSpawn)
        {
            Debug.LogError("Pas assez de points de spawn d�finis pour le nombre de chevalets � g�n�rer !");
            return;
        }

        SpawnEaselsAtRandomPoints();
    }

    void SpawnEaselsAtRandomPoints()
    {
        // �TAPE 1: M�langer la liste des points de spawn de mani�re al�atoire.
        // La fonction Guid.NewGuid() g�n�re un identifiant unique al�atoire,
        // ce qui est une excellente astuce pour obtenir un ordre al�atoire parfait.
        List<Transform> shuffledSpawnPoints = spawnPoints.OrderBy(x => System.Guid.NewGuid()).ToList();

        // �TAPE 2: Prendre les 4 premiers points de la liste m�lang�e.
        // On utilise une boucle 'for' pour parcourir le nombre d'objets que l'on veut cr�er.
        for (int i = 0; i < numberOfEaselsToSpawn; i++)
        {
            // On prend le point de spawn de la liste m�lang�e � l'index 'i'
            Transform spawnPoint = shuffledSpawnPoints[i];

            // �TAPE 3: Faire appara�tre (instancier) un chevalet � la position de ce point de spawn.
            Instantiate(easelPrefab, spawnPoint.position, spawnPoint.rotation);

            Debug.Log("Chevalet g�n�r� � la position de " + spawnPoint.name);
        }
    }
}
