using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCameraz : MonoBehaviour
{
    Camera m_MainCamera;

    // Update is called once per frame
    private void Start()
    {
        //m_MainCamera = Camera.main;
    }
    void Update()
    {
        transform.Rotate(Vector3.up, 45 * Time.deltaTime * 5f);
    }

    void OnTriggerEnter(Collider other)
    {
        //m_MainCamera.GetComponent<Camera>().UpDown();
        if (other.tag == "Player")
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().UpDown();
            Destroy(gameObject);
        }
    }
}
