using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    public Animator animator;
    public GoalPoint goalPoint;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        goalPoint = GetComponent<GoalPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goalPoint.walking)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
