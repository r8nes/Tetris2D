using UnityEngine;

public class Block : MonoBehaviour
{
    private float _fallTime;
    private float _previousTime;

    [SerializeField] private float _speed;
    private void Update()
    {
        // UNDONE
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right;
        }

        if (Time.time - _previousTime > (Input.GetKey(KeyCode.S) ? _fallTime / 10 : _fallTime))
        {
            transform.position += Vector3.down;
            _previousTime = Time.time;
        }
    }
}
