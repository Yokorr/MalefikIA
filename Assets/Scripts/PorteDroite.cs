using System.Threading.Tasks;
using UnityEngine;

public class PorteDroite : MonoBehaviour
{
    public float speed;
    public float maxX;  // 3.55
    public int direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    async void Update()
    {
        if (direction == 1)
        {
            if (!(transform.position.x >= maxX))
            {
                transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
                Debug.Log(transform.position.x);
            }
        }

        else if (direction == 2)
        {
            if (!(transform.position.x <= maxX))
            {
                transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
                Debug.Log(transform.position.x);
            }
        }
    }
}
