using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

    [SerializeField] float speed = 10.0f;

    //movement
    float mx, my = 0.0f;


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        UpdateMovementInput();
    }
    private void FixedUpdate() {
        //update pos
        Vector3 newPos = new(mx * Time.deltaTime, my * Time.deltaTime, 0);

        this.transform.position += newPos * speed;

    }

    void UpdateMovementInput() {
        mx = my = 0.0f;
        mx += Keyboard.current.dKey.value;
        mx += Keyboard.current.qKey.value * -1;
        mx += Keyboard.current.aKey.value * -1;
        my += Keyboard.current.zKey.value;
        my += Keyboard.current.wKey.value;
        my += Keyboard.current.sKey.value * -1;
        Mathf.Clamp(mx, 0.0f, 1.0f);
        Mathf.Clamp(my, 0.0f, 1.0f);

    }
}
