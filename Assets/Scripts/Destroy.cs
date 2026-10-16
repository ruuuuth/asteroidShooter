using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
     public AudioClip sonidoExplosion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider obj) {
          if (sonidoExplosion != null)
        {
            AudioSource.PlayClipAtPoint(
                sonidoExplosion,
                transform.position,
                1.5f
            );
        }
        Destroy (obj.gameObject);
        Destroy (gameObject);
    }
}
