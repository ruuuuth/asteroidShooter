using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed=0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset=new Vector2(0f,(Time.time*speed)%1);
        

    }
}
