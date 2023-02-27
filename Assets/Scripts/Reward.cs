using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reward : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Boss;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, transform.position.y, Boss.transform.position.z) + new Vector3(0, 0, 20);
        transform.Rotate(Vector3.up, 45 * Time.deltaTime * 5f);
    }

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("CLEAR", LoadSceneMode.Single);
        Destroy(gameObject);
    }
}
