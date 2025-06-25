using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Spawner : MonoBehaviour
{
    [Header("Configuration des Chevalets")]
    public GameObject easelPrefab;
    public int numberOfEaselsToSpawn = 4;

    [Header("Configuration des Ennemis")]
    public GameObject enemyPrefab; // NOUVEAU : Le prefab de l'ennemi
    public int numberOfEnemiesToSpawn = 4; // NOUVEAU : Le nombre d'ennemis

    [Header("Points de Spawn")]
    // La liste compl�te de tous les points de spawn possibles.
    public List<Transform> spawnPoints;


    void Start()
    {
        // --- V�rifications initiales ---
        if (easelPrefab == null || enemyPrefab == null)
        {
            Debug.LogError("Un des prefabs (chevalet ou ennemi) n'est pas assign� !");
            return;
        }

        // On v�rifie qu'on a assez de points de spawn pour tout le monde
        if (spawnPoints.Count < numberOfEaselsToSpawn + numberOfEnemiesToSpawn)
        {
            Debug.LogError("Pas assez de points de spawn pour g�n�rer tous les objets !");
            return;
        }

        SpawnObjects();
    }

    void SpawnObjects()
    {
        // �TAPE 1: M�langer la liste compl�te des points de spawn une seule fois.
        List<Transform> shuffledSpawnPoints = spawnPoints.OrderBy(x => System.Guid.NewGuid()).ToList();

        // On cr�e un compteur pour savoir o� nous en sommes dans la liste m�lang�e.
        int spawnPointIndex = 0;

        // --- �TAPE 2: Faire appara�tre les chevalets ---
        Debug.Log("--- D�but du spawn des chevalets ---");
        for (int i = 0; i < numberOfEaselsToSpawn; i++)
        {
            // On prend le point de spawn actuel
            Transform spawnPoint = shuffledSpawnPoints[spawnPointIndex];
            Instantiate(easelPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Chevalet g�n�r� � " + spawnPoint.name);

            // On avance notre compteur pour le prochain objet
            spawnPointIndex++;
        }

        // --- �TAPE 3: Faire appara�tre les ennemis ---
        Debug.Log("--- D�but du spawn des ennemis ---");
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            // On continue l� o� on s'�tait arr�t� dans la liste m�lang�e
            Transform spawnPoint = shuffledSpawnPoints[spawnPointIndex];
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Ennemi g�n�r� � " + spawnPoint.name);

            // On avance � nouveau le compteur
            spawnPointIndex++;
        }
    }
}
