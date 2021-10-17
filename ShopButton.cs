using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField]
    ShopManager shop;
    [SerializeField]
    Text display;

    void Start()
    {

    }
    public void button1()
    {
      display.text=shop.Buy1();
    }

    public void button2()
    {
      display.text=shop.Buy2();
    }


    public void button3()
    {

    }

    public void button4()
    {

    }


}
