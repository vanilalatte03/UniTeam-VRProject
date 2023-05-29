using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{ 
    public enum Type { Range }; //����Ÿ��
    public Type type;
    public float rate; //����
    public Transform bulletPos; //�Ѿ��� �߻�Ǵ� ��ġ
    public GameObject bullet;
    public GunSound gunSound;
    public int maxAmmo; //�ִ�źâ
    public int curAmmo; //����źâ

    public void Use()
    {   
        if (type == Type.Range && curAmmo > 0)
        {
            curAmmo--;
            GameManager.Instance.ShootingUIUpdate(curAmmo, maxAmmo);            // UI źâ �����̵� (���� �۾�)
            StartCoroutine("Shot");
        }
    }

    IEnumerator Shot()
    {     
        //�Ѿ� �߻�
        GameObject intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
        gunSound.Shot.Play();
        bulletRigid.velocity = bulletPos.forward * 50; 

        yield return null;
    }
}
