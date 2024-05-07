using System;

class Program
{
    static void Main(string[] args)
    {
        ITransportImplementor jaguarImplementor = new CarTransportImplementor(250, 2000, 100);
        ITransport jaguar = new Jaguar(jaguarImplementor);
        Console.WriteLine(jaguar.GetInfo());
    }
}
public interface ITransport
{
    double Speed { get; }
    double Capacity { get; }
    double Range { get; }

    string GetInfo();
}

public abstract class Transport : ITransport
{
    protected ITransportImplementor _implementor;

    protected Transport(ITransportImplementor implementor)
    {
        _implementor = implementor;
    }

    public double Speed => _implementor.Speed;
    public double Capacity => _implementor.Capacity;
    public double Range => _implementor.Range;

    public string GetInfo()
    {
        return _implementor.GetInfo();
    }
}

public interface ITransportImplementor
{
    double Speed { get; }
    double Capacity { get; }
    double Range { get; }

    string GetInfo();
}

public class CarTransportImplementor : ITransportImplementor
{
    public double Speed { get; }
    public double Capacity { get; }
    public double Range { get; }

    public CarTransportImplementor(double speed, double capacity, double range)
    {
        Speed = speed;
        Capacity = capacity;
        Range = range;
    }

    public string GetInfo()
    {
        return $"Автомобиль со скоростью {Speed} км/ч грузоподъемностью в {Capacity} кг может проехать {Range} км";
    }
}
public class Jaguar : Transport
{
    public Jaguar(CarTransportImplementor implementor) : base(implementor)
    {
    }

    public Jaguar(ITransportImplementor implementor) : base(implementor)
    {
    }
}