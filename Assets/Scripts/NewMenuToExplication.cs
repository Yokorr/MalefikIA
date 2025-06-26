using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewMenuToExplication : MonoBehaviour
{
    public Button play;
    public Button settings;
    public Button exit;

    void Start()
    {
        play.onClick.AddListener(PlayGame);
        settings.onClick.AddListener(OpenSettings);
        exit.onClick.AddListener(ExitGame);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Explication");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings"); // Assure-toi que la scène "Settings" existe dans le Build Settings
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting..."); // Utile pour tester dans l'éditeur, car Application.Quit() ne fonctionne pas dans l'éditeur
    }
}
