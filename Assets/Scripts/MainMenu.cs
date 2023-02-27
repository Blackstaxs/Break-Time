using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1()
    {
        SceneManager.LoadScene("Snow", LoadSceneMode.Single);
    }

    public void Level2()
    {
        SceneManager.LoadScene("DashLevel", LoadSceneMode.Single);
    }

    public void Level3()
    {
        SceneManager.LoadScene("DebuffLevel", LoadSceneMode.Single);
    }

    public void Level4()
    {
        SceneManager.LoadScene("Trial", LoadSceneMode.Single);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }

    public void Main()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void Boss()
    {
        SceneManager.LoadScene("Boss", LoadSceneMode.Single);
    }
}
