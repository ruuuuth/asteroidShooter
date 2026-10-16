using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject shot;
    public Transform shotContent;
    public float fireRate;
    public float nextFire;


    // NUEVO: sonido de disparo
    public AudioClip shootSound;
    private AudioSource audioSource;




    public GameObject asteroid;
    public Vector3 spawnValues;
    public int asteroidCount;
    public float spawnWait;
    public float starWait;
    public float waveWait;

    public float xMin, xMax, zMin, zMax;
    private Rigidbody rb;
   

    void Start()
    {
        rb=GetComponent<Rigidbody>();
            audioSource = GetComponent<AudioSource>();

        StartCoroutine (createAsteroids());
    }

    void Update(){
        if(Input.GetButton("Fire1")&& Time.time>nextFire){
            nextFire=Time.time+fireRate;
            Instantiate(shot,shotContent.position,shotContent.rotation);
          if (shootSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(shootSound);
            }
        
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
    float h=Input.GetAxis("Horizontal");
    float v=Input.GetAxis("Vertical");
    Vector3 vector= new Vector3(h,5f,v);
    rb.linearVelocity=vector*10;
    rb.position=new Vector3(
        Mathf.Clamp(rb.position.x,xMin,xMax),6.0f,
        Mathf.Clamp(rb.position.z, zMin,zMax)
    );
    rb.rotation=Quaternion.Euler(0.0f,0.0f,rb.linearVelocity.x*-2);    
    }

    IEnumerator createAsteroids(){
        yield return new WaitForSeconds (starWait);
        while(true){
            for(int i=0;i<asteroidCount;i++){
                Vector3 spawnPosition=new Vector3(Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
                    Quaternion spawnRotation=Quaternion.identity;
                    Instantiate(asteroid,spawnPosition,spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }

    }

}
