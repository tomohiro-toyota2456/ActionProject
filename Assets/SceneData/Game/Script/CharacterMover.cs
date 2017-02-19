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
  BoolReactiveProperty isJump = new BoolReactiveProperty(true);
  public BoolReactiveProperty IsJump { get { return isJump; } }

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
    Where(_ =>isJump.Value &&controller.PushJumpKey()).
    Subscribe((_) =>
    {
     spd.y = characterStatus.CurJump;
     isJump.Value = false;
    });

   //移動
   this.UpdateAsObservable().
    Where(_ =>controller.MoveDir().magnitude != 0)
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

     //0にしてあげないと横への動きがおかしくなる
     if(isJump.Value && spd.y < 0)
     {
      spd.y = 0;
     }

    });

   groundHitBox.OnTriggerEnterAsObservable()
    .Where(_ => _.tag == "Ground" && rdbody.velocity.y <= 0)
    .Subscribe(_ => IsJump.Value = true);
  }

}
}