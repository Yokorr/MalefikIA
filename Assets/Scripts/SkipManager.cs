using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SkipManager : MonoBehaviour
{
    public GameObject texteBox;
    public string sceneName;

    private KeyCode skip = KeyCode.P;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        texteBox.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5f)
        {
            texteBox.gameObject.SetActive(true);

            if (Input.GetKeyDown(skip))
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
