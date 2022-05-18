using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Movement : MonoBehaviour
{
    public AnimationCurve jumpCurve;
    public AnimationCurve slideCurve;
    public Animator anim;

    private bool Jumping = false;
    private bool Sliding = false;
    public float SlideDuration = 1f;
    public float SlideUpDownDuration = 1f;
    public float SlideScale = 90f;
    public float JumpScale = 5f;
    public float JumpDuration = 1f;

    public float reloadTime = 5F;
    public float bulletForce;
    public GameObject Bullet;
    public Transform bulletSpawnPosition;
    public float bulletTimeToDestroy = 2f;
    public bool canFire = true;
    public int munition = 10;
   

    float yOriginal;
    float yOffset;
    float xOriginal;
    float zOriginal;
    float zRotation;
    float yFinal;
    Vector3 posIni;
    public float verticalPos;

    internal Transform tr;
    public Transform Pivot;

    //Life System
    public int lives;
    public GameObject[] hearts;
    

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        tr = transform;
        yOriginal = tr.position.y;
        xOriginal = tr.position.x;
        zOriginal = tr.position.z;
        zRotation = tr.rotation.z;
        lives = 3;

    }

    // Update is called once per frame
    void Update()
    {
        yFinal = yOriginal + yOffset;
        if (Input.GetMouseButtonDown(0))
        {
            posIni = Input.mousePosition;
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            if ((posIni - Input.mousePosition).magnitude > 150)
            {
                verticalPos = (posIni - Input.mousePosition).y;
                if (verticalPos<0)
                {
                    Saltar();
                }
                else
                {
                    Deslizar();
                }
            }
        }
        
        tr.position = new Vector3(xOriginal, yFinal, zOriginal);

        Pivot.rotation = Quaternion.Euler(0, 0, zRotation);
        if (Input.GetButtonDown("Fire2"))
        {
            Bullets();
            
        }
    }

    public void Saltar()
    {
        if (!Jumping && !Sliding)
        {
            StartCoroutine(toJump());
        }
    }

    public void Deslizar()
    {
        if (!Jumping && !Sliding)
        {
            StartCoroutine(toSlide());
        }
    }

    public IEnumerator toJump()
    {
        anim.SetBool("isJumping", true);
        Jumping = true;
        float x = 0;
        while (x < JumpDuration)
        {
            x += Time.deltaTime;
            yOffset = jumpCurve.Evaluate(x / JumpDuration) * JumpScale;
            yield return null;
        }
        Jumping = false;
        anim.SetBool("isJumping", false);
    }

    public IEnumerator toSlide()
    {
        Sliding = true;
        float x = 0;
        while (x < SlideUpDownDuration)
        {
            x += Time.deltaTime;
            zRotation = slideCurve.Evaluate(x / SlideDuration) * SlideScale;
            
            yield return null;
        }
        yield return new WaitForSeconds(SlideDuration);
        while (x > 0)
        {
            x -= Time.deltaTime;
            zRotation = slideCurve.Evaluate(x / SlideDuration) * SlideScale;
            
            yield return null;
        }
        Sliding = false;
    }

    private void Bullets()
    {
        if (munition >= 1)
        {
            Invoke("EnableFire", reloadTime);
            GameObject bulletClone = Instantiate(
                Bullet, bulletSpawnPosition.position, transform.rotation);

            Rigidbody bulletRB = bulletClone.GetComponent<Rigidbody>();

            if (bulletRB != null)
            {
                bulletRB.AddForce(bulletClone.transform.right * bulletForce, ForceMode.Impulse);

            }

            Destroy(bulletClone, bulletTimeToDestroy);
            munition--;
            print(munition);
            //canFire = false;
        }
        else
        {
            print("no mun");
            canFire = false;
        }



    }

    public void EnableFire()
    {
        canFire = true;
       
    }

    public void incrementMunition(int qtty)
    {
        munition += qtty;
    }

    public void GetDamage(int qtty)
    {
        lives = lives - qtty;
        if (lives >= 0)
        {
            hearts[lives].gameObject.SetActive(false);
        }
        
    }
   
}
