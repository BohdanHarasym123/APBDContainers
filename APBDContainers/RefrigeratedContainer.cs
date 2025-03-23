namespace APBDContainers;

public class RefrigeratedContainer : Container
{
    public string Type { get; set; }
    public double Temperature { get; set; }

    private static Dictionary<string, double> ProductTemperature = new Dictionary<string, double>
    {
        {"Frozen Pizza", -30}, {"Bananas", 13.3}, {"Chocolate", 18}, {"Fish", 2}, {"Meat", -15}, {"Ice cream", -18},
        {"Cheese", 7.2}, {"Sausages", 5}, {"Butter", 20.5}, {"Eggs", 19}
    };

    public RefrigeratedContainer(double _TareWeight, double _Height, double _Depth, double _MaximumPayload, string _Type, double _Temperature)
        : base(_TareWeight, _Height, _Depth, _MaximumPayload)
    {
        Type = _Type;
        if (ProductTemperature.ContainsKey(Type))
        {
            Temperature = (_Temperature >= ProductTemperature[Type]) ? _Temperature : ProductTemperature[Type];
        }
        else
        {
            Temperature = _Temperature;
        }
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
        return base.ContainerToString() + $", type {Type}, temperature {Temperature}";
    }
}