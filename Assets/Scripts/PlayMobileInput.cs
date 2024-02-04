using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMobileInput : MonoBehaviour
{
    // [SerializeField] private mobileJoystick joystick;


    // public float moveSpeed = 5f; // Tốc độ di chuyển của nhân vật

    // private void Awake()
    // {
    //     // Gắn lắng nghe sự kiện từ joystick
    //     joystick.OnMove += HandleMovement;
    // }

    // private void OnDestroy()
    // {
    //     // Hủy lắng nghe sự kiện khi đối tượng bị hủy
    //     joystick.OnMove -= HandleMovement;
    // }

    // private void HandleMovement(Vector2 inputVector)
    // {
    //     // Xử lý di chuyển của nhân vật
    //     Vector3 movement = new Vector3(inputVector.x, 0f, inputVector.y) * moveSpeed * Time.deltaTime;
    //     transform.Translate(movement);
    // }
    // public Vector2 MovementVector {get;private set;}
    // public event Action OnAttack;
    // public event Action OnJumpPressed;
    // public event Action OnJumpReleased;
    // public event Action <Vector2> OnMovement;
    // public event Action OnWeaponChange;
    // [SerializeField]private mobileJoystick joystick;
    // /// <summary>
    // /// Start is called on the frame when a script is enabled just before
    // /// any of the Update methods is called the first time.
    // /// </summary>
    // private void Start()
    // {
    //     joystick.OnMove +=Move;
    // }

    // private void Move(Vector2 input)
    // {
    //     MovementVector = input;
    //     OnMovement?.Invoke(MovementVector);
    // }
}
