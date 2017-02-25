namespace Game
{
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

public class FollowCamera : MonoBehaviour
{
  [SerializeField]
  GameObject target;//追従オブジェクト

  // Update is called once per frame
  void Update()
  {
   if (target == null)
    return;

   this.transform.position = target.transform.position;
  }
}
}