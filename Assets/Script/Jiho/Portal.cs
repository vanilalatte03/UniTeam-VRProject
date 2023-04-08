using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string Map2; //이동할 씬 이름

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) //충돌한 개체가 플레이어인 경우
        {
            SceneManager.LoadScene("Map2");
        }
    }
}
