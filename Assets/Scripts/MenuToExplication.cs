using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuToExplication : MonoBehaviour
{
    public Button play;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        play.onClick.AddListener(PlayGame);
    }

    // Update is called once per frame
    public void PlayGame()
    {
        SceneManager.LoadScene("Explication");
    }
}
