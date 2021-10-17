using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ButtonForManual : MonoBehaviour
{
  [SerializeField]
  GameObject oper;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TutorialButton()
    {
      oper.GetComponent<LabManual>().TutorialButton();
    }
    public void ProgressButton()
    {
      oper.GetComponent<LabManual>().ProgressButton();
    }
    public void Button1()
    {
      oper.GetComponent<LabManual>().Button1();

    }
    public void Button2()
    {

        oper.GetComponent<LabManual>().Button2();
    }
    public void Button3()
        {

            oper.GetComponent<LabManual>().Button3();
        }
    public void NextPage()
    {

        oper.GetComponent<LabManual>().NextPage();
    }

    public void LastPage()
    {
      oper.GetComponent<LabManual>().LastPage();
    }

    public void Backup()
    {
      oper.GetComponent<LabManual>().Backup();
    }
}
