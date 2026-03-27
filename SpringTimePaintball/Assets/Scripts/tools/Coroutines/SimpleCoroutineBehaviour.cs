using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class SimpleCoroutineBehaviour : MonoBehaviour
{
    public float seconds = 1;
    private WaitForSeconds _waitForSeconds;
    public UnityEvent @event;
    public UnityEvent @waitEvent;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(seconds);
    }

    private IEnumerator Start()
    {
        while (true)
        {
            yield return _waitForSeconds;
            @event.Invoke();
        }
    }

    public void waitEventInvoke()
    {
        Debug.Log("trying");
        StartCoroutine(nameof(waitForSeconds));
    }

    public IEnumerator waitForSeconds()
    {
        Debug.Log("trying1");
        while (true)
        {
            Debug.Log("trying2");
            yield return _waitForSeconds;
            @waitEvent.Invoke();
        }
    }
}
