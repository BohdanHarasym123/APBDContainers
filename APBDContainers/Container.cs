namespace APBDContainers;

public abstract class Container
{
    public static int ContainerCount = 0;
    public string SerialNumber { get; set; }
    public double CargoMass { get; set; }
    public double TareWeight { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public double MaximumPayload { get; set; }

    public Container(double _TareWeight, double _Height, double _Depth, double _MaximumPayload)
    {
        TareWeight = _TareWeight;
        Height = _Height;
        Depth = _Depth;
        MaximumPayload = _MaximumPayload;
        ContainerCount++;
    }
    
    public abstract void LoadCargo(double mass) ;

    public abstract void EmptyCargo();

    public virtual string ContainerToString()
    {
        return $"Container {SerialNumber}, tare weight {TareWeight}, mass of cargo {CargoMass}, maximum payload {MaximumPayload}";
    }
}