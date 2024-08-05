using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class HouseBuilder : IHouseBuilder
{
    House house;
    public HouseBuilder()
    {
        Reset();
    }

    public House Build()
    {
        Debug.Log(house.print());
        return house;
    }

    public IHouseBuilder Reset()
    {
        house = new House();
        return this;
    }

    public IHouseBuilder SetRoofType(RoofType roof)
    {
        house.roof = roof;
        return this;
    }

    public IHouseBuilder WithFancyStatues()
    {
        house.AddExtension("Statues");
        return this;
    }

    public IHouseBuilder WithGarage()
    {
        house.AddExtension("Garage");
        return this;
    }

    public IHouseBuilder WithGarden()
    {
        house.AddExtension("Garden");
        return this;
    }

    public IHouseBuilder WithSwimmingPool()
    {
        house.AddExtension("SwimmingPool");
        return this;
    }
}
