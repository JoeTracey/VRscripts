using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMoney : MonoBehaviour
{
  [SerializeField]
  Bank bank;
  [SerializeField]
  int amount;

    // Start is called before the first frame update
    public void Transact()
    {
      bank.money +=amount;
    }
}
