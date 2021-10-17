using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObject : MonoBehaviour
{
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

  GameObject currentSample;
  GameObject bottomOfSample;
  GameObject topOfSample;
  GameObject sampleClone;
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
  int maxShapeVal;
  int heatVal;
  int sampleTempIndex;
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

  GameObject page;
  
  [SerializeField]
  GameObject PrintedPosition;
  List<GameObject> sampleParts = new List<GameObject>();


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
      if (!isHolding && obj.tag == "SampleTensile" && !splitting)
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
        isHolding = true;
        Transform trans= obj.gameObject.GetComponent<Transform>();

        trans.position = lowleftTooth.transform.position  + new Vector3(.0f,.12f,-0.034f);
        trans.rotation =Quaternion.Euler(0,0,0);
        sampletype = "SampleTensile";
        animtype= "ductile";
        currentSample = obj.gameObject;
        sampleTempIndex = currentSample.GetComponent<SampleFunctions>().sampleTempIndex;
        if (sampleTempIndex==0) //Regular
          {
        shapeKeyIndex = currentSample.GetComponent<SampleFunctions>().shapeKeyIndex;
        maxShapeVal = currentSample.GetComponent<SampleFunctions>().shapeKeyDepth;
        deltTot = currentSample.GetComponent<SampleFunctions>().deltSize;

          }
        if (sampleTempIndex==1) //Hot
          {
        shapeKeyIndex = currentSample.GetComponent<SampleFunctions>().hotShapeKeyIndex;
        maxShapeVal = currentSample.GetComponent<SampleFunctions>().shapeKeyDepthHot;
        deltTot = currentSample.GetComponent<SampleFunctions>().hotDeltSize;

          }
        if (sampleTempIndex==3) //Cold
          {
        shapeKeyIndex = currentSample.GetComponent<SampleFunctions>().coldShapeKeyIndex;
        maxShapeVal = currentSample.GetComponent<SampleFunctions>().shapeKeyDepthCold;
        deltTot = currentSample.GetComponent<SampleFunctions>().coldDeltSize;

          }
        Debug.Log(shapeKeyIndex);
        Debug.Log(maxShapeVal);

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
      if (isHolding && obj.tag == "SampleTensile" && !splitting)
      {
        Rigidbody rigid= obj.gameObject.GetComponent<Rigidbody>();
        rigid.isKinematic=true;
        Reset();
      }
    }


    void TensileTest()
    {
      Debug.Log("Tensile Testing");
      if (isHolding && sampletype == "SampleTensile" && hasTested == false)
      {
        GetSampleChildren(currentSample);
        hasTested = true;
        isTesting = true;
        // maxShapeVal = currentSample.GetComponent<SampleFunctions>().shapeKeyDepth;
        // deltTot = currentSample.GetComponent<SampleFunctions>().deltSize;
        //topClamp.gameObject.GetComponent<FixedJoint>().connectedBody=currentSample.GetComponent<Rigidbody>();

        //topClamp.gameObject.GetComponent<FixedJoint>().connectedBody=topClamp.GetComponent<Rigidbody>();

      }
    }

    void Update()
    {
      if (isTesting == true)
      {
        if (currentShapeVal <= maxShapeVal){
        Debug.Log(currentShapeVal);
        currentShapeVal += Time.deltaTime*2f + currentShapeVal/200;
        bottomOfSample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(shapeKeyIndex, currentShapeVal);
        topOfSample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(shapeKeyIndex, currentShapeVal);
        bottomClamp.transform.position -= new Vector3(0,deltTot*(currentShapeVal-lastShapeVal)/100f, 0);
        topClamp.transform.position += new Vector3(0,deltTot*(currentShapeVal-lastShapeVal)/100f, 0);
        Debug.Log("moving clamp");
        lastShapeVal = currentShapeVal;}
        if (currentShapeVal >= maxShapeVal)
        {
          isTesting = false;
          split(currentSample);
          PrintGraph();
          // currentShapeVal=100f;
          }
        // bottomOfSample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(shapeKeyIndex, maxShapeVal);
        // topOfSample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(shapeKeyIndex, maxShapeVal);
        // bottomClamp.transform.position -= new Vector3(0,deltTot*(currentShapeVal-lastShapeVal)/100f, 0);
        // topClamp.transform.position += new Vector3(0,deltTot*(currentShapeVal-lastShapeVal)/100f, 0);
        // Debug.Log("moving clamp");
        // lastShapeVal = currentShapeVal;
        // if (currentShapeVal == 100f)
        // {
        //   split(currentSample);
        //   PrintGraph();
        // }
      }
    }
    void split(GameObject sample)
    {
      splitting=true;
      //record position of top and bottomsampleHalf
      //bottomSampleLoc = sample.gameObject.GetComponent<Transform>().position+ new Vector3(deltTot,0,0);
      //topSampleLoc = sample.gameObject.GetComponent<Transform>().position+ new Vector3(-deltTot,0,0);
      sampleLoc=sample.gameObject.GetComponent<Transform>().position;
      samplerot=sample.gameObject.GetComponent<Transform>().rotation;
      if (sampleTempIndex == 0)
      {
      sampleClone = sample.GetComponent<SampleFunctions>().clone;
      }
      if (sampleTempIndex == 1)
      {
      sampleClone = sample.GetComponent<SampleFunctions>().cloneHot;
      }
      if (sampleTempIndex == 3)
      {
      sampleClone = sample.GetComponent<SampleFunctions>().cloneCold;
      }
      //get rid of sample
      sample.transform.position += new Vector3(-100f, 0,0);
      //add new samples
      sampleClone.transform.position= sampleLoc;
      sampleClone.transform.rotation=samplerot;
      bottomOfSample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(shapeKeyIndex, 0);
      topOfSample.gameObject.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(shapeKeyIndex, 0);
      //splitting=false;
    }
    public void Activate()
    {
      TensileTest();
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
      Debug.Log("Called Reset");
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

        public void PrintGraph()
    {
      heatVal = currentSample.GetComponent<SampleFunctions>().sampleTempIndex;
      if (heatVal == 0){page = currentSample.GetComponent<SampleFunctions>().originalGraph;}
      if (heatVal == 1){page = currentSample.GetComponent<SampleFunctions>().hotGraph;}
      if (heatVal == 3){page = currentSample.GetComponent<SampleFunctions>().coldGraph;}
      
      // page.GetComponent<Transform>().position =PrintedPosition;
      page.transform.GetComponent<Transform>().position =PrintedPosition.GetComponent<Transform>().position;
      page.transform.GetComponent<Transform>().rotation =PrintedPosition.GetComponent<Transform>().rotation;
      // page.transform.rotation =Quaternion.Euler(90,0,0);
    }


}
