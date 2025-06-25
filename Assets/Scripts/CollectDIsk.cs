using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDIsk : MonoBehaviour
{
    void OnTriggerEnter(Collider touch)
    {
        if (touch.CompareTag("Player"))
        {
            GestionDisquette player = touch.GetComponent<GestionDisquette>();
            if (player != null)
            {
                player.AddDisquette();
                Destroy(gameObject);
            }
        }
    }
}

