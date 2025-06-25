using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PorteArriere : MonoBehaviour
{
    public int delay = 20;

    public float speed = 1;
    public float maxX = 3.55f;
    public int direction = 1;

    public string sceneName;

    private float originalX;
    private bool canMove = false;

    private int etat = 1;
    private float timer = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        maxX = transform.position.x + (maxX > 0 ? 2.3f : -2.3f);

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

        if (etat == 1)
        {
            Debug.Log("Ouverture de porte");
            if (direction == 1)
            {
                if (transform.position.x < maxX)
                {
                    transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
                }

                else
                {
                    etat = 2;
                    timer = 0f;
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
                    etat = 2;
                    timer = 0f;
                }
            }
        }

        else if (etat == 2) 
        {
            Debug.Log("Attente de 2s");
            timer += Time.deltaTime;

            if (timer > 2f)
            {
                timer = 0f;
                etat = 4;
            }
        }

        else if (etat == 4)
        {
            //timer += Time.deltaTime;
            //if (timer > 2f)
            //{
                SceneManager.LoadScene(sceneName);
            //}
        }
    }
}
