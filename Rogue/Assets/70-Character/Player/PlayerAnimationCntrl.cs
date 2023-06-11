using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationCntrl : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private int horizontalName;
    private int verticalName;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();

        horizontalName = Animator.StringToHash("Horizontal");
        verticalName = Animator.StringToHash("Vertical");
    }

    public void UpdateAnimation(float horizontal, float vertical, float dt)
    {
        animator.SetFloat(horizontalName, Mathf.Abs(horizontal), 0.1f, dt);
        animator.SetFloat(verticalName, Mathf.Abs(vertical), 0.1f, dt);
    }
}
