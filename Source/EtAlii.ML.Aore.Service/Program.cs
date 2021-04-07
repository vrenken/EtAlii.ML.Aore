namespace EtAlii.ML.Aore.Service
{
    using System;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var systemContext = new SystemContext();
            await systemContext
                .StartAsync(args)
                .ConfigureAwait(false);

            Console.ReadKey();
        }
    }
}
