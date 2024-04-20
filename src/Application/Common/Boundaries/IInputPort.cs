namespace Application.Common.Boundaries;

public interface IInputPort<T>
{
    Task Execute(T instance, CancellationToken cancellationToken);
}

public interface IInputPort
{
    Task Execute(CancellationToken cancellationToken);
}