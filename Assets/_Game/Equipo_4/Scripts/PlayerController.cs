using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Header("Movement")]
    private float speed = 0f;
    public float rotateSpeed;
    private Vector3 mov;
    private Rigidbody rb;
    private Animator anim;


    [Header("UI")]
    private int score;
    private int itemAmmount = 0;
    public Text itemText;
    private UIController uiManage;


    public int ItemAmmount
    {
        get { return itemAmmount; }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        itemText.text = itemAmmount.ToString() + "/3";
        uiManage = FindObjectOfType<UIController>();
        uiManage.ShowLevelStartMsg();
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Move(x, 0f, z);

    }

    public void Move(float x, float y, float z)
    {
        mov.Set(x, y, z);
        mov = mov.normalized * speed;
        rb.MovePosition(rb.position + mov * Time.deltaTime);
        Rotate(mov);
        AnimateCharacter(mov);
    }

    public void Rotate(Vector3 movement)
    {
        if (movement != Vector3.zero)
        {
            Quaternion rotate = Quaternion.LookRotation(movement);
            rotate = Quaternion.RotateTowards(transform.rotation, rotate, rotateSpeed * Time.deltaTime);
            rb.MoveRotation(rotate);
        }

    }

    public void AnimateCharacter(Vector3 movement)
    {
        if (movement.z != 0)
        {
            anim.SetFloat("Speed", movement.z);
        }
        else if (movement.x != 0)
        {
            anim.SetFloat("Speed", movement.x);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
    }

    public void ChangeScore(int points)
    {
        score += points;
    }

    public void TakeItem(int ammount)
    {
        this.itemAmmount += ammount;
        itemText.text = itemAmmount.ToString() + "/3";
    }
}
