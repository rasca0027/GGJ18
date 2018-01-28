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
         daysToGrow = 3; // just for testing TODO
         seedPrice = 500;
         marketPrice = 1000;
     }
 }

public class Stress : Emotion
{
    public Stress()
    {
        name = "Stress";
        description = "blah";
        daysToGrow = 1;
        seedPrice = 0;
        marketPrice = 1;
    }
}

public class Anger : Emotion
{
    public Anger()
    {
        name = "Anger";
        description = "blah";
        daysToGrow = 5;
        seedPrice = 70;
        marketPrice = 100;
    }
}

public class Fear : Emotion
{
    public Fear()
    {
        name = "Fear";
        description = "blah";
        daysToGrow = 5;
        seedPrice = 50;
        marketPrice = 100;
    }
}

public class Desire : Emotion
{
    public Desire()
    {
        name = "Desire";
        description = "blah";
        daysToGrow = 2;
        seedPrice = 5;
        marketPrice = 10;
    }
}

public class Grief : Emotion
{
    public Grief()
    {
        name = "Grief";
        description = "blah";
        daysToGrow = 3;
        seedPrice = 20;
        marketPrice = 50;
    }
}

public class Joy : Emotion
{
    public Joy()
    {
        name = "Joy";
        description = "blah";
        daysToGrow = 365;
        seedPrice = 100000;
        marketPrice = 1000000;
    }
}
