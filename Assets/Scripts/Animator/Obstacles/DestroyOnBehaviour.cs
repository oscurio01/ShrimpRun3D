using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnBehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject explosionDestroy = PoolingManager.Instance.GetPooledObject("DestroyEffect");

        if (explosionDestroy != null)
        {
            explosionDestroy.transform.position = animator.transform.position;
            explosionDestroy.SetActive(true);

            var pParticles = explosionDestroy.GetComponent<ParticleSystem>();
            var main = pParticles.main;
            main.stopAction = ParticleSystemStopAction.Disable;
            explosionDestroy.GetComponent<ParticleSystem>().Play();

        }

        animator.gameObject.transform.parent.gameObject.SetActive(false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
