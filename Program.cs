using System;
using System.Speech.Synthesis;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Initialize SpeechSynthesizer
        using (var synth = new SpeechSynthesizer())
        {
            Console.WriteLine("Enter the text you want to convert to audio:");
            string text = Console.ReadLine();

            // Generate speech from the input text
            var audioStream = new MemoryStream();
            synth.SetOutputToWaveStream(audioStream);
            synth.Speak(text);

            // Save the audio stream to a file
            string audioFilePath = "output.wav";
            File.WriteAllBytes(audioFilePath, audioStream.ToArray());

            Console.WriteLine($"Audio saved to {audioFilePath}");
        }
    }
}
