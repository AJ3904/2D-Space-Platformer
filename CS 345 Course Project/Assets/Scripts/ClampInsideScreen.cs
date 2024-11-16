using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampInsideScreen : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectHalfWidth;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        objectHalfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        float clampedX = Mathf.Clamp(transform.position.x, -screenBounds.x + objectHalfWidth, screenBounds.x - objectHalfWidth);
        Vector2 pos = transform.position;
        pos.x = clampedX;
        transform.position = pos;
    }
}
