using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public float delay = 5f;
    public GameObject audioClip1;
    public GameObject audioClip2;

    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > delay)
        {
            audioClip1.gameObject.SetActive(true);
            audioClip2.gameObject.SetActive(true);
        }
    }
}
