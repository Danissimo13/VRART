using System.Collections;
using System.Threading;
using UnityEngine;

public class SpaceActivator : MonoBehaviour
{
    [SerializeField] private float _activationSpeed;
    [SerializeField] private ParticleSystem _starsParticles;

    private Transform _spaceTransform;

    private int _onShowingSpace;
    private int _onHidingSpace;

    private Vector3 _velocity = Vector3.zero;

    private void Start()
    {
        _spaceTransform = GetComponentInChildren<Space>().transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponentInParent<Player>();
        if (player != null)
        {
            var isShowing = Interlocked.Exchange(ref _onShowingSpace, 1);
            if (isShowing == 1) return;
            while (Volatile.Read(ref _onHidingSpace) == 1) { }

            StartCoroutine(SmoothShowSpace());

            Interlocked.Exchange(ref _onShowingSpace, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponentInParent<Player>();
        if (player != null)
        {
            var isHiding = Interlocked.Exchange(ref _onHidingSpace, 1);
            if (isHiding == 1) return;
            while (Volatile.Read(ref _onShowingSpace) == 1) { }

            StartCoroutine(SmoothHideSpace());

            Interlocked.Exchange(ref _onHidingSpace, 0);
        }
    }

    private IEnumerator SmoothShowSpace()
    {
        float x = _spaceTransform.localScale.x;
        float y = _spaceTransform.localScale.y;
        float z = _spaceTransform.localScale.z;
        for (; x <= 9 && y <= 4.5; x += 0.1f, y += 0.05f)
        {
            yield return new WaitForSeconds(1 / _activationSpeed);
            _spaceTransform.localScale = new Vector3(x, y, z);
        }

        _starsParticles.Play();

        yield return null;
    }

    private IEnumerator SmoothHideSpace()
    {
        _starsParticles.Stop();

        float x = _spaceTransform.localScale.x;
        float y = _spaceTransform.localScale.y;
        float z = _spaceTransform.localScale.z;
        for (; x >= 3 && y >= 1.5; x -= 0.1f, y -= 0.05f)
        {
            yield return new WaitForSeconds(1 / _activationSpeed);
            _spaceTransform.localScale = new Vector3(x, y, z);
        }

        yield return null;
    }
}
