// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design.Serialization;
using APBDContainers;

Console.WriteLine("Hello, World!");

Container liquidContainer = new LiquidContainer(10, 10, 10, 300, false);
liquidContainer.LoadCargo(50);
Console.WriteLine(liquidContainer.ContainerToString());

Container gasContainer = new GasContainer(10, 10, 10, 300, 50);
gasContainer.LoadCargo(50);
Console.WriteLine(gasContainer.ContainerToString());

gasContainer.EmptyCargo();
Console.WriteLine(gasContainer.ContainerToString());

gasContainer.LoadCargo(50);
Console.WriteLine(gasContainer.ContainerToString());

Container refContainer = new RefrigeratedContainer(10, 10, 10, 300, "Pizza", -30);
refContainer.LoadCargo(150);
Console.WriteLine(refContainer.ContainerToString());

Ship ship = new Ship(50, 4, 300);
ship.LoadContainer(liquidContainer);

List<Container> conts = new List<Container>();
conts.Add(refContainer);
conts.Add(gasContainer);
ship.LoadContainersList(conts);

Console.WriteLine(ship);
ship.UnloadContainer("KON-G-2");