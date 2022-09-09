using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtPercentageCalculation : IRemovedDirtCalculator
{
    
   
    public float RemovedDirtCalculate(float removedAmount,float totalAmount)
    {

        return removedAmount / totalAmount;
    }
}
