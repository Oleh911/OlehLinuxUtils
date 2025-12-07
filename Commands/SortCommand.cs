using Spectre.Console.Cli;
using System.ComponentModel;
using OlehLinuxUtils.Utils;

public sealed class SortCommand : Command<SortCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [Description("Reverse order")]
        [CommandOption("-r|--reverse")]
        public bool Reverse { get; set; }

        [Description("Numeric sort")]
        [CommandOption("-n|--numeric")]
        public bool Numeric { get; set; }

        [Description("Input files")]
        [CommandArgument(0, "[files]")]
        public string[] Files { get; set; } = Array.Empty<string>();
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        var lines = FileReader.ReadLines(settings.Files).ToList();

        Func<string, (int, object)> numericKey = s =>
        {
            if (double.TryParse(s, out double d))
                return (0, d);
            return (1, s);
        };

        try
        {
            if (settings.Numeric)
                lines.Sort((a, b) => Compare(numericKey(a), numericKey(b)));
            else
                lines.Sort(StringComparer.Ordinal);
        }
        catch
        {
            lines = lines.OrderBy(l => l).ToList();
        }

        if (settings.Reverse)
            lines.Reverse();

        foreach (var line in lines)
            Console.WriteLine(line);

        return 0;
    }

    static int Compare((int, object) a, (int, object) b)
    {
        int c = a.Item1.CompareTo(b.Item1);
        if (c != 0) return c;
        return Comparer<object>.Default.Compare(a.Item2, b.Item2);
    }
}
