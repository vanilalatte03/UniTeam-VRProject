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
    public GunSound gunSound;
    public int ammo; //플레이어의 탄알 총량
    float fireDelay;

    private PlayerHealth playerHealth;

    [SerializeField]
    private ParticleSystem shotEffectParticle;

    [SerializeField]
    private AudioSource heatSound;

    [SerializeField]
    private float invincibilityTime = 1.0f;

    private bool isInviciility;

     void Awake()
     {
        playerHealth = GetComponent<PlayerHealth>();
        foreach (var item in weapons)
        {
            equipweapon = item.GetComponent<Weapon>();
        }       
    }

    private void Start()
    {
        GameManager.Instance.ShootingUIUpdate(equipweapon.curAmmo, equipweapon.maxAmmo);            // 게임 초기시 UI 탄창 업데이드 (은수 작업)
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
            shotEffectParticle.Play();
        }
    }

    private void Reload()
    {
        if (equipweapon == null)
        {
            return;
        }
        if (ammo == 0 || equipweapon.curAmmo == equipweapon.maxAmmo)
        {
            return;
        }
        if (GameManager.Instance.IsGamePause || !GameManager.Instance.IsGameActive)
        {
            return;
        }
        if (rDown && isFireReady)
        {
            GameManager.Instance.ReloadUIUpdate();
            isReload = true;
            Debug.Log("재장전");
            gunSound.Reload.Play();
            Invoke("ReloadOut", 0.5f);//뒤에 숫자 재장전 시간
        }
    }
    void ReloadOut()
    {
        int reAmmo = ammo < equipweapon.maxAmmo ? ammo : equipweapon.maxAmmo;
        equipweapon.curAmmo = equipweapon.maxAmmo;
        ammo -= reAmmo;
        isReload = false;

        GameManager.Instance.ShootingUIUpdate(equipweapon.curAmmo, equipweapon.maxAmmo);            // UI 탄창 업데이드 (은수 작업)
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster" && isInviciility == false)
        {
            isInviciility = true;
            playerHealth.TakeDamage(10);            // 몬스터의 공격력은 임시로 10 설정
            heatSound.Play();
            Invoke("InviciilityControl", invincibilityTime);
        }
    }

    private void InviciilityControl()
    {
        isInviciility = false;
    }
}
