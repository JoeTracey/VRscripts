using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskButton : MonoBehaviour
{
    // [SerializeField]
    // ShopManager shop;
    // [SerializeField]
    // Text display;
      [SerializeField]
      GameObject userDisplay;
      [SerializeField]
      GameObject gameDisplay;
      [SerializeField]
      GameObject unitDisplay;

    [SerializeField]
    BasicTask taskManager;

    void Start()
    {

    }
    public void button1()
    {
      taskManager.SetMO();

    }

    public void button2()
    {
      Debug.Log('2');
      taskManager.SetCondTask();


    }


    public void button3()
    {
      Debug.Log('3');
      taskManager.SetTensTask();
    }

    public void button4()
    {
      Debug.Log('4');
      taskManager.SetCompTask();

    }

    public void button5()
    {
      Debug.Log('5');
      taskManager.SetCvnTask();

    }

    public void button6()
    {
      Debug.Log('6');
      taskManager.SetXRDTask();

    }

    public void skipquestion()
    {
      taskManager.SkipQuestion();
    }


}
