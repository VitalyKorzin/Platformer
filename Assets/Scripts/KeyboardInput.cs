using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private CharacterMovement _characterMovement;

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            _characterMovement.Run();

        if (Input.GetButtonDown("Jump"))
            _characterMovement.Jump();
    }
}