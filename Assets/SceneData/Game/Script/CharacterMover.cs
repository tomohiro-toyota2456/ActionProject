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
  BoxCollider groundHitBox;//地面との判定ジャンプ判定に使う


  [SerializeField]
  CharacterStatus characterStatus;

  IController controller;
  bool isJump = true;
  public bool IsJump { set { isJump = value; } }

  Vector3 spd;

  private void Start()
  {
   controller = GetComponent<IController>();

   if(rdbody == null)
   {
    rdbody = GetComponent<Rigidbody>();
   }

   //ジャンプ
   this.UpdateAsObservable().
    Where(_ =>isJump &&controller.PushJumpKey()).
    Subscribe((_) =>
    {
     spd.y = characterStatus.CurSpd *5;
     isJump = false;
    });

   //移動
   this.UpdateAsObservable().
    Where(_ => isJump && controller.MoveDir().magnitude != 0)
    .Subscribe((_) =>
    {
     spd.x = characterStatus.CurSpd * controller.MoveDir().x;
    });

   this.FixedUpdateAsObservable()
    .Subscribe((_) => 
    {
     rdbody.velocity = spd;
     spd.x *= 0.8f;
     spd.y -= 0.8f;

     if(isJump && spd.y < 0)
     {
      spd.y = 0;
     }

    });

   groundHitBox.OnTriggerEnterAsObservable()
    .Where(_ => _.tag == "Ground" && rdbody.velocity.y <= 0)
    .Subscribe(_ => IsJump = true);
  }

}
}