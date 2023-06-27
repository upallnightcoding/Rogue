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

    private PlayerState playerState = PlayerState.START;

    private void Awake()
    {
        charCntrl = GetComponent<CharacterController>();
        playerAnimCntrl = GetComponent<PlayerAnimationCntrl>();
    }

    private void Start()
    {
        InputControls.OnJump += OnJump;
    }

    private void Update()
    {
        Vector2 playerDirection = inputControls.GetMoveDirection();
        //Debug.Log($"Direction: {playerDirection.x}, {playerDirection.y}");

        switch (playerState)
        {
            case PlayerState.START:
                playerState = PlayerStart();
                break;
            case PlayerState.IDLE:
                playerState = PlayerIdle(playerDirection);
                break;
            case PlayerState.MOVE:
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
    }

    private bool IsPlayerMoving(Vector2 playerDirection) => (int)playerDirection.magnitude != 0;

    private enum PlayerState
    {
        START,
        IDLE,
        MOVE,
        JUMP
    }
}
