using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scale : MonoBehaviour
{  [SerializeField]
  GameObject plate;

  bool isHolding = false;

  [SerializeField]
  OVRGrabber rightHand;
  [SerializeField]
  OVRGrabber leftHand;
  [SerializeField]
  OVRGrabbable grabbableScript;

  [SerializeField]
  TextMeshPro display;
  string mass2;

  Vector3 scaler= new Vector3(2f,2f,2f);
  Vector3 negscaler = new Vector3(.5f,.5f,.5f);

    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)

    {
      if (col.tag=="Sample1")//(!isHolding && col.tag == "Player")
      {
        isHolding = true;
        mass2 = col.GetComponent<SampleFunctions>().mass;
        display.text= mass2;

      }
    }
    void OnTriggerExit(Collider col)
    {
      if (col.tag == "Sample1")
      {
      isHolding=false;
      display.text= "0";
      }
    }
    public void Reset()
    {
      if (isHolding)
      {
      isHolding = false;
     }
    }
}
