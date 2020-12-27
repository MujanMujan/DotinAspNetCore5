using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace CourseStore.Infra.Dal
{
    public class CountDatabaseAccessInterceptor : DbCommandInterceptor
    {

        private long databaseAccessCounter = 0;
        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {

            Console.WriteLine(command.CommandText);
            databaseAccessCounter += 1;
            Console.WriteLine($"Total database access count: {databaseAccessCounter}\n");
            return base.ReaderExecuting(command, eventData, result);
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        {
            Console.WriteLine(command);
            return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
        }
    }
}
