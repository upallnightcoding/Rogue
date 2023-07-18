using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeletonSlaveCntrl : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float moveSpeed;

    private GameObject player = null;

    private SeletonState state = SeletonState.IDLE;

    private CharacterController charCntrl;

    // Start is called before the first frame update
    void Start()
    {
        charCntrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case SeletonState.IDLE:
                state = IdleState();
                break;
            case SeletonState.CHASE:
                state = ChaseState(Time.deltaTime);
                break;
        }
    }

    public void SetPlayer(GameObject player) 
    {
        this.player = player;
    }

    private SeletonState IdleState()
    {
        return ((player == null) ? SeletonState.IDLE : SeletonState.CHASE);
    }

    private SeletonState ChaseState(float dt)
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        Vector3 direction = (player.transform.position - transform.position).normalized;
        direction.y = 0.0f;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * dt);

        transform.rotation = rotation;

        Vector3 moveSkeleton = transform.forward * moveSpeed * dt;

        charCntrl.SimpleMove(moveSkeleton);

        return (SeletonState.CHASE);
    }

    private enum SeletonState
    {
        IDLE,
        CHASE
    }
}
