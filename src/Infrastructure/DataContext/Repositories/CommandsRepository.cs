using Domain.Enums;

namespace Infrastructure.DataContext.Repositories;

internal class CommandsRepository(IOptions<DbOptions> options) : GovernmentContext(options), ICommandsRepository
{
}