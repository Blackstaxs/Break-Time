using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 StartPosition;
    private Vector2 CurrentPosition;
    private Vector2 EndPosition;
    private bool stopTouch = false;
    public GameObject PLayer;
    public float swipeRange;
    public float tapRange;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Swiping()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            StartPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            CurrentPosition = Input.GetTouch(0).position;
            Vector2 Distance = CurrentPosition - StartPosition;

            if (!stopTouch)
            {
                if (Distance.x < -swipeRange)
                {
                    PLayer.GetComponent<Player>().Dash();
                    stopTouch = true;
                }
                else if (Distance.x > swipeRange)
                {
                    PLayer.GetComponent<Player>().Dash();
                    stopTouch = true;
                }
                else if (Distance.y > swipeRange)
                {
                    PLayer.GetComponent<Player>().Dash();
                    stopTouch = true;
                }
                else if (Distance.y < -swipeRange)
                {
                    PLayer.GetComponent<Player>().Dash();
                    stopTouch = true;
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            EndPosition = Input.GetTouch(0).position;
        }
    }
}
