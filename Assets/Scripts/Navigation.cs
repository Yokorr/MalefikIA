using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Navigation : MonoBehaviour
{
    //public Button menu;
    public string nextScene;

    //void Start()
    //{
    //    Cursor.visible = true;
    //    Cursor.lockState = CursorLockMode.None;
    //    if (menu != null)
    //    {
    //        menu.onClick.AddListener(NavigationScene);
    //    }
    //}
    public void NavigationScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
