using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : StateMachineBehaviour
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
        GameObject explosion = PoolingManager.Instance.GetPooledObject("ExplosionEffect");

        if(explosion != null)
        {
            explosion.transform.position = animator.transform.position;
            explosion.SetActive(true);

            var pParticles = explosion.GetComponent<ParticleSystem>();
            var main = pParticles.main;
            main.stopAction = ParticleSystemStopAction.Disable;
            explosion.GetComponent<ParticleSystem>().Play();

            Collider[] hitColliders = Physics.OverlapSphere(new Vector3(animator.gameObject.transform.position.x, animator.gameObject.transform.position.y-1, animator.gameObject.transform.position.z), 6.45f, 3);
            foreach (var hitCollider in hitColliders)
            {

                if (hitCollider.GetComponent<PlayerLevelController>())
                {
                    for (int i = 0; i < (hitCollider.GetComponent<PlayerLevelController>().GetMaxFollowersShrimps() + 1); i++)
                    {
                        hitCollider.GetComponent<PlayerLevelController>().DecreaseShrimp();
                    }
                }
            }

        }
        
        animator.gameObject.SetActive(false);
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
