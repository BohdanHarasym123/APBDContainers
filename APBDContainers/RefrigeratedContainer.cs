namespace APBDContainers;

public class RefrigeratedContainer : Container
{
    public string Type { get; set; }
    public double Temperature { get; set; }

    public RefrigeratedContainer(double _TareWeight, double _Height, double _Depth, double _MaximumPayload, string _Type, double _Temperature)
        : base(_TareWeight, _Height, _Depth, _MaximumPayload)
    {
        Type = _Type;
        Temperature = _Temperature;
        SerialNumber = $"KON-R-{ContainerCount}";
    }

    public override void LoadCargo(double mass)
    {
        if (mass > MaximumPayload)
        {
            throw new OverfillException("Exceeded maximum payload");
        }
        
        CargoMass = mass;
    }

    public override void EmptyCargo()
    {
        CargoMass = 0;
    }

    public override string ContainerToString()
    {
        return base.ToString() + $" type {Type}, temperature {Temperature}";
    }
}