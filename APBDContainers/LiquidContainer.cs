namespace APBDContainers;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; set; }

    public LiquidContainer(double _TareWeight, double _Height, double _Depth, double _MaximumPayload, bool _isHazardous)
        : base(_TareWeight, _Height, _Depth, _MaximumPayload)
    {
        IsHazardous = _isHazardous;
        SerialNumber = $"KON-L-{ContainerCount}";
    }

    public override void LoadCargo(double mass)
    {
        if (IsHazardous && mass > 0.5 * MaximumPayload)
        {
            throw new OverfillException("Exceeded maximum payload for hazardous material");
        }
        else if(mass > 0.9 * MaximumPayload)
        {
            throw new OverfillException("Exceeded maximum payload");
        }
        
        CargoMass = mass;
    }

    public override void EmptyCargo()
    {
        CargoMass = 0;
    }

    public void notifyHazard(string msg)
    {
        Console.WriteLine($"WARNING: Hazardous situation occuring at {SerialNumber} container");
    }
}