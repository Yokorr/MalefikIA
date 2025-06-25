using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Spawner : MonoBehaviour
{
    // Le prefab de l'objet "chevalet" que nous voulons faire apparaître
    public GameObject easelPrefab;

    // La liste de tous les points de spawn possibles.
    // On va la remplir manuellement dans l'inspecteur.
    public List<Transform> spawnPoints;

    // Le nombre de chevalets que nous voulons faire apparaître
    public int numberOfEaselsToSpawn = 4;


    // La fonction Start est appelée une seule fois au début du jeu
    void Start()
    {
        // On vérifie qu'on a bien assigné le prefab et les points de spawn
        if (easelPrefab == null)
        {
            Debug.LogError("Le prefab du chevalet n'est pas assigné !");
            return; // On arrête l'exécution pour éviter d'autres erreurs
        }

        if (spawnPoints.Count < numberOfEaselsToSpawn)
        {
            Debug.LogError("Pas assez de points de spawn définis pour le nombre de chevalets à générer !");
            return;
        }

        SpawnEaselsAtRandomPoints();
    }

    void SpawnEaselsAtRandomPoints()
    {
        // ÉTAPE 1: Mélanger la liste des points de spawn de manière aléatoire.
        // La fonction Guid.NewGuid() génère un identifiant unique aléatoire,
        // ce qui est une excellente astuce pour obtenir un ordre aléatoire parfait.
        List<Transform> shuffledSpawnPoints = spawnPoints.OrderBy(x => System.Guid.NewGuid()).ToList();

        // ÉTAPE 2: Prendre les 4 premiers points de la liste mélangée.
        // On utilise une boucle 'for' pour parcourir le nombre d'objets que l'on veut créer.
        for (int i = 0; i < numberOfEaselsToSpawn; i++)
        {
            // On prend le point de spawn de la liste mélangée à l'index 'i'
            Transform spawnPoint = shuffledSpawnPoints[i];

            // ÉTAPE 3: Faire apparaître (instancier) un chevalet à la position de ce point de spawn.
            Instantiate(easelPrefab, spawnPoint.position, spawnPoint.rotation);

            Debug.Log("Chevalet généré à la position de " + spawnPoint.name);
        }
    }
}
