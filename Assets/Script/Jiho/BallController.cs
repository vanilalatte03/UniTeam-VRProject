using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject ballPrefab; // ������ ���� ������
    public Transform dropZone; // ���� ������ ������ ��ġ
    public float ballLifetime = 2f; // ������ ���� ������� �ð�

    private bool playerOnObject = false; // �÷��̾ ������Ʈ ���� �ö󰬴��� ����
    private bool ballCreated = false; // ���� �̹� �����Ǿ����� ����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !ballCreated)
        {
            playerOnObject = true;
            CreateBall();
            Invoke("DropBall", ballLifetime);
            ballCreated = true; // ���� �����Ǿ����� ǥ��
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
        // �� ���� ����
        Vector3 ballPosition = dropZone.position + new Vector3(0f, 0.5f, 0f);
        GameObject ball = Instantiate(ballPrefab, ballPosition, Quaternion.identity);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.isKinematic = false; // Ű�׸�ƽ�� �����Ͽ� ���� �����̵��� ��
    }

    private void DropBall()
    {
        if (playerOnObject)
        {
            // ������Ʈ ���� �÷��̾ �ִ� ��쿡�� ���� ����߸�
            Transform ball = transform.GetChild(0); // �ڽ� �� ù ��° ���� ������
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            ballRigidbody.isKinematic = false; // ���� ��� Ȱ��ȭ�Ͽ� ���������� ��

            ballRigidbody.AddForce(Vector3.forward * 10f, ForceMode.Impulse); // ������ �������� ���� ����
        }
    }
}