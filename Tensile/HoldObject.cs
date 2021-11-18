using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to hold, split, and conduct tensile testing, as well as print out sample results 

public class HoldObject : MonoBehaviour
{
  //Allow clamp parts to be specified through serialization
  [SerializeField]
  GameObject lowleftTooth;
  [SerializeField]
  GameObject lowrightTooth;
  [SerializeField]
  GameObject highleftTooth;
  [SerializeField]
  GameObject highrightTooth;

  [SerializeField]
  OVRGrabber rightHand;
  [SerializeField]
  OVRGrabber leftHand;
  [SerializeField]
  GameObject bottomClamp;
  [SerializeField]
  GameObject topClamp;
  
  [SerializeField]
  GameObject PrintedPosition;

  //Create objects to be referenced
  GameObject currentSample;
  GameObject bottomOfSample;
  GameObject topOfSample;
  GameObject sampleClone;
  GameObject page;
  Vector3 llstart;
  Vector3 lrstart;
  Vector3 hlstart;
  Vector3 hrstart;

  Vector3 topClampStart;
  Vector3 bottomClampStart;

  Vector3 topSampleLoc;
  Vector3 bottomSampleLoc;
  Vector3 sampleLoc;
  Quaternion samplerot;
  
  List<GameObject> sampleParts = new List<GameObject>();
  
  int maxShapeVal;
  int heatVal;
  int sampleTempIndex;

  //Setting initial values
  int shapeKeyIndex = 0;
  string sampletype = "";
  string animtype = "";


  bool isHolding = false;
  bool hasTested = false;
  bool isTesting = false;
  bool splitting = false;

  float currentShapeVal = 0;
  float lastShapeVal = 0;

  float deltTot;




    // Start is called before the first frame update
    void OnStartUp()

    {
      llstart = lowleftTooth.transform.position;
      lrstart = lowrightTooth.transform.position;
      hlstart = highleftTooth.transform.position;
      hrstart = highrightTooth.transform.position;

      Vector3 topClampStart = topClamp.transform.position;
      Vector3 bottomClampStart = bottomClamp.transform.position;
    }

    // Call when sample is being held and enters the collider
    void OnTriggerEnter(Collider obj)

    {
      if (!isHolding && obj.tag == "Sample1") //Handle basic test samples
      {
        Debug.Log(obj.tag);
        OVRGrabbable grabbableScript = obj.gameObject.GetComponent<OVRGrabbable>();
        rightHand.ForceRelease(grabbableScript);
        leftHand.ForceRelease(grabbableScript);
        Rigidbody rigid= obj.gameObject.GetComponent<Rigidbody>();
        rigid.isKinematic=true;
        lowleftTooth.transform.position += new Vector3(.03f,0,0);
        lowrightTooth.transform.position -= new Vector3(.03f,0,0);
        highleftTooth.transform.position += new Vector3(.03f,0,0);
        highrightTooth.transform.position -= new Vector3(.03f,0,0);
        isHolding = true;
        Transform trans= obj.gameObject.GetComponent<Transform>();

        trans.position = lowleftTooth.transform.position  + new Vector3(.5f,.12f,0);
        trans.rotation =Quaternion.Euler(90,0,0);
        sampletype = "Sample1";
        currentSample = obj.gameObject;
      }
      if (!isHolding && obj.tag == "SampleTensile" && !splitting) //Handle dog bone tensile samples
      {
        Debug.Log(obj.tag);
        OVRGrabbable grabbableScript = obj.gameObject.GetComponent<OVRGrabbable>();
        rightHand.ForceRelease(grabbableScript);
        leftHand.ForceRelease(grabbableScript);
        Rigidbody rigid= obj.gameObject.GetComponent<Rigidbody>();
        rigid.isKinematic=true;
        lowleftTooth.transform.position -= new Vector3(0,0,.0485f);
        lowrightTooth.transform.position += new Vector3(0,0,.047f);
        highleftTooth.transform.position -= new Vector3(0,0,.0495f);
        highrightTooth.transform.position += new Vector3(0,0,.047f);
        isHolding = true; //Flag to allow testing station to start
        Transform trans= obj.gameObject.GetComponent<Transform>();

        trans.position = lowleftTooth.transform.position  + new Vector3(.0f,.12f,-0.034f);
        trans.rotation =Quaternion.Euler(0,0,0);
        sampletype = "SampleTensile";
        animtype= "ductile";
        currentSample = obj.gameObject;
        sampleTempIndex = currentSample.GetComponent<SampleFunctions>().sampleTempIndex;
        if (sampleTempIndex==0) //Regular sample flag
          {
        shapeKeyIndex = currentSample.GetComponent<SampleFunctions>().shapeKeyIndex;
        maxShapeVal = currentSample.GetComponent<SampleFunctions>().shapeKeyDepth;
        deltTot = currentSample.GetComponent<SampleFunctions>().deltSize;

          }
        if (sampleTempIndex==1) //Hot sample flag
          {
        shapeKeyIndex = currentSample.GetComponent<SampleFunctions>().hotShapeKeyIndex;
        maxShapeVal = currentSample.GetComponent<SampleFunctions>().shapeKeyDepthHot;
        deltTot = currentSample.GetComponent<SampleFunctions>().hotDeltSize;

          }
        if (sampleTempIndex==3) //Cold sample flag
          {
        shapeKeyIndex = currentSample.GetComponent<SampleFunctions>().coldShapeKeyIndex;
        maxShapeVal = currentSample.GetComponent<SampleFunctions>().shapeKeyDepthCold;
        deltTot = currentSample.GetComponent<SampleFunctions>().coldDeltSize;

          }
        Debug.Log(shapeKeyIndex);
        Debug.Log(maxShapeVal);

      }
    }

