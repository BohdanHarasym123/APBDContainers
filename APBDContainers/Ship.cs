namespace APBDContainers;

public class Ship
{
    private List<Container> Containers { get; set; }
    public int MaxSpeed { get; set; }
    public int MaxContainers { get; set; }
    public double MaxCargoWeight { get; set; }

    public Ship(int _MaxSpeed, int _MaxContainers, double _MaxCargoWeight)
    {
        MaxSpeed = _MaxSpeed;
        MaxContainers = _MaxContainers;
        MaxCargoWeight = _MaxCargoWeight;
        Containers = new List<Container>();
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count + 1 > MaxContainers)
        {
            throw new OverfillException("No more containers allowed on ship");
        } else if (ComputeMass(Containers) + container.TareWeight + container.CargoMass > MaxCargoWeight)
        {
            throw new OverfillException("Ship exceeded maximum weight");
        }
        
        Containers.Add(container);
    }

    public void LoadContainersList(List<Container> list)
    {
        if (Containers.Count + list.Count > MaxContainers)
        {
            throw new OverfillException("No more containers allowed on ship");
        } else if (ComputeMass(Containers) + ComputeMass(list) > MaxCargoWeight)
        {
            throw new OverfillException("Ship exceeded maximum weight");
        }

        foreach (Container container in list)
        {
            Containers.Add(container);
        }
    }

    public void UnloadContainer(string SerialNumber)
    {
        for(int i = 0; i < Containers.Count(); i++)
        {
            if (Containers[i].SerialNumber.Equals(SerialNumber))
            {
                Containers.RemoveAt(i);
            }
        }
    }

    public void ReplaceContainer(int index, Container container)
    {
        Containers.RemoveAt(index);
        Containers.Add(container);
    }

    public void TransferContainer(int index, Ship ship)
    {
        Container container = Containers[index];
        Containers.RemoveAt(index);
        ship.LoadContainer(container);
    }


    private double ComputeMass(List<Container> list)
    {
        double Mass = 0;
        foreach (Container container in list)
        {
            Mass += container.CargoMass + container.TareWeight;
        }

        return Mass;
    }

    public override string ToString()
    {
        string res = $"Max speed {MaxSpeed} knots, max capacity {MaxContainers}, max weight {MaxCargoWeight}";
        foreach (Container container in Containers)
        {
            res += ", " + container.ContainerToString();
        }
        return res;
    }
}