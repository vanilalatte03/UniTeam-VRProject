using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{ 
    public enum Type { Range }; //무기타입
    public Type type;
    public float rate; //공속
    public Transform bulletPos; //총알이 발사되는 위치
    public GameObject bullet;
    public GunSound gunSound;
    public int maxAmmo; //최대탄창
    public int curAmmo; //현재탄창

    public void Use()
    {   
        if (type == Type.Range && curAmmo > 0)
        {
            curAmmo--;
            GameManager.Instance.ShootingUIUpdate(curAmmo, maxAmmo);            // UI 탄창 업데이드 (은수 작업)
            StartCoroutine("Shot");
        }
    }

    IEnumerator Shot()
    {     
        //총알 발사
        GameObject intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
        gunSound.Shot.Play();
        bulletRigid.velocity = bulletPos.forward * 50; 

        yield return null;
    }
}
