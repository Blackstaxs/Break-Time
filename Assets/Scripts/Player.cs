using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public Rigidbody rb;
    public BoxCollider bc;
    public float speedForce = 10f;
    public float jumpForce = 10f;
    public float peso = 0;
    public float MaXjUMP = 4.5f;
    public float extraHeight = 3f;
    public bool develop;
    public float downPower = 1f;
    public bool JumpPressed = false;
    public bool isHolding = true;
    private bool canDash =true;
    private bool isDashing = false;
    private float dashingPower = 24f;
    private float dashingTime = 0.15f;
    private float dashingCooldown = 1f;

    //swipe
    private Vector2 StartPosition;
    private Vector2 CurrentPosition;
    private Vector2 EndPosition;
    private bool stopTouch = false;
    public GameObject PLayer;
    public float swipeRange;
    public float tapRange;
    //
    [SerializeField] private TrailRenderer tr;

    public AudioSource JumpAudio;
    public AudioSource DashAudio;
    public Animator anim;


    void Start()
    {
        PlayerPrefs.SetString("SavedScene", SceneManager.GetActiveScene().name);
        if (develop == true)
        {
            extraHeight = 4.5f;
            downPower = 2.5f;
        }
    }

    void Update()
    {
        Swiping();
        //test fix
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (3.5f - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && isHolding)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (2f - 1) * Time.deltaTime;
        }

        //add velocity if player on ground

        if (GroundCheck() && (JumpPressed == !true))
        {
            rb.velocity = Vector3.forward * speedForce;
        }

    }

    //cast a ray down to check for ground
    bool GroundCheck()
    {
        float extraHeight = 0.01f;
        var ray = new Ray(bc.bounds.center, Vector3.down);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, bc.bounds.extents.y + extraHeight))
        {
            //check the mass for the jump colors
            if(hit.collider.tag != "BLOCK")
            {
                peso = hit.collider.GetComponent<Rigidbody>().mass;
                return true;
            }
            else
            {
                return false;
            }
        }
        
        else
        {
            return false;
        }   
    }

    //test jump function
    public void PlayerJump()
    {
        if (GroundCheck())
        {
            JumpPressed = true;
            anim.Play("Jump");
            JumpAudio.Play();
            rb.velocity = new Vector3(0, jumpForce, speedForce);
            Invoke("ToFalse", 0.5f);
        }
    }


    public void RedholdUi()
    {
        isHolding = false;
        RedJump();
    }

    public void RedNotholdUi()
    {
        isHolding = true;
        RedJump();
    }

    public void RedJump()
    {
        if (GroundCheck() && (peso == 1))
        {
            PlayerJump();
        }
    }

    public void GreenholdUi()
    {
        isHolding = false;
        GreenJump();
    }

    public void GreenNotholdUi()
    {
        isHolding = true;
        GreenJump();
    }

    public void GreenJump()
    {
        if (GroundCheck() && (peso == 2))
        {
            PlayerJump();
        }
    }

    public void BlueholdUi()
    {
        isHolding = false;
        BlueJump();
    }

    public void BlueNotholdUi()
    {
        isHolding = true;
        BlueJump();
    }

    public void BlueJump()
    {
        if (GroundCheck() && (peso == 3))
        {
            PlayerJump();
        }
    }

    //collision with obstacles
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BLOCK")
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }

    void ToFalse()
    {
        JumpPressed = false;
    }

    public IEnumerator Dash()
    {
        canDash = false;
        anim.Play("Dash");
        DashAudio.Play();
        isDashing = true;
        rb.useGravity = false;
        rb.velocity = new Vector3(0, 0, transform.localScale.z * dashingPower);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        rb.useGravity = true;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        tr.emitting = false;
        canDash = true;
    }

    public void Swiping()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            StartPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            CurrentPosition = Input.GetTouch(0).position;
            Vector2 Distance = CurrentPosition - StartPosition;

            if (!stopTouch)
            {
                if (Distance.x < -swipeRange && canDash)
                {
                    StartCoroutine(Dash());
                    stopTouch = true;
                }
                else if (Distance.x > swipeRange && canDash)
                {
                    StartCoroutine(Dash());
                    stopTouch = true;
                }
                else if (Distance.y > swipeRange && canDash)
                {
                    StartCoroutine(Dash());
                    stopTouch = true;
                }
                else if (Distance.y < -swipeRange && canDash)
                {
                    StartCoroutine(Dash());
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
