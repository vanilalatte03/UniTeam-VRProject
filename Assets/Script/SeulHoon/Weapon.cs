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

    public void Use()
    {
        if (type == Type.Range)
        {
            StartCoroutine("Shot");
        }
    }

    IEnumerator Shot()
    {
        //총알 발사
        GameObject intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = bulletPos.forward * 50; 

        yield return null;
    }
}
