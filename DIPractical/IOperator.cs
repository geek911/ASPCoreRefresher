namespace DIPractical;

public interface IOperator
{
    void Write();
}


public interface IOperatorTransient : IOperator{}
public interface IOperatorScope : IOperator{}
public interface IOperatorSingleton : IOperator{}


public class Dependancy : IOperatorTransient, IOperatorScope, IOperatorSingleton
{
    readonly Guid _guid;

    public Dependancy(Guid guid)
    {
        _guid = guid;
    }
    public void Write()
    {
        Console.WriteLine($"GUID : {_guid}");
    }
}