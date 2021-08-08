using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBall : MonoBehaviour
{
    MeshRenderer mesh;
    Material mat;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
    }

    void OnCollisionEnter(Collision collision)//물리적 충돌이 시작할 때 호출되는 함수 
    {
        if (collision.gameObject.name=="Myball")
        {
            mat.color = new Color(0, 0, 0); //검은색
        }
    }
    void OnCollisionStay(Collision collision) //물리적 충돌 중 호출되는 함수
    {
        
    }
    void OnCollisionExit(Collision collision) //물리적 충돌이 끝났을 때 호출되는 함수
    {
        if (collision.gameObject.name == "Myball")
        {
            mat.color = new Color(1, 1, 1); //검은색
        }
    }
}
