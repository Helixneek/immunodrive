using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AltShooter : MonoBehaviour
{
    Shooter shooter;

    void Awake() {
        shooter = GetComponent<Shooter>();
    }

    void OnFire(InputValue value) {
        if(shooter != null) {
            shooter.isFiring = value.isPressed;
        }
    }
}
