using UnityEngine;

public class FlickeringLightObject : MonoBehaviour
{
    public GameObject lightObject;
    public float minTime = 0.05f;
    public float maxTime = 0.5f;

    private float timer;
    private float nextToggleTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (lightObject == null)
            lightObject = gameObject;

        SetNextToggleTime();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextToggleTime)
        {
            lightObject.SetActive(!lightObject.activeSelf);
            SetNextToggleTime();
            timer = 0f;
        }
    }

    void SetNextToggleTime()
    {
        nextToggleTime = Random.Range(minTime, maxTime);
    }
}
