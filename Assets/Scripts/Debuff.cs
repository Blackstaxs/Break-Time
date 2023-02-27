using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff : MonoBehaviour
{
    public GameObject Camera;

    void Update()
    {
        transform.Rotate(Vector3.up, 45 * Time.deltaTime * 5f);
    }

    void OnTriggerEnter(Collider other)
    {
        Camera.GetComponent<Camera>().UpDown();
        Destroy(gameObject);
    }
}
