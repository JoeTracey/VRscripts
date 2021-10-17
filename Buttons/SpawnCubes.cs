using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cubePrefab;

    public void Cube()

    {
      Instantiate(cubePrefab);
    }
}
