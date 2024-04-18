namespace Application.Common.Handlers;

public abstract class Handler<T>
{
    protected Handler<T>? Successor;

    public Handler<T> SetSuccessor(Handler<T> successor)
        => Successor = successor;

    public abstract Task Process(T toHandle, CancellationToken cancellationToken);
}