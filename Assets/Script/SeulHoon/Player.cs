using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool fDown;
    bool rDown;
    bool isFireReady;
    bool isReload;

    Weapon equipweapon;
    public GameObject[] weapons;
    public int ammo; //플레이어의 탄알 총량
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
        Reload();
    }

    //사용자 입력
    void GetInput()
    {       
        fDown = Input.GetButtonDown("Fire1");
        rDown = Input.GetButtonDown("Reload");
    }

    void Attack()
    {
        if (GameManager.Instance.IsGamePause || !GameManager.Instance.IsGameActive)
        {
            return;
        }

        if (equipweapon == null)
        {
            Debug.Log("리턴");
            return;
        }
        
        //공격딜레이
        fireDelay += Time.deltaTime;
        isFireReady = equipweapon.rate < fireDelay;
       
        if (fDown && isFireReady)
        {            
            equipweapon.Use();
            Debug.Log("공격");
            fireDelay = 0;
        }
     }

    private void Reload()
    {
        if (equipweapon == null)
        {
            return;
        }
        if (ammo == 0)
        {
            return;
        }
        if (GameManager.Instance.IsGamePause || !GameManager.Instance.IsGameActive)
        {
            return;
        }
        if (rDown && isFireReady)
        {
            isReload = true;
            Debug.Log("재장전");
            Invoke("ReloadOut", 0.5f);//뒤에 숫자 재장전 시간
        }
    }
    void ReloadOut()
    {
        int reAmmo = ammo < equipweapon.maxAmmo ? ammo : equipweapon.maxAmmo;
        equipweapon.curAmmo = equipweapon.maxAmmo;
        ammo -= reAmmo;
        isReload = false;
    }
}
