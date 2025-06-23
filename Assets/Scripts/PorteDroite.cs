using System.Threading.Tasks;
using UnityEngine;

public class PorteDroite : MonoBehaviour
{
    public float speed;
    public float maxX;  // 3.55
    public int direction;

    private float originalX;
    private bool canMove = false;
    private bool goingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        originalX = transform.position.x;

        Debug.Log("Avant delay 1");
        await Task.Delay(5000);
        Debug.Log("Apres delay 1");

        canMove = true;
        Debug.Log(originalX);
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
        {
            return;
        }

        if (goingRight) 
        {
            if (direction == 1)
            {
                if (transform.position.x < maxX)
                {
                    transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
                }

                else
                {
                    goingRight = false;
                }
            }

            else if (direction == 2)
            {
                if (transform.position.x > maxX)
                {
                    transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
                }

                else
                {
                    goingRight = false;
                }
            }
        }

        else
        {
            if (direction == 1)
            {
                if (transform.position.x > originalX)
                {
                    transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
                }

                else
                {
                    goingRight = true;
                }
            }

            else if (direction == 2)
            {
                if (transform.position.x < originalX)
                {
                    transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
                }

                else
                {
                    goingRight = true;
                }
            }
        }
    }
}
