using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationPoint;

    private float _previousTime;
    private float _fallTime = 0.8f;

    private static int _width = 10;
    private static int _height = 20;

    private static Transform[,] grid = new Transform[_width, _height];

    private void Update()
    {
        // UNDONE
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left;

            if (!CheckValidPosition())
            {
                transform.position -= Vector3.left;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right;

            if (!CheckValidPosition())
            {
                transform.position -= Vector3.right;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            transform.RotateAround(transform.TransformPoint(_rotationPoint), Vector3.forward , 90f);
            if (!CheckValidPosition())
            {
                transform.RotateAround(transform.TransformPoint(_rotationPoint), Vector3.forward, -90f);
            }
        }

        if (Time.time - _previousTime > (Input.GetKey(KeyCode.S) ? _fallTime / 10 : _fallTime))
        {
            transform.position += Vector3.down;
            if (!CheckValidPosition())
            {
                transform.position -= Vector3.down;
                AddToGrid();
                CheckForLines();

                enabled = false;
                FindObjectOfType<Spawner>().NewBlock();
            }
            _previousTime = Time.time;
        }
    }

    private void CheckForLines()
    {
        for (int i = _height-1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }

    private void RowDown(int i)
    {
        for (int k = i; k < _height; k++)
        {
            for (int j = 0; j < _width; j++)
            {
                if (grid[j,k] != null)
                {
                    grid[j, k - 1] = grid[j, k];
                    grid[j, k] = null;
                    grid[j, k - 1].transform.position -= Vector3.up;
                }
            }
        }
    }

    private void DeleteLine(int i)
    {
        for (int j = 0; j < _width; j++)
        {
            Destroy(grid[j ,i].gameObject);
            grid[j, i] = null;
        }
    }

    private bool HasLine(int i)
    {
        for (int j = 0; j < _width; j++)
        {
            if (grid[j, i] == null)
            {
                return false;
            }
        }
        return true;
    }

    private void AddToGrid() {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }
    }

    private bool CheckValidPosition()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if (roundedX < 0 || roundedX >= _width || roundedY < 0 || roundedY >= _height)
            {
                return false;
            }

            if (grid[roundedX,roundedY] != null)
            {
                return false;
            }
        }
        return true;
    }
}
