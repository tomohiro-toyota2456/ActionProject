namespace Game
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UniRx.Triggers;

public class AttackStateBehaviour : StateMachineBehaviour
{
  [SerializeField]
  bool isLast;
  public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
   animator.SetBool("isAttack", false);
  }

  public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
   if(isLast)
   {
    animator.SetBool("isAttack", false);
   }
  }

 }
}