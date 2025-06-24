using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upsol : MonoBehaviour
{
    public float speed = 21;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().linearVelocity = new Vector3(0, speed, 0);
    }
}
