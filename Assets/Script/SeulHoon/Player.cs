using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool fDown;
    public GameObject[] weapons; 
    Weapon equipweapon;
    bool isFireReady;
    float fireDelay;
    
     void Awake()
     {
        foreach (var item in weapons)
        {
            equipweapon = item.GetComponent<Weapon>();
        }
     }

    void Update()
    {
        GetInput();
        Attack();
    }

    //사용자 입력
   void GetInput()
    {
        fDown = Input.GetButtonDown("Fire1");
        Debug.Log("마우스 입력됨.");
    }

    void Attack()
    {
        if(equipweapon == null)
        {
            Debug.Log("리턴");
            return;
        }

        //공격딜레이
        fireDelay += Time.deltaTime;
        isFireReady = equipweapon.rate < fireDelay;

        if(fDown && isFireReady)
        {
            equipweapon.Use();
            Debug.Log("공격");
            fireDelay = 0;
        }
     }
}
