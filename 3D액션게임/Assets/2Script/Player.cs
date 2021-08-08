using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject[] weapons;
    public bool[] hasWeapons;
    public GameObject[] grenades;
    public int hasGrenades;

    int itemCount;
    public int ammo;
    public int coin;
    public int health;

    public int Maxammo;
    public int Maxcoin;
    public int Maxhealth;
    public int MaxhasGrenades;


    float hAxis;
    float vAxis;

    bool wDown;
    bool jDown;
    bool iDown;
    bool sDown1;
    bool sDown2;
    bool sDown3;


    bool isJump;
    bool isDodge;
    bool isSwap;

    AudioSource audio;
    Vector3 moveVec;
    Vector3 dodgeVec;

    Rigidbody rigid;
    Animator anim;

    GameObject nearObject;
    GameObject equipWeapon;
    int equipWeaponIndex = -1; //망치의 index가 0이기 때문에 0으로 설정하면 망치를 먹어도 Swap 함수 첫번째 코드에서 return이 되어버려 망치를 사용할 수 없게 된다.

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }
    void Start()
    {

    }

    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
        Dodge();
        Swap();
        Interation();
    }

    

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
        iDown = Input.GetButtonDown("Interation");
        sDown1 = Input.GetButtonDown("Swap1");
        sDown2 = Input.GetButtonDown("Swap2");
        sDown3 = Input.GetButtonDown("Swap3");
    }
    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;//어떤 방향이든 같은 속도가 나올 수 있도록
        /*if (wDown)
            transform.position += moveVec * speed * 0.3f * Time.deltaTime;
        else
            transform.position += moveVec * speed * Time.deltaTime;*/
        if (isDodge)
            moveVec = dodgeVec;
        //if (isSwap)
        //    moveVec = Vector3.zero;
        transform.position += moveVec * speed * (wDown ? 0.1f : 1f) * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);

    }
    void Turn()
    {
        transform.LookAt(transform.position + moveVec);// 플레이어가 회전하도록 만들어주는 함수
    }
    void Jump()
    {
        if (jDown && moveVec == Vector3.zero && !isJump && !isDodge && !isSwap)
        {
            rigid.AddForce(Vector3.up * 30, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
        }
    }

    void Dodge()
    {
        if (jDown && moveVec != Vector3.zero && !isJump && !isDodge && !isSwap) // 다른 행동이 실행되지 않았을때
        {
            dodgeVec = moveVec;
            speed *= 2;
            anim.SetTrigger("doDodge");
            isDodge = true;

            Invoke("DodgeOut", 0.4f);

        }
    }
    void DodgeOut()
    {
        speed *= 0.5f;
        isDodge = false;
    }
    void Swap()
    {
        if (sDown1 && (!hasWeapons[0] || equipWeaponIndex == 0))
            return;
        if (sDown2 && (!hasWeapons[1] || equipWeaponIndex == 1))
            return;
        if (sDown3 && (!hasWeapons[2] || equipWeaponIndex == 2))
            return;

        int weaponIndex = -1;
        if (sDown1) weaponIndex = 0;
        if (sDown2) weaponIndex = 1;
        if (sDown3) weaponIndex = 2;

        if ((sDown1 || sDown2 || sDown3) && !isJump &&!isDodge)
        {
            if (equipWeapon != null)
                equipWeapon.SetActive(false);

            equipWeaponIndex = weaponIndex;
            equipWeapon = weapons[weaponIndex];
            equipWeapon.SetActive(true);
            
            anim.SetTrigger("doSwap");
            
            isSwap = true;

            Invoke("SwapOut", 0.4f);
            
        }
    }
    void SwapOut()
    {
        isSwap = false;
    }

    private void Interation()
    {
        if(iDown && nearObject !=null && !isJump && !isDodge)//e키를 눌렀을때 + 주위에 무기가 있을때 + 점프나 도약을 하지 않고 있을때 실행이 된다.
        {
            if(nearObject.tag=="Weapon") // 가까운 물체의 tag가 무기일때
            {
                Item item = nearObject.GetComponent<Item>(); // 각각 무기에 넣어둔 item이라는 스크립트를 가져오기 위한 코드 
                int weaponIndex = item.value; // item 스크립트 안의 value값
                hasWeapons[weaponIndex] = true; // 유니티에서 무기마다의 value값을 설정하고 그 값이 들어있는 bool배열안에 있는 값들을 true or false로 설정하게 만들어준다.

                Destroy(nearObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")// 캐릭터가 바닥에 닿았을때 사용되는 함수 
        {
            anim.SetBool("isJump", false);
            isJump = false;
        }
    }
   
   
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item")
        {
            Item item = other.GetComponent<Item>();
            switch (item.type)
            {
                case Item.Type.Ammo:
                    ammo += item.value;
                    if (ammo > Maxammo)
                        ammo = Maxammo;
                    break;
                case Item.Type.Coin:
                    coin += item.value;
                    if (coin > Maxcoin)
                        coin = Maxcoin;
                    break;
                case Item.Type.Grenade:
                    grenades[hasGrenades].SetActive(true);
                    hasGrenades += item.value;
                    if (hasGrenades > MaxhasGrenades)
                        hasGrenades = MaxhasGrenades;
                    break;
                case Item.Type.Heart:
                    health += item.value;
                    if (health > Maxhealth)
                        health = Maxhealth;
                    break;
            }
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Weapon")
        {
            nearObject = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Weapon")
        {
            nearObject = null;
        }
    }
}
