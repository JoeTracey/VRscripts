using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    Vector3 destination;
   [SerializeField]
    Quaternion destRot;
    public GameObject player;
    [SerializeField]
    BoxCollider obstructingWall;
    public void Port()

    {
      //player.transform.position = new Vector3(52f,70.0f,42.0f);
      obstructingWall.isTrigger = true;
      player.transform.rotation = destRot;
      player.transform.position = destination;
      //obstructingWall.isTrigger = false;

    }
}
