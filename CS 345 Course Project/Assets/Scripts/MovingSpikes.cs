using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpikes : MonoBehaviour
{
    public float speed;
    public Transform[] positions;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = positions[i].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, positions[i].position) < 0.02f)
        {
            i++;
            if(i == positions.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, positions[i].position, speed * Time.deltaTime);
    }
}
