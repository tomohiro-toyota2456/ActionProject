namespace Game
{
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UniRx;
 using UniRx.Triggers;
 using Controller;

public class CharacterAnimationController : MonoBehaviour
{
  [SerializeField]
  Animator animator;//アニメーション制御用
  [SerializeField]
  Rigidbody rdbody;


  string RunState = "isRun";
  string JumpState = "isJump";

  BoolReactiveProperty isJump;
  IController controller;

  float rot = 90.0f;

  // Use this for initialization
  void Start()
  {
   controller = GetComponent<IController>();
   isJump = GetComponent<CharacterMover>().IsJump;

   //ジャンプ監視
   isJump
   .Subscribe((flag) =>
   {
    animator.SetBool(JumpState,!flag);
   });

   //移動監視
   this.UpdateAsObservable()
    .Subscribe((_) => 
    {
     if(controller.MoveDir().x >=0.1f || controller.MoveDir().x <= -0.1f )
     {
      rot = 90*controller.MoveDir().x;
      animator.SetBool(RunState, true);
     }
     else
     {
      animator.SetBool(RunState, false);
     }

     transform.rotation = Quaternion.Euler(0, rot, 0);
     Debug.Log(controller.MoveDir().ToString());
    });

   this.UpdateAsObservable()
    .Where(_ => controller.PushAttackKey())
    .Subscribe(_ =>
    {
     animator.SetBool("isAttack", true);
    });
    
  }
}
}
