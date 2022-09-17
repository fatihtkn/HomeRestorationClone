using System.Collections;
using UnityEngine;


public class ConfettiManager :MonoSingleton<ConfettiManager>
{
    [SerializeField]private GameObject confettiPrefab;
    public  GameObject Confetti => confettiPrefab;
    public  void CreateConfetti()
    {

        confettiPrefab.SetActive(true);

    }
   
    




}
