namespace Game
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller;
using UniRx;
using UniRx.Triggers;

public class CharacterMover : MonoBehaviour
{
  [SerializeField]
  Rigidbody rdbody;

  [SerializeField]
  CharacterStatus characterStatus;

  IController controller;
  bool isJump = true;
  private void Start()
  {
   controller = GetComponent<IController>();

   if(rdbody == null)
   {
    rdbody = GetComponent<Rigidbody>();
   }

   //ジャンプ
   this.FixedUpdateAsObservable().
    Where(_ => isJump && controller.PushJumpKey()).
    Subscribe((_) =>
    {
     float spd = characterStatus.CurSpd;
     rdbody.AddForce(0, spd, 0);
     isJump = false;
    });

   //移動
   this.FixedUpdateAsObservable().
    Where(_ => isJump && controller.MoveDir().magnitude != 0)
    .Subscribe((_) =>
    {
     float spd = characterStatus.CurSpd * controller.MoveDir().x;
     rdbody.AddForce(spd, 0, 0);
     Debug.Log("test");
    });
  }

}
}