using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CollisionBehavior : MonoBehaviour
{
    public UnityEvent startEvent, collisionEnterEvent, respondLateEvent;
    public float holdTime = 0.1f;
    private WaitForSeconds waitObj;

    private void Awake()
    {
        waitObj = new WaitForSeconds(holdTime);
    }
    protected virtual void Start()
    {
        startEvent.Invoke();
    }
    
    protected virtual void OnCollisionEnter(Collision collision)
    {
        collisionEnterEvent.Invoke();

        if (!gameObject.activeInHierarchy) return;
        StartCoroutine(RespondLate());
    }

    private IEnumerator RespondLate()
    {
        yield return waitObj;
        respondLateEvent.Invoke();
    }
}
