using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject ballPrefab; // 생성할 공의 프리팹
    public Transform dropZone; // 공이 떨어질 구역의 위치
    public float ballLifetime = 2f; // 생성한 공이 사라지는 시간

    private bool playerOnObject = false; // 플레이어가 오브젝트 위에 올라갔는지 여부
    private bool ballCreated = false; // 공이 이미 생성되었는지 여부

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !ballCreated)
        {
            playerOnObject = true;
            CreateBall();
            Invoke("DropBall", ballLifetime);
            ballCreated = true; // 공이 생성되었음을 표시
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnObject = false;
        }
    }

    private void CreateBall()
    {
        // 공 생성 로직
        Vector3 ballPosition = dropZone.position + new Vector3(0f, 0.5f, 0f);
        GameObject ball = Instantiate(ballPrefab, ballPosition, Quaternion.identity);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.isKinematic = false; // 키네마틱을 해제하여 공이 움직이도록 함
    }

    private void DropBall()
    {
        if (playerOnObject)
        {
            // 오브젝트 위에 플레이어가 있는 경우에만 공을 떨어뜨림
            Transform ball = transform.GetChild(0); // 자식 중 첫 번째 공을 가져옴
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            ballRigidbody.isKinematic = false; // 공의 운동을 활성화하여 떨어지도록 함

            ballRigidbody.AddForce(Vector3.forward * 10f, ForceMode.Impulse); // 앞으로 구르도록 힘을 가함
        }
    }
}