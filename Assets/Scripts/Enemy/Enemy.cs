using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private ContactFilter2D _contactFilter;

    private readonly float _distanceRaycast = 0.5f;
    private SpriteRenderer _spriteRenderer;
    private RaycastHit2D[] _horizontalRaycastHits;
    private RaycastHit2D[] _verticalRaycastHits;
    private float _directionByX;
    private float _directionByY;
    private int _horizontalHitsCount;
    private int _verticalHitsCount;
    private bool _thereIsObstacle;
    private bool _isOnGround;


    private void Awake() => _spriteRenderer = GetComponent<SpriteRenderer>();

    private void Start()
    {
        _horizontalRaycastHits = new RaycastHit2D[1];
        _verticalRaycastHits = new RaycastHit2D[1];
        _directionByX = 1f;
        _directionByY = -1f;
    }

    private void Update()
    {
        CheckPosition();

        if (_isOnGround == false || _thereIsObstacle)
            Revert();

        Move();
    }

    private void CheckPosition()
    {
        CheckRays();
        _thereIsObstacle = _horizontalHitsCount > 0;
        _isOnGround = _verticalHitsCount != 0;
    }

    private void CheckRays()
    {
        _horizontalHitsCount = Physics2D.Raycast(transform.position, transform.right * _directionByX, _contactFilter, _horizontalRaycastHits, _distanceRaycast);
        _verticalHitsCount = Physics2D.Raycast(transform.position, transform.up * _directionByY, _contactFilter, _verticalRaycastHits, _distanceRaycast);
    }

    private void Revert()
    {
        _directionByX *= -1f;
        _spriteRenderer.flipX = _directionByX < 0.0f;
    }

    private void Move() => transform.Translate(_movementSpeed * Time.deltaTime * _directionByX * transform.right);
}