using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string nextScene;

    void OnTriggerEnter(Collider touch)
    {
        if (touch.CompareTag("Player"))
        {
            GestionDisquette player = touch.GetComponent<GestionDisquette>();
            if (player != null)
            {
                if (player.nbDisquettes == 4)
                {
                    SceneManager.LoadScene(nextScene);
                }
            }
            
        }
    }
}
