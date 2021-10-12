using System;
using UnityEngine;

public class BlockInput : MonoBehaviour
{
    [SerializeField] private float _speed;
    public static event Action<float> OnMove;

    private void Update()
    {
#if UNITY_EDITOR
        OnMove?.Invoke(Input.GetAxisRaw("Horizontal"));
#endif
#if UNITY_ANDROID
        //_leftButton.gameObject.SetActive(true);
        //_rightButton.gameObject.SetActive(true);
#endif
    }
}
