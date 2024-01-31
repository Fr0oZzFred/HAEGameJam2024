using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class DelayEvent : MonoBehaviour
{
    [SerializeField] float duration = 1.0f;
    [SerializeField] UnityEvent onDelayFinished;
    private void OnEnable() {
        StartCoroutine(Delay());
    }
    IEnumerator Delay() {
        yield return new WaitForSeconds(duration);
        if (!this.gameObject.activeInHierarchy) yield break;
        onDelayFinished.Invoke();
    }
}
