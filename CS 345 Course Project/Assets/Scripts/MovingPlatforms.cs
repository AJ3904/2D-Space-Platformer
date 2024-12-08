using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public bool active = false;
    public float speed;
    public int startingPoint;
    public Transform[] positions;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        transform.position = positions[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
            if(Vector2.Distance(transform.position, positions[0].position) == 0 && audioSource != null){
                audioSource.Play();
            }
            transform.position = Vector2.MoveTowards(transform.position, positions[1].position, speed * Time.deltaTime);
        }
        else{
            if(Vector2.Distance(transform.position, positions[1].position) == 0 && audioSource != null){
                audioSource.Play();
            }            
            transform.position = Vector2.MoveTowards(transform.position, positions[0].position, speed * Time.deltaTime);
        }
    }
}
