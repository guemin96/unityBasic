using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealLifeCycle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 vec = new Vector3(2, 0, 0); //  벡터 값->숫자에 방향이 더해진 형식

        //transform.Translate(vec);//translate 이동시켜주다.

    }

    void Update()
    {
        Vector3 vec = new Vector3(
            Input.GetAxisRaw("Horizontal"), 
            Input.GetAxisRaw("Vertical"),
            0);
        transform.Translate(vec);
    }
}
