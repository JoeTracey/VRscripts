using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Input;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
  [SerializeField]
  public Canvas pauseMenu;
  int paused= 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Start))
        {
          if (paused==0)
          {

          pauseMenu.planeDistance= 0.6f ;
          paused=2;
          //StartCoroutine("wait");
        }
          //Application.LoadLevel(Application.loadedLevel);
          else if (paused== 1)
          {
            pauseMenu.planeDistance= 200f ;
            paused=4;
            //StartCoroutine("wait");
          //  yield return new WaitForSeconds(2);
          }
          else
          {
            StartCoroutine("wait");
          }

        }
    }
    IEnumerator wait()
    {
      yield return new WaitForSeconds(.25f);
      if (paused==2)
      {
        paused=1;
      }
      else if (paused == 4)
      {
        paused=0;
      }


    }
}
