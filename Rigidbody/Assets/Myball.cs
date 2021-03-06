using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Myball : MonoBehaviour
{

    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void FixedUpdate()
    {

        //방향키로 점프및 움직임
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector3.up * 20, ForceMode.Impulse);//캐릭터가 점프할때 보통 이것을 사용
            Debug.Log(rigid.velocity);
        }
        Vector3 vec = new Vector3(Input.GetAxis("Horizontal"),
                                    0,
                                    Input.GetAxis("Vertical"));
        
        rigid.AddForce(vec, ForceMode.Impulse);//
        rigid.AddTorque(Vector3.back);


        //rigid.velocity = new Vector3(2, 4, -1);//현재 이동속도

    }
    void OnTriggerStay(Collider other)//투명한 상자로 공이 이동했을때 공이 위로 붕뜨게 해주는 함수
    {
        if (other.name == "Cube")
        {
            rigid.AddForce(Vector3.up, ForceMode.Impulse);
        }
    }
    public void Jump()
    {
        rigid.AddForce(Vector3.up*20, ForceMode.Impulse);
    }
}
