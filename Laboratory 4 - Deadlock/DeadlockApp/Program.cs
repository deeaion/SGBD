using System;
using System.Threading;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Serilog;
using Microsoft.Extensions.DependencyInjection;

namespace DeadlockApp
{
    internal class Program
    {
        public class SharedState
        {
            public bool TransactionCommitted { get; set; }
        }

        public static Thread CreateThread1(string connection, ILogger<Program> logger, SharedState sharedState)
        {
            return new Thread(() =>
            {
                try
                {
                    logger.LogInformation("Thread 1 started");
                    using (SqlConnection connectionDB = new SqlConnection(connection))
                    {
                        connectionDB.Open();
                        using (SqlCommand setDeadlockPriorityCommand = connectionDB.CreateCommand())
                        {
                            setDeadlockPriorityCommand.CommandText = "SET DEADLOCK_PRIORITY HIGH";
                            setDeadlockPriorityCommand.ExecuteNonQuery();
                        }

                        using (SqlTransaction trans = connectionDB.BeginTransaction())
                        {
                            try
                            {
                                using (SqlCommand command = connectionDB.CreateCommand())
                                {
                                    command.Transaction = trans;
                                    command.CommandText = "update Artist set first_name='JisungD1' where id_artist=19";
                                    command.ExecuteNonQuery();
                                    Thread.Sleep(4000); // Simulate delay
                                    command.CommandText = "update Band set records_number=51 where id_group=1";
                                    command.ExecuteNonQuery();
                                }

                                trans.Commit();
                                sharedState.TransactionCommitted = true;
                                logger.LogInformation("Thread 1 transaction committed");
                            }
                            catch (SqlException e)
                            {
                                logger.LogError(e, "Thread 1 SQL Exception");
                                trans.Rollback();
                                logger.LogInformation("Thread 1 transaction rolled back");
                                if (e.Number == 1205)
                                {
                                    logger.LogInformation("Thread 1 deadlock detected");
                                }
                                else
                                {
                                    throw;
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    logger.LogError(e, "Thread 1 Exception");
                }
            });
        }

        public static Thread CreateThread2(string connection, ILogger<Program> logger, SharedState sharedState)
        {
            return new Thread(() =>
            {
                try
                {
                    logger.LogInformation("Thread 2 started");
                    using (SqlConnection connectionDB = new SqlConnection(connection))
                    {
                        connectionDB.Open();
                        using (SqlCommand setDeadlockPriorityCommand = connectionDB.CreateCommand())
                        {
                            setDeadlockPriorityCommand.CommandText = "SET DEADLOCK_PRIORITY HIGH";
                            setDeadlockPriorityCommand.ExecuteNonQuery();
                        }

                        using (SqlTransaction trans = connectionDB.BeginTransaction())
                        {
                            try
                            {
                                using (SqlCommand command = connectionDB.CreateCommand())
                                {
                                    command.Transaction = trans;
                                    command.CommandText = "update Band set records_number=52 where id_group=1";
                                    command.ExecuteNonQuery();
                                    Thread.Sleep(4000); // Simulate delay
                                    command.CommandText = "update Artist set first_name='JisungD2' where id_artist=19";
                                    command.ExecuteNonQuery();
                                }

                                trans.Commit();
                                sharedState.TransactionCommitted = true;
                                logger.LogInformation("Thread 2 transaction committed");
                            }
                            catch (SqlException e)
                            {
                                logger.LogError(e, "Thread 2 SQL Exception");
                                trans.Rollback();
                                logger.LogInformation("Thread 2 transaction rolled back");
                                if (e.Number == 1205)
                                {
                                    logger.LogInformation("Thread 2 deadlock detected");
                                }
                                else
                                {
                                    throw;
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    logger.LogError(e, "Thread 2 Exception");
                }
            });
        }

        public static void Main(string[] args)
        {
            string connection =
                @"Data Source=DESKTOP-32D15JA\SQLEXPRESS;Initial Catalog=KpopStore;Integrated Security=True;TrustServerCertificate=true;";
            var sharedState = new SharedState();

            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            // Create a logger factory and add Serilog
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });

            // Create a logger
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogInformation("Starting the actual while loop");

            while (!sharedState.TransactionCommitted)
            {
                logger.LogInformation("Attempting transactions");
                var thread1 = CreateThread1(connection, logger, sharedState);
                var thread2 = CreateThread2(connection, logger, sharedState);

                thread1.Start();
                thread2.Start();

                thread1.Join();
                thread2.Join();
            }

            logger.LogInformation("One transaction completed successfully. Application will now stop.");

            Log.CloseAndFlush();
        }
    }
}
