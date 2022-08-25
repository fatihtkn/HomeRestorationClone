using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiManager : MonoBehaviour
{
    [SerializeField]private GameObject confetti_prefab;
    public static ConfettiManager confettiSc;
    private bool control;
    private void Awake()
    {
        confettiSc = GetComponent<ConfettiManager>();
        
    }

    public  void CreateConfetti()
    {


        
        StartCoroutine(Cooldown());

    }
    private IEnumerator Cooldown()
    {
        confetti_prefab.SetActive(true);
        yield return new WaitForSeconds(3f);
        confetti_prefab.SetActive(false);
    }
    




}
