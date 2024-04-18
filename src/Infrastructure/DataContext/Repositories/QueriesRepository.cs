namespace Infrastructure.DataContext.Repositories;

internal class QueriesRepository : GovernmentContext, IQueriesRepository
{
    public QueriesRepository(IOptions<DbOptions> options) : base(options)
        => ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
}