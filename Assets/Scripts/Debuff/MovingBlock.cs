using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    // Start is called before the first frame update
    private bool dirUp = true;
    public float speed = 2.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dirUp)
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        else
            transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y >= 4.0f)
        {
            dirUp = false;
        }

        if (transform.position.y <= 0)
        {
            dirUp = true;
        }
    }
}
