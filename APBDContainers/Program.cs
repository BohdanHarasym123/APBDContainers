// See https://aka.ms/new-console-template for more information

using APBDContainers;

Console.WriteLine("Hello, World!");

Container con = new LiquidContainer(10, 10, 10, 300, false);
Console.WriteLine(con.ContainerToString());