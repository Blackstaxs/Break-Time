using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollow : MonoBehaviour
{
    public Transform player;
    public GameObject BallATK;
    public GameObject PillarATK;
    public float BulletSpped = 800f;
    public float CoolDownBoss = 1f;
    public float TimeBe = 3f;
    private float BossHP = 30;
    public int BossPhase = 1;
    public bool BossActive = true;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BossTest());
    }

    // Update is called once per frame
    void Update()
    {
        BossDistance();
        if (BossHP == 20)
        {
            TimeBe = 2f;
        }
        if (BossHP == 15)
        {
            BulletSpped = 1000f;
        }


        if (BossHP < 0)
        {
            BossActive = false;
        }
    }

    IEnumerator BossTest()
    {
        yield return new WaitForSeconds(CoolDownBoss);
        BossAttack();
    }

    private IEnumerator FastlowAttack()
    {
        anim.Play("1ball");
        yield return new WaitForSeconds(1);
        var instance = Instantiate(BallATK, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);
        instance.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpped);

        CoolDownBoss = TimeBe;
        BossLoop();
        yield return new WaitForSeconds(CoolDownBoss);
        BossAttack();
    }

    private IEnumerator DobleAttack()
    {
        anim.Play("Atk_Claw_DBL");
        yield return new WaitForSeconds(1);
        var instance = Instantiate(BallATK, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);
        instance.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpped);

        var instance2 = Instantiate(BallATK, new Vector3(transform.position.x, 6, transform.position.z), Quaternion.identity);
        instance2.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpped);

        CoolDownBoss = TimeBe;
        BossLoop();
        yield return new WaitForSeconds(CoolDownBoss);
        BossAttack();
    }

    private IEnumerator UltraFastAttack()
    {
        anim.Play("Atk_Claw_R");
        yield return new WaitForSeconds(1);
        var instance = Instantiate(BallATK, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);
        instance.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpped * 2);

        CoolDownBoss = TimeBe;
        BossLoop();
        yield return new WaitForSeconds(CoolDownBoss);
        BossAttack();
    }

    private IEnumerator PillarAttack()
    {
        anim.Play("Breath_Fs");
        yield return new WaitForSeconds(1);
        var instance = Instantiate(PillarATK, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);
        instance.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpped * 2);

        CoolDownBoss = TimeBe;
        BossLoop();
        yield return new WaitForSeconds(CoolDownBoss);
        BossAttack();
    }

    private IEnumerator RapidPillar()
    {
        anim.Play("Breath_Fw");
        yield return new WaitForSeconds(1);

        var pillar1 = Instantiate(PillarATK, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);
        pillar1.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpped);
        var pillar2 = Instantiate(PillarATK, new Vector3(transform.position.x, 1, transform.position.z + 3), Quaternion.identity);
        pillar2.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpped);
        var pillar3 = Instantiate(PillarATK, new Vector3(transform.position.x, 1, transform.position.z + 6), Quaternion.identity);
        pillar3.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpped);
        

        CoolDownBoss = TimeBe;
        BossLoop();
        yield return new WaitForSeconds(CoolDownBoss);
        BossAttack();
    }


    private IEnumerator RapidFire()
    {
        anim.Play("manyballs");
        yield return new WaitForSeconds(1);
        var fireball1 = Instantiate(BallATK, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);
        fireball1.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpped);
        var fireball2 = Instantiate(BallATK, new Vector3(transform.position.x, 1, transform.position.z + 2), Quaternion.identity);
        fireball2.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpped);
        var fireball3 = Instantiate(BallATK, new Vector3(transform.position.x, 1, transform.position.z + 4), Quaternion.identity);
        fireball3.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpped);
        var fireball4 = Instantiate(BallATK, new Vector3(transform.position.x, 1, transform.position.z + 6), Quaternion.identity);
        fireball4.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpped);
        var fireball5 = Instantiate(BallATK, new Vector3(transform.position.x, 1, transform.position.z + 8), Quaternion.identity);
        fireball5.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpped);
        var fireball6 = Instantiate(BallATK, new Vector3(transform.position.x, 1, transform.position.z + 10), Quaternion.identity);
        fireball6.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpped);
        var fireball7 = Instantiate(BallATK, new Vector3(transform.position.x, 1, transform.position.z + 12), Quaternion.identity);
        fireball7.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpped);
        var fireball8 = Instantiate(BallATK, new Vector3(transform.position.x, 1, transform.position.z - 2), Quaternion.identity);
        fireball8.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpped);

        CoolDownBoss = TimeBe;
        BossLoop();
        yield return new WaitForSeconds(CoolDownBoss);
        BossAttack();
    }

    private void BossLoop()
    {
        BossPhase = Random.Range(1, 7);
        //Debug.Log(BossPhase);
    }

    private void BossAttack()
    {
        if (BossActive == true)
        {
            if (BossPhase == 1)
            {
                StartCoroutine(FastlowAttack());
            }
            else if (BossPhase == 2)
            {
                StartCoroutine(PillarAttack());
            }
            else if (BossPhase == 3)
            {
                StartCoroutine(RapidPillar());
            }
            else if (BossPhase == 4)
            {
                StartCoroutine(RapidFire());
            }
            else if (BossPhase == 5)
            {
                StartCoroutine(UltraFastAttack());
            }

            else if (BossPhase == 6)
            {
                StartCoroutine(DobleAttack());
            }

            BossHP -= 1;
            //Debug.Log(BossHP);
            //Debug.Log(TimeBe);
        }
        
    }

    private void BossDistance()
    {
        if(BossActive == true)
        {
            transform.position = new Vector3(0, 0, player.transform.position.z) + new Vector3(0, 0, 22);
        }
    }
}
