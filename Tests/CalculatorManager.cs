using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CalculatorManager : MonoBehaviour
{
  [SerializeField]
  GameObject userDisplay;
  [SerializeField]
  GameObject gameDisplay;
  List<float> values = new List<float>();
  public float val1=0;
  public float val2=1;
    float last=0;
  int dec = 0;
  int dnum = 0;
  char oper = '*';
  int oop = 0;
      // Start is called before the first frame update
      void Start()
      {

          gameDisplay.GetComponent<Text>().text = "";
          userDisplay.GetComponent<Text>().text = "";

      }

      // Update is called once per frame
      public void Check(string guess)
      {

          Debug.Log("Running Equation");
        foreach (char c in guess)
        {
          Debug.Log(guess);
          Debug.Log(c);
          if (c=='+')
            {
              Debug.Log("plus");
              Execute(oper);
              oper='+';
              oop=1;


            }
            else if (c == '-')
            {
              Debug.Log("minus");
              Execute(oper);
              oper='-';
              oop=1;

            }
            else if (c == '*')
            {
              Debug.Log("times");
              Execute(oper);
              oper='*';
              oop=1;

            }
            else if (c == '/')
            {
              Debug.Log("div");
              Execute(oper);
              oper='/';
              oop=1;

            }
            else if (c == '^')
            {
              Debug.Log("to the power");
              Execute(oper);
              oper='^';
              oop=1;

            }
            else if (c == 's')
            {
              Debug.Log("sqrt");
              Execute(oper);
              oper='s';
              oop=1;

            }
            else if (c == '.')
            {
              dec=1;

            }
            else if (c == '@')
            {
              Debug.Log("@-last");
              val1=last;
              Execute(oper);
              oop=1;

            }
          else

          {
            if (oop==0)
            {
              val2=1;
              val1=0;
            }
            Debug.Log("Else, hitting number");
            Debug.Log(val1);
            int o = (int)char.GetNumericValue(c);
            Debug.Log(c);
            Debug.Log(o);
            oop = 1;
            if (dec==0)
            {
              val1= o+(val1*10f) ;
            }
            else
            {Debug.Log('_');
              Debug.Log(val1);
              val1= val1 +o*(1f/(10f*dec)) ;
              Debug.Log(val1);
              dec+=1;
            }
            Debug.Log(val1);
          }
        }
        Execute(oper);
        Debug.Log("Finishing operation");
        gameDisplay.GetComponent<Text>().text = val2.ToString("0.00");
        last = val2;
        //val2=1;
        val1=1;
        oper='*';
        oop=0;
        }
        void Execute(char c)
        {
          dec=0;
          Debug.Log("Executing");
          Debug.Log(val1);
          if (c== '+')
          {Debug.Log("EX-plus");
          val2= val1 + val2;
          val1=0;}
          else if (c== '*')
          {Debug.Log("EX-times");
          val2= val1 * val2;
          val1=0;}
          else if (c== '-')
          {val2= val2 - val1;
          val1=0;}
          else if (c== '/')
          {val2= val2 / val1;
          val1=0;}
          else if (c== '^')
          {val2= Mathf.Pow(val2,val1);
          val1=0;}
          else if (c== 's')
          {val2= Mathf.Sqrt(val1);
          val1=0;}
        }



}
