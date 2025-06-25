using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class ChangeSceneExplication : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;

    public Button Button1; 
    public Button Button2;
    public Button Button3; 

    void Start()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        canvas3.SetActive(false);

   
        if (Button1 != null)
        {
            Button1.onClick.AddListener(OnButton1Click);
        }
        

        if (Button2 != null)
        {
            Button2.onClick.AddListener(OnButton2Click);
        }
        

        if (Button3 != null)
        {
            Button3.onClick.AddListener(OnButton3Click);
        }
        

    }

    public void OnButton1Click()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }

    public void OnButton2Click()
    {
        canvas2.SetActive(false);
        canvas3.SetActive(true);
    }

    public void OnButton3Click()
    {
        SceneManager.LoadScene("ascenseur 1er");
    }
}