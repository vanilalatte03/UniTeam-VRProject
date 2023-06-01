using UnityEngine;

public class OVRInputEunsu : MonoBehaviour
{
    public float movementSpeed = 8f;  // �÷��̾� �̵� �ӵ�

    private CharacterController characterController;  // ĳ���� ��Ʈ�ѷ� ������Ʈ
    private OVRPlayerController ovrPlayerController;  // Oculus �÷��̾� ��Ʈ�ѷ� ������Ʈ

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