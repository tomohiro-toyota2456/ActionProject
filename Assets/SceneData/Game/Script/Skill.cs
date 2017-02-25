namespace Game
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
  [SerializeField]
  AttackObject attackObject;
  [SerializeField]
  SkillType skillType;

  public AttackObject AttackObject { get { return attackObject; }set { attackObject = value; } }

  public enum SkillType
  {
   Buff,
   Attack,
  }

}
}
