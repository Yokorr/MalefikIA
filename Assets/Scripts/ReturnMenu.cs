using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ReturnMenu : MonoBehaviour
{
    public Button exit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (exit != null)
        {
            exit.onClick.AddListener(ExitGame);
        }
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
