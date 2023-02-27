using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    private GameObject Post;
    private GameObject Tv;
    private GameObject Wine;
    private Vector3 NormalCamera;
    private float DebuffTime = 6f;

    PostProcessVolume volume;
    Bloom bloomLayer = null;

    void Start()
    {
        Post = GameObject.Find("Post");
        Post.SetActive(false);
        Tv = GameObject.Find("Tv");
        Tv.SetActive(false);
        Wine = GameObject.Find("Drink");
        Wine.SetActive(false);
        volume = GameObject.Find("Disco").GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out bloomLayer);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =new Vector3(0 , 0, player.transform.position.z) + new Vector3(15, 1, 5);
    }

    public void UpDown()
    {
        transform.rotation = Quaternion.Euler(0, -90, 180);
        Invoke("BackToNormal", DebuffTime);
    }

    public void BackToNormal()
    {
        transform.rotation = Quaternion.Euler(0, -90, 0);
    }

    public void DarknessOn()
    {
        Post.SetActive(true);
        Invoke("DarknessOff", DebuffTime);
    }
    public void DarknessOff()
    {
        Post.SetActive(false);
    }

    public void DrunkOn()
    {
        Wine.SetActive(true);
        Invoke("DrunkOff", DebuffTime);
    }
    public void DrunkOff()
    {
        Wine.SetActive(false);
    }

    public void LightsOn()
    {
        Magenta();
        Invoke("Yellow", 1f);
        Invoke("Cyan", 2f);
        Invoke("Yellow", 3f);
        Invoke("Cyan", 4f);
        Invoke("White", 5f);
    }

    public void TvOn()
    {
        Tv.SetActive(true);
        Invoke("TvOff", DebuffTime);
    }

    public void TvOff()
    {
        Tv.SetActive(false);
    }

    void Magenta()
    {
        bloomLayer.threshold.Override(0.8f);
        bloomLayer.color.Override(Color.magenta);
    }

    void Yellow()
    {
        bloomLayer.color.Override(Color.yellow);
    }

    void Cyan()
    {
        bloomLayer.color.Override(Color.cyan);
    }

    void White()
    {
        bloomLayer.color.Override(Color.white);
        bloomLayer.threshold.Override(1f);
    }
}
