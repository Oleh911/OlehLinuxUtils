using Spectre.Console.Cli;
using System.ComponentModel;
using OlehLinuxUtils.Utils;

public sealed class TailCommand : Command<TailCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [Description("Number of lines (default 10)")]
        [CommandOption("-n|--lines <NUM>")]
        public int Lines { get; set; } = 10;

        [Description("Input files")]
        [CommandArgument(0, "[files]")]
        public string[] Files { get; set; } = Array.Empty<string>();
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        var buffer = new Queue<string>();

        foreach (var line in FileReader.ReadLines(settings.Files))
        {
            buffer.Enqueue(line);
            if (buffer.Count > settings.Lines)
                buffer.Dequeue();
        }

        foreach (var line in buffer)
            Console.WriteLine(line);

        return 0;
    }
}
