using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharpySwingingObject : MonoBehaviour
{
    [SerializeField]
    GameObject self;
  //  [SerializeField]
    [SerializeField]
    FixedJoint controlJoint;
    [SerializeField]
    FixedJoint testJoint;
    [SerializeField]
    Rigidbody controlMarker;
    [SerializeField]
    Rigidbody testMarker;
    Rigidbody marker;
    float speed;

    
    Vector3 sampleSpot;
    Quaternion sampleOrient;

    Vector3 testMarkerSpot;
    Quaternion testMarkerOrient;
    Vector3 controlMarkerSpot;
    Quaternion controlMarkerOrient;
    bool recording = false;
    FixedJoint currentjoint;


     //= self.transform.position;
    // Start is called before the first frame update
    void Start()
    {
      sampleSpot = self.GetComponent<Transform>().position;
      sampleOrient = self.GetComponent<Transform>().rotation;
      testMarkerSpot = testMarker.GetComponent<Transform>().position;
      testMarkerOrient = testMarker.GetComponent<Transform>().rotation;
      controlMarkerSpot = controlMarker.GetComponent<Transform>().position;
      controlMarkerOrient = controlMarker.GetComponent<Transform>().rotation;

      sampleSpot+= new Vector3(0, 5 , 0);
      testMarkerSpot+= new Vector3(0, 5 , 0);
      controlMarkerSpot+= new Vector3(0, 5 , 0);

    }
    void Update()
    {
      if (recording)
      {
        speed = self.GetComponent<Rigidbody>().velocity.magnitude;
        if (speed < 1)
        {

            HitPeak(currentjoint);
            recording = false;
        }
      }
    }
    public void ResetAll()
    {
      Debug.Log("Hit Reset All-Charpy");
        Debug.Log(self.GetComponent<Rigidbody>().velocity.magnitude );
      if (self.GetComponent<Rigidbody>().velocity.magnitude < 1)
      {
        testMarker.transform.position = testMarkerSpot;
        testMarker.transform.rotation = testMarkerOrient;
        controlMarker.transform.position = controlMarkerSpot;
        controlMarker.transform.rotation = controlMarkerOrient;
        testMarker.isKinematic = false;
        controlMarker.isKinematic = false;


        if (self.GetComponent<FixedJoint>() == null)
        {
        controlJoint = self.AddComponent<FixedJoint>();
        testJoint = self.AddComponent<FixedJoint>();
        controlJoint.connectedBody  = controlMarker;
        testJoint.connectedBody  = testMarker;
        }
        else
        {
          Debug.Log(self.GetComponent<FixedJoint>());
        }
      }
    }
    // Update is called once per frame
    public void Reset()
    {
      Debug.Log("Hit Reset");
        Debug.Log(self.GetComponent<Rigidbody>().velocity.magnitude );
    if (self.GetComponent<Rigidbody>().velocity.magnitude < 0.115)
      {
        Freeze();
        self.transform.position = sampleSpot;
        self.transform.rotation = sampleOrient;
      }
    }

    public void Freeze()
    { Debug.Log("Called Freeze");
        self.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void HitPeak(FixedJoint joint)
    {
        // self.GetComponent<Rigidbody>().isKinematic = true;
        joint.breakForce = 0;
        Debug.Log("Hit Peak");
        Debug.Log(marker);
        marker.isKinematic = true;
    }


    public void Test()
    {
      marker = testMarker;
      Release(testJoint);
    }

    public void Calibrate()
    {
    marker = controlMarker;
    Release(controlJoint);
    }

    public void Release(FixedJoint joint)
    {
        self.GetComponent<Rigidbody>().isKinematic = false;
        Debug.Log("Triggered");
        Debug.Log(sampleSpot);
        Debug.Log(sampleOrient);
        StartCoroutine(Wait(joint));
    }

    public void ReadyToRecord(FixedJoint joint)
    {

      currentjoint = joint;
        Debug.Log("Ready to Record");
      recording = true;

    }
    public void Brake(bool on)
    {
      if (on)
      {
        Debug.Log("Braking");
        self.GetComponent<Rigidbody>().drag = 5;
      }
      else
      {
        Debug.Log("Braking off");
        self.GetComponent<Rigidbody>().drag = 0;

      }
    }
    IEnumerator Wait(FixedJoint joint)
    {
      yield return new WaitForSecondsRealtime(1);
      ReadyToRecord(joint);
    }
    IEnumerator Wait2()
    {
      yield return 0;
    }

}
