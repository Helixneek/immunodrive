using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement and Bounds")]
    [SerializeField] float MoveSpeed = 5f;
    Vector2 rawInput;

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    
    Vector2 minBounds;
    Vector2 maxBounds;

    [Header("Inventory")]
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;
    Shooter shooter;

    private void Awake() {
        shooter = GetComponent<Shooter>();
    }

    void Start() {
        initBounds();

        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    void Update()
    {
        Move();
    }

    void initBounds() {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    void Move() {
        Vector3 delta = rawInput * MoveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);

        transform.position = newPos;
    }

    void OnMove(InputValue value) {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value) {
        if(shooter != null) {
            shooter.isFiring = value.isPressed;
        }
    }
}
