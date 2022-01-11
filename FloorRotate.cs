using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRotate : MonoBehaviour
{
    [SerializeField]private float rotateSpeed;
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles -= new Vector3(0f, rotateSpeed * Time.deltaTime, 0f);
        }else if(Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += new Vector3(0f, rotateSpeed * Time.deltaTime, 0f);
        }
    }
}
