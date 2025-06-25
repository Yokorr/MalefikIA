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
    // La liste complète de tous les points de spawn possibles.
    public List<Transform> spawnPoints;


    void Start()
    {
        // --- Vérifications initiales ---
        if (easelPrefab == null || enemyPrefab == null)
        {
            Debug.LogError("Un des prefabs (chevalet ou ennemi) n'est pas assigné !");
            return;
        }

        // On vérifie qu'on a assez de points de spawn pour tout le monde
        if (spawnPoints.Count < numberOfEaselsToSpawn + numberOfEnemiesToSpawn)
        {
            Debug.LogError("Pas assez de points de spawn pour générer tous les objets !");
            return;
        }

        SpawnObjects();
    }

    void SpawnObjects()
    {
        // ÉTAPE 1: Mélanger la liste complète des points de spawn une seule fois.
        List<Transform> shuffledSpawnPoints = spawnPoints.OrderBy(x => System.Guid.NewGuid()).ToList();

        // On crée un compteur pour savoir où nous en sommes dans la liste mélangée.
        int spawnPointIndex = 0;

        // --- ÉTAPE 2: Faire apparaître les chevalets ---
        Debug.Log("--- Début du spawn des chevalets ---");
        for (int i = 0; i < numberOfEaselsToSpawn; i++)
        {
            // On prend le point de spawn actuel
            Transform spawnPoint = shuffledSpawnPoints[spawnPointIndex];
            Instantiate(easelPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Chevalet généré à " + spawnPoint.name);

            // On avance notre compteur pour le prochain objet
            spawnPointIndex++;
        }

        // --- ÉTAPE 3: Faire apparaître les ennemis ---
        Debug.Log("--- Début du spawn des ennemis ---");
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            // On continue là où on s'était arrêté dans la liste mélangée
            Transform spawnPoint = shuffledSpawnPoints[spawnPointIndex];
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Ennemi généré à " + spawnPoint.name);

            // On avance à nouveau le compteur
            spawnPointIndex++;
        }
    }
}
