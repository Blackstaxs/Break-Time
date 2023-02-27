using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class DarkCamera : MonoBehaviour
{
   
    void Start()
    {

    }


    void Update()
    {
        transform.Rotate(Vector3.up, 45 * Time.deltaTime * 5f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().DarknessOn();
            Destroy(gameObject);
        }
    }
}
