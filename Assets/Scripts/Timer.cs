using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 60f; // Temps restant en secondes
    public Text timerText; // Référence à un objet UI Text pour afficher le temps

    void Start()
    {
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            timeRemaining = 0;
            EndGame();
        }
    }

    void UpdateTimerDisplay()
    {
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("Temps restant: {0:00}", seconds);
    }

    void EndGame()
    {
        // Action à effectuer lorsque le temps est écoulé
        Debug.Log("Temps écoulé! Fin de la partie.");
        // Vous pouvez charger une autre scène ou effectuer d'autres actions ici
        // Par exemple, SceneManager.LoadScene("GameOverScene");
    }
}
