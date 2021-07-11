using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCan : MonoBehaviour
{
    public float rotateSpeed;
    
    void Update()
    {
        transform.Rotate(Vector3.up*rotateSpeed*Time.deltaTime, Space.World);   
        //vector3.up=>vector3(0,1,0) space안에는 self,world가 있는데 좌표의 차이라서 직접 눈으로 보면 더 쉽게 알 수 있다.
    }
     
}
