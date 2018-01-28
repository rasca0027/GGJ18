using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public abstract class Emotion
{

    public string name;
    public string description;
    public int daysToGrow;
    public int seedPrice;
    public int marketPrice;
    
    public Emotion()
    {
        
    }
}

public class Hope : Emotion
{

    public Hope()
    {
        name = "Hope";
        description = "blah";
        daysToGrow = 3;
        seedPrice = 500;
        marketPrice = 1000;
    }
    
}
