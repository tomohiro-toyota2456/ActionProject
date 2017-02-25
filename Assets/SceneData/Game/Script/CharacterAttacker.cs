namespace Game
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Controller;

public class CharacterAttacker : MonoBehaviour
{
  [SerializeField]
  Skill[] normalAttack = new Skill[3];
  [SerializeField]
  Skill[] skills = new Skill[3];
  [SerializeField]
  Animator animator;

  IController controller;
  public void Start()
  {
   SetData();
  }

  public void SetData()
  {
   string[] names = new string[3];
   names[0] = "back_20";
   names[1] = "back_20_p";
   names[2] = "bb_front_A";
   AnimatorOverrideController newAnime = new AnimatorOverrideController();
   newAnime.runtimeAnimatorController = GetComponent<Animator>().runtimeAnimatorController;
   for (int i = 0; i < normalAttack.Length; i++)
   {
    newAnime[names[i]] = normalAttack[i].AttackObject.AnimationClip;
    GetComponent<Animator>().runtimeAnimatorController = newAnime;
   }
  }
}
}