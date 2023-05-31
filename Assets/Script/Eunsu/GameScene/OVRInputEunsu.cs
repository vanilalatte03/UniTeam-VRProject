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
    public float movementSpeed = 3f;  // �÷��̾� �̵� �ӵ�

    private CharacterController characterController;  // ĳ���� ��Ʈ�ѷ� ������Ʈ
    private OVRPlayerController ovrPlayerController;  // Oculus �÷��̾� ��Ʈ�ѷ� ������Ʈ

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        ovrPlayerController = GetComponent<OVRPlayerController>();
    }

    private void Update()
    {
        // Oculus Touch ��Ʈ�ѷ��� ���� ��ƽ�� �̿��� �̵� �Է�
        float horizontalInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
        float verticalInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;

        // �̵� ���� ���
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // �̵� �ӵ��� �ð��� ����� �̵� ���� ���
        Vector3 movementVector = movementDirection * movementSpeed * Time.deltaTime;

        // �÷��̾� �̵�
        characterController.Move(transform.TransformDirection(movementVector));

        // Oculus �÷��̾� ��Ʈ�ѷ��� ȸ�� �Է�
        float rotationInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;

        // �÷��̾� ȸ��
        transform.Rotate(Vector3.up * rotationInput);
    }
}