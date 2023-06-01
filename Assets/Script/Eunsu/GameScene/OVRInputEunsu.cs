using UnityEngine;

public class OVRInputEunsu : MonoBehaviour
{
    public float movementSpeed = 8f;  // 플레이어 이동 속도

    private CharacterController characterController;  // 캐릭터 컨트롤러 컴포넌트
    private OVRPlayerController ovrPlayerController;  // Oculus 플레이어 컨트롤러 컴포넌트

    private Player player;

    [SerializeField]
    private AudioSource audioSource;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        ovrPlayerController = GetComponent<OVRPlayerController>();
        player = GetComponent<Player>();
    }

    private void Update()
    {
        PlayerMove();
        PlayerShot();
        PlayerReload();
    }

    private void PlayerMove()
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

    private void PlayerShot()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            player.Attack();
        }
    }

    private void PlayerReload()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            player.Reload();
        }
    }
}