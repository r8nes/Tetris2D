using UnityEngine;

public class Block : MonoBehaviour
{
    private float _previousTime;
    private float _fallTime = 0.8f;
    private static int _height = 20;
    private static int _width = 10;

    private void Update()
    {
        // UNDONE
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left;

            if (!CheckValidMove())
            {
                transform.position -= Vector3.left;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right;

            if (!CheckValidMove())
            {
                transform.position -= Vector3.right;
            }
        }

        if (Time.time - _previousTime > (Input.GetKey(KeyCode.S) ? _fallTime / 10 : _fallTime))
        {
            transform.position += Vector3.down;
            if (!CheckValidMove())
            {
                transform.position -= Vector3.down;
            }
            _previousTime = Time.time;
        }
    }

    private bool CheckValidMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if (roundedX < 0 || roundedX > _width || roundedY < 0 || roundedY >= _height)
            {
                return false;
            }
        }
        return true;
    }
}
