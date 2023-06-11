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

    private PlayerState playerState = PlayerState.IDLE;

    private Vector2 playerDirection;

    private void Awake()
    {
        charCntrl = GetComponent<CharacterController>();
        playerAnimCntrl = GetComponent<PlayerAnimationCntrl>();
    }

    private void Start()
    {
        InputControls.OnJump += OnJump;
    }

    // Update is called once per frame
    private void Update()
    {
        switch(playerState)
        {
            case PlayerState.IDLE:
                playerState = PlayerIdle();
                break;
            case PlayerState.MOVE:
                playerState = PlayerMove(Time.deltaTime);
                break;
            case PlayerState.JUMP:
                break;
        }
    }

    private void LateUpdate()
    {
        cameraCntrl.FollowTarget();
    }

    private PlayerState PlayerMove(float dt)
    {
        playerDirection = inputControls.GetMoveDirection();

        if (IsPlayerMoving())
        {
            Vector3 direction = cameraObject.forward * playerDirection.y;
            direction = direction + cameraObject.right * playerDirection.x;
            direction.y = 0.0f;
            direction.Normalize();

            charCntrl.Move(dt * gameData.moveSpeed * direction);

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, gameData.rotationSpeed * dt);

            transform.rotation = playerRotation;

        }
        
        playerAnimCntrl.UpdateAnimation(playerDirection.x, playerDirection.y, dt);

        return (PlayerState.MOVE);
    }

    private PlayerState PlayerIdle()
    {
        playerDirection = inputControls.GetMoveDirection();

        return (IsPlayerMoving() ? PlayerState.MOVE : PlayerState.IDLE);
    }

    private void OnJump()
    {
        Debug.Log("Player Controller Jump ...");
    }

    private bool IsPlayerMoving() => (int)playerDirection.magnitude != 0;

    private enum PlayerState
    {
        IDLE,
        MOVE,
        JUMP
    }
}
