using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharpyManager : MonoBehaviour
{
  [SerializeField]
  GameObject self;
  // [SerializeField]
  // GameObject starterLoc;
  Vector3 sampleDest;
  bool sampleInPlace = false;

    [SerializeField]
    GameObject leftSide;
    [SerializeField]
    GameObject rightSide;
  [SerializeField]
  OVRGrabber rightHand;
  [SerializeField]
  OVRGrabber leftHand;

  [SerializeField]
  GameObject sampleLocHolder;
   [SerializeField]
  BoxCollider collider;
  Quaternion samplerot;
  SampleFunctions sampleClone;
    Vector3 leftSideSpot;
    Quaternion leftSideOrient;
    Vector3 rightSideSpot;
    Quaternion rightSideOrient;
    SampleFunctions currentRight;
    SampleFunctions currentLeft;
    GameObject currentSample;
    int heatVal;
  // JointMotor moto;
    // Start is called before the first frame update
    void Start()
    {
      // d1start = 
      leftSideSpot = leftSide.GetComponent<Transform>().position;
      leftSideOrient = leftSide.GetComponent<Transform>().rotation;
      rightSideSpot = rightSide.GetComponent<Transform>().position;
      rightSideOrient = rightSide.GetComponent<Transform>().rotation;
      // door1.transform.position;
      // d2start = door2.transform.position;
      sampleDest = sampleLocHolder.GetComponent<Transform>().position;
      // System.Threading.Thread.Sleep(5000);
      self.transform.position-= new Vector3(0, 5 , 0);
      // HingeJoint motorJ = motor.GetComponent<HingeJoint>();
    // moto = motor.motor;
    }

    void OnTriggerEnter(Collider obj)
    {Debug.Log("xrdTrigEnter");
      Debug.Log(obj);
      if ( obj.tag == "CVN")
      {
        Debug.Log(obj.tag);
        OVRGrabbable grabbableScript = obj.gameObject.GetComponent<OVRGrabbable>();
        rightHand.ForceRelease(grabbableScript);
        leftHand.ForceRelease(grabbableScript);
        // Rigidbody rigid= obj.gameObject.GetComponent<Rigidbody>();
        // rigid.isKinematic=true;
        sampleInPlace =  true;
        Transform trans= obj.gameObject.GetComponent<Transform>();
        heatVal = obj.GetComponent<SampleFunctions>().sampleTempIndex;
        Debug.Log("Heat Val;");
        Debug.Log(heatVal);
        if (heatVal == 0){
        currentRight = obj.GetComponent<SampleFunctions>().sampleRight;
        currentLeft = obj.GetComponent<SampleFunctions>().sampleLeft;
        }
        if (heatVal == 1){
        currentRight = obj.GetComponent<SampleFunctions>().sampleRightHot;
        currentLeft = obj.GetComponent<SampleFunctions>().sampleLeftHot;
        }
        if (heatVal == 3){
        currentRight = obj.GetComponent<SampleFunctions>().sampleRightCold;
        currentLeft = obj.GetComponent<SampleFunctions>().sampleLeftCold;
        }
        trans.position = sampleDest;

        // trans.rotation =Quaternion.Euler(0,0,0);
        // GameObject currentSample;
        currentSample = obj.gameObject;
        // Split(currentSample);
        Debug.Log("Moving splits around");
        currentSample.transform.position = sampleDest;
        currentLeft.transform.rotation = leftSideOrient;
        currentLeft.transform.position = leftSideSpot;
        currentRight.transform.rotation = rightSideOrient;
        currentRight.transform.position = rightSideSpot;
        Debug.Log("finished enterphase");

      }
    }

    // void OnTriggerExit(Collider obj)
    // {Debug.Log("xrdTrigExit");
    //   if (sampleInPlace && obj.tag == "XRD")
    //   {

    //     Rigidbody rigid= obj.gameObject.GetComponent<Rigidbody>();
    //       sampleInPlace = false;
    //     rigid.isKinematic=true;
    //   }
    // }

    // void Split(GameObject sample)
    // {
    //   // splitting=true;
    //   //record position of top and bottomsampleHalf
    //   //bottomSampleLoc = sample.gameObject.GetComponent<Transform>().position+ new Vector3(deltTot,0,0);
    //   //topSampleLoc = sample.gameObject.GetComponent<Transform>().position+ new Vector3(-deltTot,0,0);
    //   sampleLoc=sample.gameObject.GetComponent<Transform>().position;
    //   samplerot=sample.gameObject.GetComponent<Transform>().rotation;
    //   sampleClone = sample.GetComponent<SampleFunctions>().detachedPair;
    //   //get rid of sample
    //   sample.transform.position += new Vector3(-100f, 0,0);
    //   //add new samples
    //   sampleClone.transform.position= sampleLoc;
    //   sampleClone.transform.rotation=samplerot;
    //   // sampleL  = sample.gameObject.GetComponent<Transform>().sampleLeft;
    //   // sampleR  = sample.gameObject.GetComponent<Transform>().sampleRight;

    //   //splitting=false;
    // }


}
