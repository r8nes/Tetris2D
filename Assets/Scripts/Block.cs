using UnityEngine;

public class Block : MonoBehaviour
{
    private float _directionX;
    private Vector2 targetPos;
    private float _xIncrement = 1f;

    [SerializeField]private float _speed;
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, _speed * Time.deltaTime);

        if (_directionX != 0)
        {
            targetPos =  new Vector2(_directionX + _xIncrement, 0);
            transform.position = targetPos;
        }
    }

    private void GetDirectionX(float direction)
    {
        _directionX = direction;
    }

    private void OnEnable()
    {
        BlockInput.OnMove += GetDirectionX;
    }

    private void OnDisable()
    {
        BlockInput.OnMove -= GetDirectionX;
    }
}
