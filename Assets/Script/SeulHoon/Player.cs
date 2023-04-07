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

    //����� �Է�
   void GetInput()
    {
        fDown = Input.GetButtonDown("Fire1");
        Debug.Log("���콺 �Էµ�.");
    }

    void Attack()
    {
        if(equipweapon == null)
        {
            Debug.Log("����");
            return;
        }

        //���ݵ�����
        fireDelay += Time.deltaTime;
        isFireReady = equipweapon.rate < fireDelay;

        if(fDown && isFireReady)
        {
            equipweapon.Use();
            Debug.Log("����");
            fireDelay = 0;
        }
     }
}
