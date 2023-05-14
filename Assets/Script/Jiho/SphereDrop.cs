using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDrop : MonoBehaviour
{
    public GameObject spherePrefab;

    private void OnCollisionEnter(Collision collision)
    {
        // 플레이어 태그를 가진 오브젝트와 'TrapWall' 태그를 가진 오브젝트가 충돌했을 때
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.CompareTag("TrapWall"))
        {
            DropSphere(); 
        }
    }

    private void DropSphere()
    {
        if (spherePrefab != null)
        {
 
            GameObject sphere = Instantiate(spherePrefab, transform.position, Quaternion.identity);

 
            Rigidbody sphereRigidbody = sphere.GetComponent<Rigidbody>();
            if (sphereRigidbody != null)
            {
                sphereRigidbody.AddForce(Vector3.down * 10f, ForceMode.Impulse); 
            }
        }
    }
}