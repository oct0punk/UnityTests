using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoofType
{
    flat,
    round,
    pointy
}

public interface IHouseBuilder
{
    public IHouseBuilder Reset();
    public IHouseBuilder WithGarden();
    public IHouseBuilder WithGarage();
    public IHouseBuilder WithFancyStatues();
    public IHouseBuilder WithSwimmingPool();
    public IHouseBuilder SetRoofType(RoofType roof);
    public House Build();
}
