using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Replay : MonoBehaviour
{
    public Button replay;
    public Button exit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (replay != null)
        {
            replay.onClick.AddListener(PlayGame);
        }
        if (exit != null)
        {
            exit.onClick.AddListener(ExitGame);
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Ascenseur 1er");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
