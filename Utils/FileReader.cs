using System.Collections.Generic;
using System.IO;

namespace OlehLinuxUtils.Utils;

public static class FileReader
{
    public static IEnumerable<string> ReadLines(IEnumerable<string> files)
    {
        bool noFiles = true;

        foreach (var f in files)
        {
            noFiles = false;

            if (f == "-")
            {
                string? line;
                while ((line = Console.ReadLine()) != null)
                    yield return line;
            }
            else
            {
                foreach (var line in File.ReadLines(f))
                    yield return line;
            }
        }

        if (noFiles)
        {
            string? line;
            while ((line = Console.ReadLine()) != null)
                yield return line;
        }
    }
}
