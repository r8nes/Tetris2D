using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Block[] _blocks;

    private void Start()
    {
        NewBlock();
    }
    public void NewBlock() {
        Instantiate(_blocks[Random.Range(0, _blocks.Length)], transform.position, Quaternion.identity);
    }
}
