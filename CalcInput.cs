using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CalcInput : MonoBehaviour

{

  [SerializeField]
  GameObject userDisplay;
  [SerializeField]
  GameObject gameDisplay;
  [SerializeField]
  GameObject taskManager;
    [SerializeField]
  string input;
  [SerializeField]
  public AudioSource soundSource;
    // Start is called before the first frame update
    public void Input()
    {

      userDisplay.GetComponent<Text>().text += input;
      soundSource.Play();

    }

    public void Send()
    {
      string between = userDisplay.GetComponent<Text>().text;
      int decimals= 0;
      string zero = "0";
      if (between[0]=='.')
      {
        between = String.Concat(zero, between);
      }
      foreach (char i in between)
      {
        if (i =='.')
        decimals += 1;
      }
      if (decimals>=2)
      {
        between = "0.0";
      }
      float guess = float.Parse(between);
      taskManager.GetComponent<BasicTask>().Check(guess);
      userDisplay.GetComponent<Text>().text = "";
      soundSource.Play();


    }

    public void Calculate()
        {

          string guess = userDisplay.GetComponent<Text>().text;
          taskManager.GetComponent<CalculatorManager>().Check(guess);
          userDisplay.GetComponent<Text>().text = "";

        }
    public void Clear()
    {
    soundSource.Play();
      if (userDisplay.GetComponent<Text>().text == "")
      {
        gameDisplay.GetComponent<Text>().text = "";
      }
      else
      {
      //userDisplay.GetComponent<Text>().text = "";
      taskManager.GetComponent<CalculatorManager>().val1=0;
      taskManager.GetComponent<CalculatorManager>().val2=1;
    }

    }
}
