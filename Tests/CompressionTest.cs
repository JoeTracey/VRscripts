using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompressionTest: MonoBehaviour
{
  [SerializeField]
  OVRGrabber rightHand;
  [SerializeField]
  OVRGrabber leftHand;
  [SerializeField]
  GameObject topPiston;
  [SerializeField]
  GameObject bottomPiston;

  GameObject currentSample;
  GameObject bottomOfSample;
  GameObject topOfSample;
  GameObject sampleClone;

  Vector3 topPistonStart;
  Vector3 bottomPistonStart;

  Vector3 topSampleLoc;
  Vector3 bottomSampleLoc;
  Vector3 sampleLoc;
  Quaternion samplerot;
  GameObject page;
  
  [SerializeField]
  GameObject PrintedPosition;

  int maxShapeVal;

  string sampletype = "";
  string animtype = "";


  bool isHolding = false;
  bool hasTested = false;
  bool isTesting = false;
  bool splitting = false;

  float currentShapeVal = 0;
  float lastShapeVal = 0;

  float deltTot;

  List<GameObject> sampleParts = new List<GameObject>();


    // Start is called before the first frame update
    void OnStartUp()

    {

      Vector3 topPistonStart = topPiston.transform.position;
      Vector3 bottomPistonStart = bottomPiston.transform.position;
    }

    void OnTriggerEnter(Collider obj)

    {
      if (!isHolding && obj.tag == "Sample1")
      {
        Debug.Log(obj.tag);
        OVRGrabbable grabbableScript = obj.gameObject.GetComponent<OVRGrabbable>();
        rightHand.ForceRelease(grabbableScript);
        leftHand.ForceRelease(grabbableScript);
        Rigidbody rigid= obj.gameObject.GetComponent<Rigidbody>();
        rigid.isKinematic=true;
        isHolding = true;
        Transform trans= obj.gameObject.GetComponent<Transform>();

        trans.position =bottomPiston.transform.position  + new Vector3(.05f,.12f,0);
        trans.rotation =Quaternion.Euler(90,0,0);
        sampletype = "Sample1";
        currentSample = obj.gameObject;
      }
      if (!isHolding && obj.tag == "SampleCompression" && !splitting)
      {
        Debug.Log(obj.tag);
        OVRGrabbable grabbableScript = obj.gameObject.GetComponent<OVRGrabbable>();
        rightHand.ForceRelease(grabbableScript);
        leftHand.ForceRelease(grabbableScript);
        Rigidbody rigid= obj.gameObject.GetComponent<Rigidbody>();
        rigid.isKinematic=true;
        isHolding = true;
        Transform trans= obj.gameObject.GetComponent<Transform>();

        trans.position =bottomPiston.transform.position  + new Vector3(0,.12f,0);
        trans.rotation =Quaternion.Euler(90f,0,0);
        sampletype = "SampleCompression";
        animtype= "ductile";
        currentSample = obj.gameObject;
    maxShapeVal = currentSample.GetComponent<SampleFunctions>().shapeKeyDepth; 
    }
  }

    void OnTriggerExit(Collider obj)
    {
      if (isHolding && obj.tag == "Sample1")
      {
        Rigidbody rigid= obj.gameObject.GetComponent<Rigidbody>();
        rigid.isKinematic=true;
        Reset();
      }
      if (isHolding && obj.tag == "SampleCompression" && !splitting)
      {
        Rigidbody rigid= obj.gameObject.GetComponent<Rigidbody>();
        rigid.isKinematic=true;
        Reset();
      }
    }


    void RunCompressionTest()
    {
      Debug.Log("Compression Testing");
      if (isHolding && sampletype == "SampleCompression" && hasTested == false)
      {
        //GetSampleChildren(currentSample);
        hasTested = true;
        isTesting = true;
        deltTot = currentSample.GetComponent<SampleFunctions>().deltSize;
        //bottomPiston.gameObject.GetComponent<FixedJoint>().connectedBody=currentSample.GetComponent<Rigidbody>();

        //bottomPiston.gameObject.GetComponent<FixedJoint>().connectedBody=bottomPiston.GetComponent<Rigidbody>();

      }
    }

    void Update()
    {
      if (isTesting == true)
      {
        Debug.Log(currentShapeVal);
        currentShapeVal += Time.deltaTime*2f + currentShapeVal/200;
        if (currentShapeVal >= maxShapeVal)
        {
          isTesting = false;
          currentShapeVal=maxShapeVal;
          PrintGraph();}
        currentSample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, currentShapeVal);
        topPiston.transform.position -= new Vector3(0, deltTot*(currentShapeVal-lastShapeVal)/100f, 0);
        currentSample.transform.position -= new Vector3(0, deltTot*(currentShapeVal-lastShapeVal)/200f, 0);
        // topPiston.transform.position -= new Vector3(0, deltTot*(currentShapeVal-lastShapeVal)/1000f, 0);
        lastShapeVal = currentShapeVal;
      //  if (currentShapeVal == 100f)
      //  {
      //    split(currentSample);
      //  }
      }
    }
    // void split(GameObject sample)
    // {
    //   splitting=true;
    //   //record position of top and bottomsampleHalf
    //   //bottomSampleLoc = sample.gameObject.GetComponent<Transform>().position+ new Vector3(deltTot,0,0);
    //   //topSampleLoc = sample.gameObject.GetComponent<Transform>().position+ new Vector3(-deltTot,0,0);
    //   sampleLoc=sample.gameObject.GetComponent<Transform>().position;
    //   samplerot=sample.gameObject.GetComponent<Transform>().rotation;
    //   sampleClone = sample.GetComponent<SampleFunctions>().clone;
    //   //get rid of sample
    //   sample.transform.position += new Vector3(-100f, 0,0);
    //   //add new samples
    //   sampleClone.transform.position= sampleLoc;
    //   sampleClone.transform.rotation=samplerot;
    //   //splitting=false;
    // }
    public void Activate()
    {
      RunCompressionTest();
    }


    void GetSampleChildren(GameObject sample)
    {
      sampleParts.Clear();
      foreach(Transform child in sample.GetComponent<Transform>())
      {
        Debug.Log(child);
        Debug.Log(sampleParts);
        sampleParts.Add(child.gameObject);
      }
      bottomOfSample = sampleParts[1];
      topOfSample = sampleParts[0];
    }


    public void Reset()
    {
      if (isHolding && sampletype == "Sample1")
      {
      isHolding = false;
     }
     if (isHolding && sampletype == "SampleCompression")
     {
     isHolding = false;
         Debug.Log("Reset Was Called");
     splitting=false;
     topPiston.transform.position += new Vector3(0,deltTot*maxShapeVal/100, 0);
    //  bottomPiston.transform.position = bottomPistonStart;
     currentShapeVal=0f;
     lastShapeVal=0f;
     hasTested=false;
    //  currentSample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, 0);

    }
    }

    public void PrintGraph()
    {
      page = currentSample.GetComponent<SampleFunctions>().originalGraph;
      // page.GetComponent<Transform>().position =PrintedPosition;
      page.transform.GetComponent<Transform>().position =PrintedPosition.GetComponent<Transform>().position;
      page.transform.GetComponent<Transform>().rotation =PrintedPosition.GetComponent<Transform>().rotation;
      // page.transform.rotation =Quaternion.Euler(90,0,0);
    }


}
