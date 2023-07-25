using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject First_Person;
    public GameObject Third_Person;
    public int Manager;
    public void ChangeCamera()
    {
        GetComponent<Animator>().SetTrigger("Change");
    }
    public void ManagerCamera()
    {
        if (Manager == 0)
        {
            FirstPerson();
            Manager = 1;
        }
        else
        {
            ThirdPerson();
            Manager = 0;
        }
    }


    void FirstPerson()
    {
        First_Person.SetActive(true);
        Third_Person.SetActive(false);
    }

    void ThirdPerson()
    {
        First_Person.SetActive(false);
        Third_Person.SetActive(true);
    }
}
