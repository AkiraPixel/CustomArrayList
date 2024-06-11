// See https://aka.ms/new-console-template for more information

using ConsoleApp;

Console.WriteLine("Hello, World!");

CustomArrayList customArrayList = new CustomArrayList(new[] { 1, 3, 4 });
   customArrayList.Print();

customArrayList.Add(2,1);

customArrayList.Print();
    


customArrayList.Add(new[]{5,6}, 2);


customArrayList.Print();
Console.ReadKey();