using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CurrentMoney : MonoBehaviour
{
  [SerializeField]
  Bank bank;
  [SerializeField]
  GameObject display;
  public float curFunds;
    // Start is called before the first frame update
    void Start()
    {
        curFunds = bank.money;
        display.GetComponent<Text>().text=curFunds.ToString() + " $";
    }

    // Update is called once per frame
    void Update()
    {
      curFunds = bank.money;
      display.GetComponent<Text>().text=curFunds.ToString() + " $";
    }
}
