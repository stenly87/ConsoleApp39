// See https://aka.ms/new-console-template for more information
using ConsoleApp39;

Console.WriteLine("Hello, World!");

// создание объекта
// допустим тут 10 строчек кода, которые
// обязательно нужны для создания объекта
// студента
Student student = new Student();
// после создания объекта на нем нужно донастроить
// несколько свойств и вызвать пару методов
// только после этого объект будет считаться
// полностью готовым к использованию

// проблема: много строчек кода при создании
// объекта приводит к тому, что программист
// будет стремиться изолировать код создания
// объекта в одном месте, чтобы не повторять
// одни и те же строчки кода в разных местах
// приложения.

// после изоляции кода появляется другая проблема
// проблема проектирования, она не всплывает
// пока над проектом работает один человек

// для решения проблемы взаимопонимания
// решений разными программистами придумываются
// паттерны - общие принципы решения задач
// различного типа

// код создания объекта - порождающая задача 
// для ее решения существует набор порождающих 
// паттернов

// паттерны содержат общие принципы построения
// кода. При этом эти принципы необязательно
// соблюдать досконально. И в целом паттерны
// нужны не всегда. Использование паттернов
// без оснований может привести к переделыванию
// проекта.

// паттерны подразумеваются к использованию
// в больших проектах, с длительной поддержкой
// при разработке в команде.
// при разработке маленькой программы в одного
// человека паттерны не нужны, поскольку они
// излишне усложнят простой код.
// паттерны спроектированы так, чтобы разрабатывать
// гибкий код. Это код, который нацелен на 
// внесение изменений в будущем.

// виды паттернов
// порождающие - нацелены на создание новых объектов
// 1. Фабричный метод
// Существует абстрактная фабрика, абстрактный продукт
// и конкретные фабрики, создающие конкретные продукты
// при этом весь код по созданию конкретного продукта
// инкапсулирован в конкретную фабрику

// создание конкретной фабрики приводит
// к возможности создания конкретных марок машин
CarFabric fabric = new LadaFabric();
EngineFabric engineFabric = new DieselEngineFabric();
fabric.UseEngine(engineFabric);
Car car1 = fabric.CreateCar();
EngineFabric engineGasolineFabric = new GasolineEngineFabric();
fabric.UseEngine(engineGasolineFabric);
Car car2 = fabric.CreateCar();


abstract class Engine
{ 
}
abstract class CarBody
{ 
}
abstract class Car
{ 
    public string Title { get; set; }
    public Engine Engine { get; protected set; }
    public CarBody CarBody { get; protected set; }

    
}

class Lada : Car
{
    public Lada(string title, Engine engine, CarBody carBody)
    {
        Engine = engine;
        CarBody = carBody;
        Title = title;
    }

    internal void FinishWithAFile()
    {
        // крайне важная работа
        // без этого метода машина непригодна к
        // использованию
    }
}
class GasolineEngine : Engine { }
class DieselEngine : Engine { }
class Cabriolet : CarBody { }

abstract class EngineFabric
{
    public abstract Engine CreateEngine();
}

class DieselEngineFabric : EngineFabric
{
    public override Engine CreateEngine()
    {
        return new DieselEngine();
    }
}

class GasolineEngineFabric : EngineFabric
{
    public override Engine CreateEngine()
    {
        return new GasolineEngine();
    }
}



abstract class CarFabric
{
    public abstract Car CreateCar();
    protected EngineFabric engineFabric;
    internal void UseEngine(EngineFabric engineFabric)
    {
        this.engineFabric = engineFabric;
    }
}

class LadaFabric : CarFabric
{
    public override Car CreateCar()
    {
        Lada lada = new Lada("Лада-2023",
        engineFabric.CreateEngine(),
        new Cabriolet());
        lada.FinishWithAFile(); // доработать напильником
        return lada;            // чтобы лада завелась
    }
}