using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Prop : MonoBehaviour {

    [SerializeField] UnityEvent onPlayerEnter;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject == LevelManager.Instance.Player.gameObject)
            OnPlayerTouched(collision.gameObject.GetComponent<Player>());
    }

    public virtual void OnPlayerTouched(Player player) {
        onPlayerEnter.Invoke();
    }
}
