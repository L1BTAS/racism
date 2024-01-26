using UnityEngine;
using UnityEngine.InputSystem;

public class Abilities : MonoBehaviour
{
    public PlayerInput playerInput;
    public Rigidbody2D rb2d;
    public float teleportDistance = 5f;

    private void OnEnable()
    {
        playerInput.actions["Ability"].performed += Blink;
    }

    private void OnDisable()
    {
        playerInput.actions["Ability"].performed -= Blink;
    }

    private void Blink(InputAction.CallbackContext context)
    {
            // �������� ������� ������� ���������
            Vector2 currentPosition = rb2d.position;

            // ��������� ����� ������� � ������ ����������� �������� � ���������� ������������
            Vector2 newPosition = currentPosition + rb2d.velocity.normalized * teleportDistance;

            // ������������� ���������
            rb2d.MovePosition(newPosition);
    }
}
