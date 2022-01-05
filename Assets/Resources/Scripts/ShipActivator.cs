using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipActivator : MonoBehaviour
{
    [SerializeField] private ShipSceneStarter _shipSS;
    [SerializeField] private BreakableWindow windowPrefab;
    [SerializeField] private BreakableWindow _window;

    private bool isTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponentInParent<Player>();
        if (player != null)
        {
            if (isTriggered) return;
            _shipSS.Run();
            isTriggered = true;
            StartCoroutine(breakWindow());
        }
    }

    void OnTriggerExit(Collider other)
    {
        var player = other.GetComponentInParent<Player>();
        if (player != null)
        {
            _shipSS.Stop();
            isTriggered = false;
        }
    }

    IEnumerator breakWindow()
    {
        yield return new WaitForSeconds(1.2f);
        _window.breakWindow();
        var newWindow = Instantiate(windowPrefab);
        Destroy(_window);
        _window = newWindow;
    }
}
