namespace Application.Common.Boundaries;

public interface IOutputPort<T>
{
    Task Error(Exception exception);
    Task Default(T? response);
}