    void OnTriggerExit(Collider obj) // call Reset() and enable gravity if sample is removed by user
    {
      if (isHolding && obj.tag == "Sample1" || isHolding && obj.tag == "SampleTensile" && !splitting )
      {
        Rigidbody rigid= obj.gameObject.GetComponent<Rigidbody>();
        rigid.isKinematic=true;
        Reset();
      }
    }


    void TensileTest()
    {
      Debug.Log("Tensile Testing");
      if (isHolding && sampletype == "SampleTensile" && hasTested == false) //only activate if test is not started yet but conditions are met
      {
        GetSampleChildren(currentSample);
        hasTested = true; //prevents TensileTest() from being called twice
        isTesting = true; //ensures Update() continues test
      }
    }

    void Update()
    {
      if (isTesting == true) //update deformation for active test
      {
        if (currentShapeVal <= maxShapeVal){ //only call if maxShapeVal is not met yet
        Debug.Log(currentShapeVal);
        currentShapeVal += Time.deltaTime*2f + currentShapeVal/200; //update based on time since last call
        //set shapekey
        bottomOfSample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(shapeKeyIndex, currentShapeVal);
        topOfSample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(shapeKeyIndex, currentShapeVal);
        //move clamp to move same distance as deformation
        bottomClamp.transform.position -= new Vector3(0,deltTot*(currentShapeVal-lastShapeVal)/100f, 0);
        topClamp.transform.position += new Vector3(0,deltTot*(currentShapeVal-lastShapeVal)/100f, 0);
        Debug.Log("moving clamp");
        lastShapeVal = currentShapeVal;} //remember last shapekey value for proper delta next call

        if (currentShapeVal >= maxShapeVal) //turn off testing station if maximum deformation is reached
        {
          isTesting = false; //prevents further deformation
          split(currentSample); //replace sample with two broken pieces
          PrintGraph(); //print results for user to compare
          }
      }
    }
    void split(GameObject sample)
    {
      splitting=true;
      //store sample transformations
      sampleLoc=sample.gameObject.GetComponent<Transform>().position;
      samplerot=sample.gameObject.GetComponent<Transform>().rotation;
      if (sampleTempIndex == 0) //replace sample with split untreated clone
      {
      sampleClone = sample.GetComponent<SampleFunctions>().clone;
      }
      if (sampleTempIndex == 1) //replace sample with hot split clone
      {
      sampleClone = sample.GetComponent<SampleFunctions>().cloneHot;
      }
      if (sampleTempIndex == 3) //replace sample with cold split clone
      {
      sampleClone = sample.GetComponent<SampleFunctions>().cloneCold;
      }
      //get rid of sample
      sample.transform.position += new Vector3(-100f, 0,0);
      //add clone at proper orientation, which contains proper shapekeys for deformation
      sampleClone.transform.position= sampleLoc;
      sampleClone.transform.rotation=samplerot;
      //ensure sample is set to 0 shapekey
      bottomOfSample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(shapeKeyIndex, 0);
      topOfSample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(shapeKeyIndex, 0);
      //splitting=false;
    }

    //Activate function to be called by physical start button
    public void Activate()
    {
      //Attempt to start testing station
      TensileTest();
    }


    void GetSampleChildren(GameObject sample) //obtain top and bottom portions of sample to treat seperately
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


    public void Reset() //Reset testing station, linked to reset button on machine
    {
      Debug.Log("Called Reset");

      //move teeth on clamps back to closed position
      if (isHolding && sampletype == "Sample1")
      {
      isHolding = false;
      lowleftTooth.transform.position -= new Vector3(.03f,0,0);
      lowrightTooth.transform.position += new Vector3(.03f,0,0);
      highleftTooth.transform.position -= new Vector3(.03f,0,0);
      highrightTooth.transform.position += new Vector3(.03f,0,0);
     }
     if (isHolding && sampletype == "SampleTensile")
      {
      isHolding = false;
      lowleftTooth.transform.position += new Vector3(0,0,.0485f);
      lowrightTooth.transform.position -= new Vector3(0,0,.047f);
      highleftTooth.transform.position += new Vector3(0,0,.0495f);
      highrightTooth.transform.position -= new Vector3(0,0,.047f);

      //adjust clamps along y (height) axis if test was completed
      if (splitting)
        {
            Debug.Log("Reset Was Called");
        splitting=false;
        bottomClamp.transform.position += new Vector3(0,deltTot*maxShapeVal/100, 0);
        topClamp.transform.position -= new Vector3(0,deltTot*maxShapeVal/100, 0);
        currentShapeVal=0f;
        lastShapeVal=0f;
        hasTested=false;
        deltTot = 0;
        }
      }
    }

    public void PrintGraph() //print out graph linked to sample that was just tested
    {
      heatVal = currentSample.GetComponent<SampleFunctions>().sampleTempIndex;
      //obtain correct graph
      if (heatVal == 0){page = currentSample.GetComponent<SampleFunctions>().originalGraph;}
      if (heatVal == 1){page = currentSample.GetComponent<SampleFunctions>().hotGraph;}
      if (heatVal == 3){page = currentSample.GetComponent<SampleFunctions>().coldGraph;}
      //drop page into machines printer
      page.transform.GetComponent<Transform>().position =PrintedPosition.GetComponent<Transform>().position;
      page.transform.GetComponent<Transform>().rotation =PrintedPosition.GetComponent<Transform>().rotation;
    }


}
