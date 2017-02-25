namespace Game
{
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

public class AttackObject : MonoBehaviour
{
  [SerializeField]
  AnimationClip animationClip;
  [SerializeField]
  HitObject[] hitObjects;

  public AnimationClip AnimationClip { get { return animationClip; } }

  //判定を行う場所
  public enum JudgmentSiteType
  {
   None,
   HandR,
   HandL,
   FootR,
   FootL,
  }

  [System.Serializable]
  public class HitObject
  {
   public Collider collider;
   public JudgmentSiteType type;
   public bool isJudge;
  }

  public void SetJudgeFlag(bool _flag,int idx)
  {
   hitObjects[idx].isJudge = _flag;
  }

}
}