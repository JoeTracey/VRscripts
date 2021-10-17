using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetComp : MonoBehaviour
{
  [SerializeField]
    GameObject selfo ;
[SerializeField]
  SampleManager sampleManager ;
[SerializeField]
CompressionTest ho ;
  [SerializeField]
  GameObject upperClamp;
    [SerializeField]
    GameObject lowerClamp;
  // [SerializeField]
  // SampleFunctions sample3;
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
      sampleManager.Reset();
    ho.Reset();
    // sample.Reset();
    // sample2.Reset();
    // sample3.Reset();
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
