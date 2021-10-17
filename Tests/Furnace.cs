using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MonoBehaviour
{

    // Start is called before the first frame update
    void OnTriggerEnter(Collider obj)
    {
        // obj.GetComponent<SampleFunctions>().sampleTempIndex = obj.GetComponent<SampleFunctions>().hotShapeKeyIndex;
        obj.GetComponent<SampleFunctions>().sampleTempIndex = 1;
        // obj.GetComponent<SampleFunctions>().deltSize = obj.GetComponent<SampleFunctions>().hotDeltSize;
        Debug.Log("Heated Sample");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
