using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool fDown;
    //bool isFireReady;
    //float fireDelay;
    Weapon weapon;
    

     void Awake()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        fDown = Input.GetMouseButton(0);
        if (fDown)
        {          
            weapon.Use();
            Debug.Log("����");
            //fireDelay = 0;
        }
    }

    /*void GetInput()
    {
        fDown = Input.GetButton("Fire1");
        Debug.Log("�ƾ�");
    }*/

    /*void Attack()
    {
        //fireDelay += Time.deltaTime;
        //isFireReady = weapon.rate < fireDelay;

        if(fDown)
        {
            weapon.Use();
            Debug.Log("����");
            //fireDelay = 0;
        }
     }*/
}
