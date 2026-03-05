using UnityEngine;
using Unity.Mathematics;
using System;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject feedback;
    Collider _collider;
    Animator _animator;
    [SerializeField] private float _destroyTime = 1;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
    }

    public void Collect()
    {
        Instantiate(feedback, transform.position, transform.rotation);
        _collider.enabled = false;
        _animator.SetTrigger("Collect");
        Destroy(gameObject);

        // Invoke(nameof(DestroyOnAnimationComplete), _destroyTime);
    }

    private void DestroyOnAnimationComplete()
    {
        Destroy(gameObject);
    }
}