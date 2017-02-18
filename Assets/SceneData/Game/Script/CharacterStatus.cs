namespace Game
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class CharacterStatus : MonoBehaviour
{
  //基礎ステータス値
  [SerializeField]
  int atk;
  [SerializeField]
  int spd;
  [SerializeField]
  int def;
  [SerializeField]
  int maxHp;

  //現在ステータス　バフデバフで遷移するもの
  IntReactiveProperty curMaxHp = new IntReactiveProperty();
  IntReactiveProperty curHp = new IntReactiveProperty();
  int curAtk;
  int curSpd;
  int curDef;

  public enum ParamName
  {
   ATK,
   DEF,
   MAXHP,
   SPD,
  }

  public IntReactiveProperty CurMaxHp { get { return curMaxHp; } }
  public IntReactiveProperty CurHp { get { return curHp; } }
  public int CurAtk { get { return curAtk; } }
  public int CurDef { get { return curDef; } }
  public int CurSpd { get { return curSpd; } }

  private void Start()
  {
   curAtk = atk;
   curDef = def;
   curSpd = spd;
   curHp.Value = maxHp;
   curMaxHp.Value = maxHp;
  }

  //ステータスに補正値をかける
  public void AddCollectionValue(float _time,ParamName _name)
  {

  }

  public void DamageHp(float _WaitTime,uint num,uint value)
  {
   
  }

  public void RecoverHp(float _WaitTime,uint num,uint value)
  {

  }


}
}
