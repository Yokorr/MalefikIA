using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LastChoice : MonoBehaviour
{
    public Button next;
    public Button end;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (next != null)
        {
            next.onClick.AddListener(nextGame);
        }
        if (end != null)
        {
            end.onClick.AddListener(endGame);
        }
    }

    public void nextGame()
    {
        SceneManager.LoadScene("FinAlive");
    }

    public void endGame()
    {
        SceneManager.LoadScene("FinDead");
    }
}
