using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Client : MonoBehaviour
{
    public int Gender = 1;
    public int Style = 1;
    public int Power = 1;

    [SerializeField] TMP_Text chara;
    void Start()
    {
       // NumberOfWheels = Mathf.Max(NumberOfWheels, 1);
        //Passengers = Mathf.Max(Passengers, 1);
        //Engine = Cargo;
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            FighterRequirements requirements = new FighterRequirements();
            requirements.Gender = Gender;
            requirements.Style = Style;
            requirements.Powers = Power;

            IFighter f = GetFighter(requirements);
            chara.text = "You Get: " + f.ToString();
            Debug.Log(f);
        }
    }

    public void GenderDrop(int index)
    {
        switch(index)
        {
            case 0:
                Gender = 1;
                break;
            case 1: 
                Gender = 2;
                break;
        }
    }

    public void StyleDrop(int index)
    {
        switch (index)
        {
            case 0:
                Style = 1;
                break;
            case 1:
                Style = 2;
                break;
            case 2:
                Style = 3;
                break;
        }
    }

    public void PowerDrop(int index)
    {
        switch (index)
        {
            case 0:
                Power = 1;
                break;
            case 1:
                Power = 2;
                break;
            case 2:
                Power = 3;
                break;
        }
    }

    private static IFighter GetFighter(FighterRequirements requirements)
    {
        FighterFactory factory = new FighterFactory(requirements);
        return factory.Create();
    }
}