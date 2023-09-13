#nullable enable
using System.Data;
using BuiltCode.CrossCutting.Extensions;
using Dapper;
using Descarpack.BookGerencial.CrossCutting.Config;
using Descarpack.BookGerencial.CrossCutting.Contracts.Infra.Services;
using Descarpack.BookGerencial.Domain.Logs;
using Descarpack.BookGerencial.Infra.Services;
using Npgsql;

namespace IntegratedAccountManagement.ApiConfiguration.Startup;
    public static class LoggerConfig
    {
        public static IServiceCollection AddLogger(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));

            services.AddSingleton<ILoggerStorageService>(sp =>
                new LoggerStorageService(
                    config.GetSection($"{nameof(AppConfig)}:{nameof(AppConfig.Logger)}").Value ?? string.Empty,
                    StoreLog(config.GetConnectionString("Default") ?? string.Empty),
                    sp.GetRequiredService<ILoggerAdapter<ILoggerStorageService>>()));

            return services;
        }

        private static LoggerStorageService.StoreLog StoreLog(string connectionString)
        {
            return (level, logger, message, exception) =>
            {
                var log = new Log
                {
                    Id = Guid.NewGuid(),
                    Exception = exception?.GetStackTraceMessage() ?? exception?.GetCompleteRecursiveMessage(),
                    Message = message,
                    Level = level.ToString(),
                    Logger = logger,
                    OccurredAt = DateTime.UtcNow
                };

                using var sqlConnection = new NpgsqlConnection(connectionString);
                try
                {
                    var sql = @"
                        set schema 'public';
                        insert into logs (id, occurred_at, level, logger, message, exception)
                        values (@Id, @OccurredAt, @Level, @Logger, @Message, @Exception)";

                    sqlConnection.Execute(
                        sql,
                        log,
                        commandType: CommandType.Text
                    );

                }
                finally
                {
                    sqlConnection.Close();
                }
            };
        }
    }

