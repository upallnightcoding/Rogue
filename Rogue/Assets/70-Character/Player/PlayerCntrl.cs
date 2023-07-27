using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private InputControls inputControls;
    [SerializeField] private Transform cameraObject;
    [SerializeField] private CameraCntrl cameraCntrl;

    private CharacterController charCntrl;
    private PlayerAnimationCntrl playerAnimCntrl;

    private float gravitySpeed = 0.0f;
    private float gravity = -9.81f;

    private PlayerState playerState = PlayerState.INIT;

    private void Awake()
    {
        charCntrl = GetComponent<CharacterController>();
        playerAnimCntrl = GetComponent<PlayerAnimationCntrl>();
    }

    private void Start()
    {
        InputControls.OnJump += OnJump;
        InputControls.OnOffensive1 += OnOffensive1;
        InputControls.OnOffensive2 += OnOffensive2;
        InputControls.OnOffensive3 += OnOffensive3;
        InputControls.OnOffensive4 += OnOffensive4;
        InputControls.OnOffensive5 += OnOffensive5;

        if (gameData.IsCombatMode())
        {
            StartPlay();
        }
    }

    private void Update()
    {
        Vector2 playerDirection = inputControls.GetMoveDirection();

        bool offenseButton = inputControls.GetLeftMouseButton();
        bool defenseButton = inputControls.GetRightMouseButton();

        switch (playerState)
        {
            case PlayerState.INIT:
                playerState = PlayerInit();
                break;
            case PlayerState.START:
                playerState = PlayerStart();
                break;
            case PlayerState.IDLE:
                playerState = PlayerIdle(playerDirection);
                break;
            case PlayerState.MOVE:
                PlayerAttack(offenseButton, defenseButton);
                playerState = PlayerMove(playerDirection, Time.deltaTime);
                break;
            case PlayerState.JUMP:
                break;
        }
    }

    private void LateUpdate()
    {
        cameraCntrl.HandleAllCameraMovement();
    }

    public void StartPlay()
    {
        playerState = PlayerState.START;
    }

    private PlayerState PlayerInit()
    {
        return ((playerState == PlayerState.INIT) ? PlayerState.INIT : PlayerState.START);
    }

    private PlayerState PlayerStart()
    {
        transform.position = gameData.playerStartingArena;
        return ((gameData.playerStartingArena == Vector3.zero) ? PlayerState.START : PlayerState.IDLE);
    }

    private PlayerState PlayerMove(Vector2 playerDirection, float dt)
    {
        if (IsPlayerMoving(playerDirection))
        {
            MovePlayerDirection(playerDirection, dt);
        }
        
        playerAnimCntrl.UpdateAnimation(playerDirection.x, playerDirection.y, dt);

        return (PlayerState.MOVE);
    }

    //private float lastOffenseTime = Time.realtimeSinceStartup;
    private float lastOffenseTime = 0.0f;
    
    private void PlayerAttack(bool offenseButton, bool defenseButton)
    {
        float currentTime = Time.realtimeSinceStartup;

        float delta = currentTime - lastOffenseTime;

        if (delta > 1.0f)
        {
            Debug.Log($"delta time: {delta}");
            lastOffenseTime = currentTime;

        }
        Debug.Log($"Offense: {offenseButton}");
    }

    private void MovePlayerDirection(Vector2 playerDirection, float dt)
    { 
        if (!charCntrl.isGrounded)
        {
            gravitySpeed += gravity * Time.deltaTime;
        } else {
            gravitySpeed = 0.0f;
        }

        Vector3 direction = cameraObject.forward * playerDirection.y;
        direction = direction + cameraObject.right * playerDirection.x;
        direction.y = 0.0f;
        direction.Normalize();

        Vector3 hortMovement = gameData.moveSpeed * direction;
        Vector3 vertMovement = Vector3.up * gravitySpeed;

        charCntrl.Move(dt * (vertMovement + hortMovement));

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, gameData.rotationSpeed * dt);

        transform.rotation = playerRotation;
    }

    private PlayerState PlayerIdle(Vector2 playerDirection)
    {
        return (IsPlayerMoving(playerDirection) ? PlayerState.MOVE : PlayerState.IDLE);
    }

    private void OnJump()
    {
        Debug.Log("Player Controller Jump ...");

        if (gameData.IsDevelopmentMode())
        {
            GameManager.Instance.AddGem(3);
        }
    }

    private void OnOffensive1()
    {
        Debug.Log("Defence 1 ...");

        playerAnimCntrl.Offensive1Animation();
    }

    private void OnOffensive2()
    {
        Debug.Log("Defence 2 ...");
    }

    private void OnOffensive3()
    {
        Debug.Log("Defence 3 ...");
    }

    private void OnOffensive4()
    {
        Debug.Log("Defence 4 ...");
    }

    private void OnOffensive5()
    {
        Debug.Log("Defence 5 ...");
    }

    private bool IsPlayerMoving(Vector2 playerDirection) => (int)playerDirection.magnitude != 0;

    private enum PlayerState
    {
        INIT,
        START,
        IDLE,
        MOVE,
        JUMP
    }
}
