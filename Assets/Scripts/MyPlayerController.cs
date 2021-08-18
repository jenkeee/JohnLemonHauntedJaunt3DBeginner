using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class MyPlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotationSpeed = 5f;

    private CharacterController controller;
    private PlayerInput playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;

    private InputAction moveAction;
    private InputAction jumpAction;

    // переменные для компонентов
    Animator m_Animator; // ссылка на компонент аниматор
    AudioSource m_AudioSource;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>(); // эта строчка включает котроллер и дает движение лемону. но он подлетает
        m_AudioSource = GetComponent<AudioSource>();
        m_Animator = GetComponent<Animator>();
        cameraTransform = Camera.main.transform; //присваим переменной трансформ камеры значение майнкамеры
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        //playerVelocity.y = 10;

    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized; // будем двигаться относительно камеры
        move.y = 0f; //непонял зачем но эта строчка есть
        controller.Move(move * Time.deltaTime * playerSpeed);


        
        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                    }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        // Rotate toward camera direction.
        float targetAngle = cameraTransform.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        
    }
    private void FixedUpdate()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);

        
        bool hasInput = !Mathf.Approximately(move.x, 0f) || !Mathf.Approximately(move.z, 0f);
        bool isWalking = hasInput;
        if (groundedPlayer)
        {
            m_Animator.SetBool("IsWalking", isWalking); // метод SetBool обращается к параметрам свойствам которые мы создали на компоненте аниматор ранее. Очень важен регистр
        }
        m_Animator.SetBool("IsJump", !groundedPlayer);

        if (isWalking) // проверим идем ли мы
        {
            if (!m_AudioSource.isPlaying) // если звук не играет
            {
                m_AudioSource.Play(); // играем звук
            }
        }
        else
        {
            m_AudioSource.Stop(); // во всех других случаях не играем звук
        }
    }
}