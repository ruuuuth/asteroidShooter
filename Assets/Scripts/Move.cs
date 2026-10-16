using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody> ().linearVelocity=transform.forward* speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
