/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRInputEunsu : MonoBehaviour
{
    private CharacterController characterController;
    
    [SerializeField]
    private float moveSpeed = 3f;

    [SerializeField]
    private float rotationSpeed = 90f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector2 thumbstickInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 mov = new Vector3(thumbstickInput.x * Time.deltaTime * moveSpeed, 0f, thumbstickInput.y * Time.deltaTime * moveSpeed);
        characterController.Move(mov);

        float rotationAmount = thumbstickInput.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
*/

using UnityEngine;

public class OVRInputEunsu : MonoBehaviour
{
    public float movementSpeed = 3f;  // 플레이어 이동 속도

    private CharacterController characterController;  // 캐릭터 컨트롤러 컴포넌트
    private OVRPlayerController ovrPlayerController;  // Oculus 플레이어 컨트롤러 컴포넌트

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        ovrPlayerController = GetComponent<OVRPlayerController>();
    }

    private void Update()
    {
        // Oculus Touch 컨트롤러의 왼쪽 스틱을 이용한 이동 입력
        float horizontalInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
        float verticalInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;

        // 이동 방향 계산
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // 이동 속도와 시간에 기반한 이동 벡터 계산
        Vector3 movementVector = movementDirection * movementSpeed * Time.deltaTime;

        // 플레이어 이동
        characterController.Move(transform.TransformDirection(movementVector));

        // Oculus 플레이어 컨트롤러의 회전 입력
        float rotationInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;

        // 플레이어 회전
        transform.Rotate(Vector3.up * rotationInput);
    }
}