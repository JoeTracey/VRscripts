using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectricTester : MonoBehaviour
{  [SerializeField]
  GameObject node;
//  [SerializeField]
//  GameObject key;
  bool isHolding = false;
  [SerializeField]
  Light ledr;
  [SerializeField]
  Light ledo;
  [SerializeField]
  Light ledy;
  [SerializeField]
  Light ledg;
  [SerializeField]
  Light ledw;
  [SerializeField]
  OVRGrabber rightHand;
  [SerializeField]
  OVRGrabber leftHand;
//[SerializeField]
  OVRGrabbable grabber;
  [SerializeField]
  BoxCollider collider;
  [SerializeField]
  GameObject voltageDisplay;
  [SerializeField]
  GameObject resistanceDisplay;
  [SerializeField]
  GameObject currentDisplay;
  Vector3 scaler= new Vector3(2f,2f,2f);
  Vector3 negscaler = new Vector3(.5f,.5f,.5f);
  //bool isKin= true;
  float current;
  float resistance;
  [SerializeField]
  float voltage;
    void Start()
    {
      ShowNull();

    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)

    {
      if (col.tag=="Sample1" || col.tag == "SampleTensile")//(!isHolding && col.tag == "Player")
      {

        resistance = col.GetComponent<SampleFunctions>().resistance;
        conductTest(resistance);
        isHolding = true;
        Rigidbody rigid= col.gameObject.GetComponent<Rigidbody>();
//        rigid.isKinematic=true;
        grabber = col.GetComponent<OVRGrabbable>();
        rightHand.ForceRelease(grabber);
        leftHand.ForceRelease(grabber);
        rigid.isKinematic=true;
        col.transform.position = node.transform.position  + new Vector3(-.26f,0,0);
        col.transform.rotation =Quaternion.Euler(0,90,0);
        collider.size = new Vector3(2,2,2);
        if (resistance <= 5)
        {ledr.intensity = 130;
        if (resistance <= 4)
        {ledo.intensity = 120;
        if (resistance <= 3)
        {ledy.intensity = 100;
        if (resistance <= 2)
        {ledg.intensity = 100;
        if (resistance <= 1)
        {ledw.intensity = 100;
        }}}}}
        voltageDisplay.GetComponent<Text>().text = voltage.ToString() + " V";
        resistanceDisplay.GetComponent<Text>().text = resistance.ToString();
        currentDisplay.GetComponent<Text>().text = current.ToString();
      }
        //Vector3 size = collider.size;
        //collider.size = Vector3.Scale(size, scaler);
      }

    void OnTriggerExit(Collider col)
    {
      if (col.tag == "Sample1")
      {

        Rigidbody rigid= col.gameObject.GetComponent<Rigidbody>();
        rigid.isKinematic=false;
      ledr.intensity = 0;
      ledo.intensity = 0;
      ledy.intensity = 0;
      ledg.intensity = 0;
      ledw.intensity = 0;
      isHolding=false;
      collider.size = new Vector3(1,1,1);
      ShowNull();
      }
    }
    public void Reset()
    {
      if (isHolding)
      {
      isHolding = false;
     }
    }
    void conductTest(float sampleResist)
    {
      resistance = sampleResist;
      current = voltage / resistance;


    }
    void ShowNull()
    {
      voltageDisplay.GetComponent<Text>().text = voltage.ToString();
      resistanceDisplay.GetComponent<Text>().text = "inf";
      currentDisplay.GetComponent<Text>().text = "0";
    }
}
