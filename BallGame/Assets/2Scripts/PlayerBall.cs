using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower;
    public int itemCount;
    public GameManagerLogic manager;
    bool isJump;
    AudioSource audio;
    Rigidbody rigid;
    
    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();

    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rigid.AddForce(new Vector3(h, 0, v),ForceMode.Impulse);//y축은 점프이기 때문에 0으로 놔둔다
    }
     void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);// 점프하는 함수
        }
    }
    private void OnCollisionEnter(Collision collision)//공이 바닥에 닿았을때 다시 점프를 할 수 있게 만들어주는 함수
    {
        if(collision.gameObject.tag=="Floor")
        {
            isJump = false;
        }
    }
   
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Finish")
        {
            if (itemCount==manager.totalItemCount)//게임 클리어 요건
            {
                if (manager.stage==2)
                {
                    SceneManager.LoadScene("Example1_0");
                }
                else
                {
                    SceneManager.LoadScene("Example1_" + (manager.stage + 1).ToString());
                }
            }
            else//restart
            {
                SceneManager.LoadScene("Example1_" + manager.stage.ToString());
            }
        }
    }
    
    

}
