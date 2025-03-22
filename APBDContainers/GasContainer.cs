namespace APBDContainers;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }

    public GasContainer(double _TareWeight, double _Height, double _Depth, double _MaximumPayload, double _Pressure)
        : base(_TareWeight, _Height, _Depth, _MaximumPayload)
    {
        Pressure = _Pressure;
        SerialNumber = $"KON-G-{ContainerCount}";
    }

    public override void LoadCargo(double mass)
    {
        if (CargoMass + mass > MaximumPayload)
        {
            throw new OverfillException("Exceeded maximum payload");
        }

        CargoMass += mass;
    }

    public override void EmptyCargo()
    {
        CargoMass = 0.05 * CargoMass;
    }

    public void notifyHazard(string msg)
    {
        Console.WriteLine($"WARNING: Hazardous situation occuring at {SerialNumber} container");
    }

    public override string ContainerToString()
    {
        return base.ToString() + $" pressure {Pressure}";
    }
}