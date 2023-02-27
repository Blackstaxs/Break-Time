using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
