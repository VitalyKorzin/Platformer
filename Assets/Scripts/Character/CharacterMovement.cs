using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(Animator))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;

    private readonly float _availableDistanceFromGroundToJump = 0.01f;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector3 _directionMovement;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        if (IsOnGround())
            SetState(State.Idle);
        else
            SetState(State.Jump);
    }

    public void Run()
    {
        if (IsOnGround())
            SetState(State.Run);

        _directionMovement = transform.right * Input.GetAxis("Horizontal");
        transform.Translate(_runSpeed * Time.deltaTime * _directionMovement);
        _spriteRenderer.flipX = _directionMovement.x < 0.0f;
    }

    public void Jump()
    {
        if (IsOnGround())
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void SetState(State state) => _animator.SetInteger("State", (int)state);

    private bool IsOnGround() => Mathf.Abs(_rigidbody.velocity.y) < _availableDistanceFromGroundToJump;
}