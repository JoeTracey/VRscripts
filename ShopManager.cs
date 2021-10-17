using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
  [SerializeField]
  Bank bank;

  //button1 objects
  [SerializeField]
  Vector3 scaleLoc;
  [SerializeField]
  GameObject scaleObject;
  [SerializeField]
  Vector3 conductLoc;
  [SerializeField]
  GameObject conductTester;
  [SerializeField]
  Vector3 tensileLoc;
  [SerializeField]
  GameObject tensileTester;
  [SerializeField]
  Vector3 compressionLoc;
  [SerializeField]
  GameObject compressionTester;
  [SerializeField]
  Vector3 CVNLoc;
  [SerializeField]
  GameObject CVNTester;
  [SerializeField]
  Vector3 XRDLoc;
  [SerializeField]
  GameObject XRDTester;
  [SerializeField]
  Vector3 rulerLoc;
  [SerializeField]
  GameObject rulerBody;
  [SerializeField]
  Vector3 FurnLoc;
  [SerializeField]
  GameObject FurnBody;
  [SerializeField]
  Vector3 LiqNLoc;
  [SerializeField]
  GameObject LiqNBody;

  [SerializeField]
  BasicTask taskManager;

  //button2 objects
  [SerializeField]
  GameObject mohoganyRuler;
  [SerializeField]
  GameObject nicerScale;

  int totalSpent = 0;

  //Lab Esentials
  int b1Idx = 0;
  List<GameObject> button1Objects = new List<GameObject>();
  List<string> button1Names = new List<string>();
  List<float> button1Prices = new List<float>();
  List<Vector3> button1Locs = new List<Vector3>();

  //Astetics
  int b2Idx = 0;
  List<GameObject> button2Objects = new List<GameObject>();
  List<string> button2Names = new List<string>();
  List<float> button2Prices = new List<float>();
  List<Vector3> button2Locs = new List<Vector3>();


    // Start is called before the first frame update
    void Start()
    {
        button1Objects.Add(scaleObject);
        button1Objects.Add(conductTester);
        button1Objects.Add(tensileTester);
        button1Objects.Add(FurnBody);
        button1Objects.Add(LiqNBody);
        button1Objects.Add(compressionTester);
        button1Objects.Add(CVNTester);
        button1Objects.Add(XRDTester);
        button1Objects.Add(XRDTester);

        button1Names.Add("New Scale");
        button1Names.Add("New Conductivity Tester");
        button1Names.Add("New Tensile Tester");
        button1Names.Add("New Furnace");
        button1Names.Add("New Liquid Nitrogen");
        button1Names.Add("New Compression Tester");
        button1Names.Add("New Charpy V-notch Tester");
        button1Names.Add("New XRD Test Station");
        button1Names.Add("SOLD OUT");

        button1Prices.Add(20f);
        button1Prices.Add(150f);
        button1Prices.Add(500f);
        button1Prices.Add(1000f);
        button1Prices.Add(2000f);
        button1Prices.Add(5000f);
        button1Prices.Add(14000f);
        button1Prices.Add(50000f);
        button1Prices.Add(0f);

        button1Locs.Add(scaleLoc);
        button1Locs.Add(conductLoc);
        button1Locs.Add(tensileLoc);
        button1Locs.Add(FurnLoc);
        button1Locs.Add(LiqNLoc);
        button1Locs.Add(compressionLoc);
        button1Locs.Add(CVNLoc);
        button1Locs.Add(XRDLoc);
        button1Locs.Add(XRDLoc);


        button2Objects.Add(mohoganyRuler);
        button2Objects.Add(nicerScale);

        button2Names.Add("A Nicer, mahogany Ruler");
        button2Names.Add("A fancier scale, with 0.1g precesion");

        button2Prices.Add(10f);
        button2Prices.Add(20f);

        button2Locs.Add(rulerLoc);
        button2Locs.Add(scaleLoc);

    }

    public string Buy1()
    {
      if (PriceCheck(button1Prices[b1Idx]))
      {
        bank.money -= button1Prices[b1Idx];
        button1Objects[b1Idx].transform.localPosition = button1Locs[b1Idx];
        b1Idx+=1;
        taskManager.Check(4321f);
        taskManager.Check(3.14f);
      }
    // if (b1Idx == 2)
    // {
    //   ClearTask();
    // }
      return( button1Names[b1Idx].ToString()+": "+ button1Prices[b1Idx].ToString("0.0")+" $");
    }

    public string Buy2()
    {
      if (PriceCheck(button2Prices[b2Idx]))
      {
        bank.money -= button2Prices[b2Idx];
        button2Objects[b2Idx].transform.position = button2Locs[b2Idx];
        b2Idx+=1;
      }
      return( button2Names[b2Idx].ToString()+": "+ button2Prices[b2Idx].ToString("0.0")+" $");
    }

    // void ClearTask()
    // {
    //   taskManager.Check(4321f);
    // }
    bool PriceCheck(float price)
    {
      if (bank.money >= price)
      {
        return true;
      }
        return false;

    }

    void Update()
    {

    }
}
