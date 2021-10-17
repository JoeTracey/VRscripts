using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrateCharpy : MonoBehaviour
{
  [SerializeField]
    GameObject selfo ;
[SerializeField]
  CharpySwingingObject hammer ;
  [SerializeField]
  BoxCollider collider;
  [SerializeField]
  Vector3 buttonPress;
  bool on = false;
  Vector3 movement = new Vector3(.01f, .01f, .01f);
  //Vector3 travel = Vector3.Scale(movement, buttonPress);

  void Start()
  {

  }
  void OnTriggerEnter(Collider col)
  {
    if(on== false)
    {
      hammer.Calibrate();
    selfo.transform.position += Vector3.Scale(movement, buttonPress);
    collider.size -= Vector3.Scale(movement, buttonPress);
    on = true;
  }

  }
  void OnTriggerExit(Collider col)
  {
    if (on == true)
    {
    selfo.transform.position -=  Vector3.Scale(movement, buttonPress);
    on = false;
  }
  }
}
