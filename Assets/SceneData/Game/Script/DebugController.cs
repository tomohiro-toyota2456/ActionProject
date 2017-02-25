namespace Controller
{
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 public class DebugController : MonoBehaviour, IController
 {
  // Update is called once per frame
  bool isJump;
  bool isAttack;
  Vector3 moveDir;

  void Update()
  {
   moveDir = Vector3.zero;
   isJump = false;
   isAttack = false;
   if (Input.GetKey(KeyCode.D))
   {
    moveDir.x = 1.0f;
   }
   else if (Input.GetKey(KeyCode.A))
   {
    moveDir.x = -1.0f;
   }

   if (Input.GetKeyUp(KeyCode.Space))
   {
    isJump = true;
   }

   if (Input.GetKeyDown(KeyCode.KeypadEnter))
   {
    isAttack = true;
   }


  }

  public bool PushJumpKey()
  {
   return isJump;
  }

  public bool PushAttackKey()
  {
   return isAttack;
  }

  public Vector3 MoveDir()
  {
   return moveDir;
  }

 }
}