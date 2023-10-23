using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFighterFactory
{
    IFighter Create(FighterRequirements requirements);
}

public class PowerlessFactory : IFighterFactory
{
    public IFighter Create(FighterRequirements requirements)
    {
        switch (requirements.Style)
        {
            case 1:
                if (requirements.Gender == 2) return new LiMei();
                return new JohnnyCage();
            case 2:
                return new Katana();
            case 3:
                if (requirements.Gender == 2) return new SonyaBlade();
                return new Kano();
            default:
                return new JohnnyCage();
        }
    }
}

public class FireFactory : IFighterFactory
{
    public IFighter Create(FighterRequirements requirements)
    {
        switch (requirements.Style)
        {
            case 1:
                return new LiuKang();
            case 2:
                return new Scorpion();
            case 3:
                return new Blaze();
            default:
                return new LiuKang();
        }
    }
}

public class IceFactory : IFighterFactory
{
    public IFighter Create(FighterRequirements requirements)
    {
        switch (requirements.Style)
        {
            case 2:
                if (requirements.Gender == 2) return new Frost();
                return new SubZero();
            default:
                return new SubZero();
        }
    }
}

public abstract class AbstractFighterFactory
{
    public abstract IFighter Create();
}

public class FighterFactory : AbstractFighterFactory
{
    private readonly IFighterFactory _factory;
    private readonly FighterRequirements _requirements;

    public FighterFactory(FighterRequirements requirements)
    {
        //_factory = requirements.Engine ? (IVehicleFactory)new MotorVehicleFactory() : new CycleFactory();
        if(requirements.Powers == 1)
        { 
            _factory = new PowerlessFactory(); 
        }
        else if(requirements.Powers == 2)
        {
            _factory = new FireFactory();
        }
        else if(requirements.Powers == 3)
        {
            _factory = new IceFactory();
        }

        _requirements = requirements;
    }

    public override IFighter Create()
    {
        return _factory.Create(_requirements);
    }
}
