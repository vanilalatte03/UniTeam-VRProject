using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string Map2; //이동할 씬 이름


    // 포탈을 게임 클리어할때 한다고 해서 보류
    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) //충돌한 개체가 플레이어인 경우
        {
            SceneManager.LoadScene("Map2");
        }
    }*/

    // 스카이박스 변경 할때 이거 사용
/*    [SerializeField]
    private Skybox[] skyboxes;*/

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) //충돌한 개체가 플레이어인 경우
        {
            Debug.Log("게임 클리어 로직!");
        }
    }
}
