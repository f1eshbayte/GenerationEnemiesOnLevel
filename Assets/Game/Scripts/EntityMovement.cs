using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    private Vector3 _direction;

    private void Update()
    {
        transform.Translate(_direction * (_speed * Time.deltaTime));
    }

    public void SetDirection(Vector3 newDirection)
    {
        _direction = newDirection.normalized;
    }
    
}
