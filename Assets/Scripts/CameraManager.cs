using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public GameObject Camera1;
    public GameObject Camera2;

    public float delay = 15f;
    private float timer = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camera1.gameObject.SetActive(true);
        Camera2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > delay)
        {
            Camera1.gameObject.SetActive(false);
            Camera2.gameObject.SetActive(true);
        }
    }
}
