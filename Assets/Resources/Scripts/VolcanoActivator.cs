using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoActivator : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponentInParent<Player>();
        if (player != null)
        {
            _particleSystem.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        var player = other.GetComponentInParent<Player>();
        if (player != null)
        {
            _particleSystem.Stop();
            _particleSystem.Clear();
        }
    }
}
