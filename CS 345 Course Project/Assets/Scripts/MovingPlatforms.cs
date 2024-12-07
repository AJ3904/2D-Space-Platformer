using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public bool active = false;
    public float speed;
    public int startingPoint;
    public Transform[] positions;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = positions[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
            transform.position = Vector2.MoveTowards(transform.position, positions[1].position, speed * Time.deltaTime);
        }
        else{
            transform.position = Vector2.MoveTowards(transform.position, positions[0].position, speed * Time.deltaTime);
        }
    }
}
