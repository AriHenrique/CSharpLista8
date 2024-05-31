using System;
using System.IO;
using System.Linq;
using System.Text;

class MarkDown
{
    public static void Exe()
    {
        string[] folders = { @"../../output", @"../../outputDouble" };
        string markdownFile = @"../../../README.md";
        
        StringBuilder markdownContent = new StringBuilder();

        try
        {
            foreach (var folder in folders)
            {
                var files = Directory.GetFiles(folder).OrderBy(filename => filename);
                foreach (var file in files)
                {
                    markdownContent.AppendLine($"## {Path.GetFileName(file)}\n");

                    string content = File.ReadAllText(file);
                    markdownContent.AppendLine(content);
                    markdownContent.AppendLine();
                }
            }
            
            File.WriteAllText(markdownFile, markdownContent.ToString());
            Console.WriteLine("Arquivo Markdown gerado com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao processar os arquivos: {ex.Message}");
        }
    }
}