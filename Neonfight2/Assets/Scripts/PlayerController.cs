using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _playerSpeed = 5f;

    [SerializeField]
    private float _rotationSpeed = 20f;

    [SerializeField]
    private Camera _followCamera;

    private Vector3 _playerVelocity;
    private bool _groundedPlayer;

    [SerializeField]
    private float _jumpHeight = 1.0f;
    [SerializeField]
    private float _gravityValue = -20.0f;

    [SerializeField]
    private float _maxPlayerLifePoints = 5f;
    [SerializeField]
    private float _currentPlayerLifePoints;
   

    private void Start()
    {
        _controller = GetComponent<CharacterController>();

        // Hides the mouse
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _currentPlayerLifePoints = _maxPlayerLifePoints;
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        _groundedPlayer = _controller.isGrounded;

        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementInput = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);
        //Vector3 movementInput = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 movementDirection = movementInput.normalized;

        _controller.Move(movementDirection * _playerSpeed * Time.deltaTime);

          

        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _rotationSpeed * Time.deltaTime);
        }

            //Debug
            if (_groundedPlayer)
            {
               // print("Grounded");
            }

        if (Input.GetButtonDown("Jump")) //&& _groundedPlayer
        {
            print("Jump!");

            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }


       public void TakeDamage(float damageAmount)
        {
            _currentPlayerLifePoints -= damageAmount;
            if (_currentPlayerLifePoints <= 0)
            {
                Die();
            }
        }
        private void Die()
        {
            // Handle player death (e.g., play animation, restart level, etc.)
            Debug.Log("PLAYER DIED");
        }



}