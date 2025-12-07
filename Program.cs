using Spectre.Console.Cli;
using System.Threading.Tasks;

class Program
{
    public static async Task<int> Main(string[] args)
    {
        var app = new CommandApp();

        app.Configure(config =>
        {
            config.AddCommand<SortCommand>("sort");
            config.AddCommand<TailCommand>("tail");
        });

        return await app.RunAsync(args);
    }
}
