using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooler : MonoBehaviour
{

    // Start is called before the first frame update
    void OnTriggerEnter(Collider obj)
    {
        // obj.GetComponent<SampleFunctions>().sampleTempIndex = obj.GetComponent<SampleFunctions>().coldShapeKeyIndex;
        obj.GetComponent<SampleFunctions>().sampleTempIndex = 3;
        // obj.GetComponent<SampleFunctions>().deltSize = obj.GetComponent<SampleFunctions>().coldDeltSize;
        Debug.Log("Cooled Sample");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
