using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool fDown;
    public GameObject weapons;
    //bool isFireReady;
    //float fireDelay;
    Weapon weapon;
    

     void Awake()
    {
        weapon = weapons.GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Attack();
    }

   void GetInput()
    {
        fDown = Input.GetButton("Fire1");
        Debug.Log("아아");
    }

    void Attack()
    {
        if(weapon == null)
        {
            Debug.Log("리턴");
            return;
        }
        //fireDelay += Time.deltaTime;
        //isFireReady = weapon.rate < fireDelay;

        if(fDown)
        {
            weapon.Use();
            Debug.Log("실행");
            //fireDelay = 0;
        }
     }
}
