using System.Diagnostics;
using Whisper.net;
using Whisper.net.Ggml;

Console.WriteLine("Whisper.net");

string outputFilePath = "transcricao.txt";
using var transcript = File.CreateText(outputFilePath);
Process.Start("ffmpeg", "-i Aline.mp3 -ar 16000 -ac 1 Aline.wav").WaitForExit();

var modelName = "model-me.bin";
if (!File.Exists(modelName))
{
    Console.WriteLine("Baixando!");
    using var modelStream = await WhisperGgmlDownloader.GetGgmlModelAsync(GgmlType.LargeV3);
    using var fileWriter = File.OpenWrite(modelName);
    await modelStream.CopyToAsync(fileWriter);
}

Console.WriteLine("Processando audio...");

using var whisperFactory = WhisperFactory.FromPath(modelName);
using var builder = whisperFactory.CreateBuilder()
    .WithLanguage("portuguese")
    .Build();


using var audioStream = File.OpenRead("Aline.wav");

await foreach (var result in builder.ProcessAsync(audioStream))
{
    Console.WriteLine($"{result.Start} -> {result.End}: {result.Text}");
    transcript.WriteLine(result.Text);
}

Console.WriteLine("Feito!");
