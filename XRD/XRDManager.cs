using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class XRDManager : MonoBehaviour
{
  [SerializeField]
  GameObject self;
  [SerializeField]
  HingeJoint motor;
  [SerializeField]
  GameObject door1;
  [SerializeField]
  GameObject door2;
  [SerializeField]
  GameObject starterLoc;
  Vector3 sampleDest;
  bool doorStat = false; //false means open, do not run
  bool sampleInPlace = false;
  Vector3 d1start;
  Vector3 d2start;

  [SerializeField]
  OVRGrabber rightHand;
  [SerializeField]
  OVRGrabber leftHand;
  JointMotor moto;
    // Start is called before the first frame update
    [SerializeField]
    GameObject machine;
  GameObject page;
  GameObject currentSample;
  [SerializeField]
  GameObject PrintedPosition;
    void Start()
    {
      d1start = door1.transform.position;
      d2start = door2.transform.position;
      sampleDest = starterLoc.transform.position;
      // HingeJoint motorJ = motor.GetComponent<HingeJoint>();
    moto = motor.motor;
    machine.transform.position -= new Vector3(0f,10f,0f); 
    }

    void OnTriggerEnter(Collider obj)
    {
      if (!sampleInPlace && obj.tag == "XRD")
      {
        Debug.Log(obj.tag);
        OVRGrabbable grabbableScript = obj.gameObject.GetComponent<OVRGrabbable>();
        rightHand.ForceRelease(grabbableScript);
        leftHand.ForceRelease(grabbableScript);
        Rigidbody rigid= obj.gameObject.GetComponent<Rigidbody>();
        rigid.isKinematic=true;
        sampleInPlace = true;
        Debug.Log("XRD Sample in Place ^");
        Transform trans= obj.gameObject.GetComponent<Transform>();

        trans.position = sampleDest;
        trans.rotation =Quaternion.Euler(0,0,0);
        // GameObject currentSample;
        currentSample = obj.gameObject;
      }
    }

    void OnTriggerExit(Collider obj)
    {
      if (sampleInPlace && obj.tag == "XRD")
      {

        Rigidbody rigid= obj.gameObject.GetComponent<Rigidbody>();
          sampleInPlace = false;
        Debug.Log("XRD sample out of place");
        rigid.isKinematic=true;
      }
    }

    public void CloseDoors()
    {
      door1.transform.position -= new Vector3(.8f,0,0);
        door2.transform.position += new Vector3(.8f,0,0);
    }

    public void OpenDoors()
    {
      door1.transform.position += new Vector3(.8f,0,0);
        door2.transform.position -= new Vector3(.8f,0,0);

    }
    //
    // public void SpinMotorOn()
    // {
    //
    //     Debug.Log("time to spin");
    //   motor.targetVelocity = 20;
    //   Thread.Sleep(600);
    //
    //     Debug.Log("That's 6 seconds");
    //   PrintResults();
    //   SpinMotorOff();
    // }
    //
    // public void SpinMotorOff()
    // {
    //
    //
    //     Debug.Log("ReverseTime");
    //   motor.targetVelocity = -20;
    //   Thread.Sleep(600);
    //           Debug.Log("Reversed for 6 seconds");
    //   motor.targetVelocity = 0;
    // }

    public void PrintResults()
    {

    }

    public void DoorButton()
    {
      if (doorStat)
      {
        OpenDoors();
        doorStat = false;
      }
      else
      {
        CloseDoors();
        doorStat = true;
      }
    }

    public void RunXRD()
    {
      StartCoroutine(XRDhelper());
    }
    IEnumerator XRDhelper()
    {
      Debug.Log("RunningXRD");
      if (doorStat && sampleInPlace)
      {
        Debug.Log("good to go");
        // SpinMotorOn();
        Debug.Log("time to spin");
      moto.targetVelocity = 20;
      motor.motor = moto;
      yield return new WaitForSeconds(6);
      // Thread.Sleep(600);

        Debug.Log("That's 6 seconds");
      PrintResults();
      // SpinMotorOff();

        Debug.Log("ReverseTime");
      Debug.Log(moto.targetVelocity );
      moto.targetVelocity = -20;
      motor.motor = moto;
       Debug.Log(moto.targetVelocity );
       Debug.Log(moto.force);
      // Thread.Sleep(600);
      yield return new WaitForSeconds(6);
              Debug.Log("Reversed for 6 seconds");
      moto.targetVelocity = 0;
      motor.motor = moto;
          PrintGraph();

      }
      else
      {

          Debug.Log("sorry not ready - XRD");
          Debug.Log(doorStat);
          Debug.Log(sampleInPlace);
      }

    }


    public void PrintGraph()
    {
      Debug.Log("Printed XRD Graph");
      page = currentSample.GetComponent<SampleFunctions>().originalGraph;
      // page.GetComponent<Transform>().position =PrintedPosition;
      page.transform.GetComponent<Transform>().position =PrintedPosition.GetComponent<Transform>().position;
      page.transform.GetComponent<Transform>().rotation =PrintedPosition.GetComponent<Transform>().rotation;
      // page.transform.rotation =Quaternion.Euler(90,0,0);
    }

}
