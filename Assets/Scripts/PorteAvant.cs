using System.Threading.Tasks;
using UnityEngine;

public class PorteAvant : MonoBehaviour
{
    public int delay = 5;

    public float speed = 1;
    public float maxX = 3.55f;
    public int direction = 1;

    private bool canMove = false;

    private int etat = 2;
    private float timer = 0f;
    private float originalX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        originalX = transform.position.x - (maxX > 0 ? 2.3f : -2.3f);

        Debug.Log("Avant delay 1");
        await Task.Delay(delay * 1000);
        Debug.Log("Apres delay 1");

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
        {
            return;
        }

        else if (etat == 2) 
        {
            //Debug.Log("Attente de 2s");
            timer += Time.deltaTime;

            if (timer > 2f)
            {
                etat = 3;
            }
        }

        else if (etat == 3)
        {
            Debug.Log(transform.position);
            //Debug.Log("Fermeture de porte");
            if (direction == 1)
            {
                if (transform.position.x > originalX)
                {
                    transform.position += new Vector3(-speed, 0f, 0f) * Time.deltaTime;
                }

                else
                {
                    etat = 4;
                    canMove = false;
                }
            }

            else if(direction == 2)
            {
                if (transform.position.x < originalX)
                {
                    transform.position += new Vector3(-speed, 0f, 0f) * Time.deltaTime;
                }

                else
                {
                    etat = 4;
                    canMove = false;
                }
            }
        }

        else if (etat == 4)
        {
            Debug.Log("Fin");
            return;
        }
    }
}
