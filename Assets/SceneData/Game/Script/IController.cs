namespace Controller
{
using System.Collections;
using System.Collections.Generic;
 using UnityEngine;
using UniRx;

//基本操作インターフェース
public interface IController
{
  Vector3 MoveDir();//移動
  bool PushJumpKey();//ジャンプ
  bool PushAttackKey();//攻撃
}
}