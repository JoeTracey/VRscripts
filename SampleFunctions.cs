using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleFunctions : MonoBehaviour
{
    [SerializeField]
    GameObject self;
  //  [SerializeField]
    Vector3 sampleSpot;
    [SerializeField]
    public string mass;
    [SerializeField]
    public float resistance;
    [SerializeField]
    public float deltSize;
    [SerializeField]
    public float hotDeltSize;
    [SerializeField]
    public float coldDeltSize;
    [SerializeField]
    public GameObject topPart;
    [SerializeField]
    public GameObject bottomPart;
    [SerializeField]
    public GameObject clone;
    [SerializeField]
    public GameObject cloneHot;
    [SerializeField]
    public GameObject cloneCold;
    [SerializeField]
    public int sampleTempIndex;
    [SerializeField]
    public int shapeKeyIndex;
    [SerializeField]
    public int hotShapeKeyIndex;
    [SerializeField]
    public int coldShapeKeyIndex;
    [SerializeField]
    public int shapeKeyDepth;
    [SerializeField]
    public int shapeKeyDepthHot;
    [SerializeField]
    public int shapeKeyDepthCold;
    [SerializeField]
    public SampleFunctions detachedPair;
    [SerializeField]
    public SampleFunctions sampleLeft;
    [SerializeField]
    public SampleFunctions sampleRight;
    [SerializeField]
    public SampleFunctions sampleLeftCold;
    [SerializeField]
    public SampleFunctions sampleRightCold;
    [SerializeField]
    public SampleFunctions sampleLeftHot;
    [SerializeField]
    public SampleFunctions sampleRightHot;
     //= self.transform.position;
    // Start is called before the first frame update
    [SerializeField]
    public int breakForce;
    [SerializeField]
    public GameObject originalGraph;
    [SerializeField]
    public GameObject hotGraph;
    [SerializeField]
    public GameObject coldGraph;
    public int sampletype;
    void Start()
    {
      sampleSpot = self.GetComponent<Transform>().position;
    }

    public void Reset()
    {
        self.transform.position = sampleSpot;
    }
}
