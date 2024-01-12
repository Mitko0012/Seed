using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using NAudio;
using NAudio.Wave;

namespace Seed
{
    public class Sound
    {
        WaveOutEvent outputDevice = new WaveOutEvent();
        public bool IsPlaying {get; private set;}
        string path;
        public Sound(string path, float volume)
        {
            this.path = path;
            outputDevice.Volume = volume;
        }

        public void Play()
        {
            Thread startThread = new Thread(StartSound);
            AudioFileReader soundFile = new AudioFileReader(path);
            IsPlaying = true;
            outputDevice.Init(soundFile);
            outputDevice.Play();
            startThread.Start();
        }

        private void StartSound()
        {
            while(outputDevice.PlaybackState == PlaybackState.Playing && IsPlaying)
            {
                Thread.Sleep(1);
            }
            Console.WriteLine("Stopped lol");
            outputDevice.Stop();
            IsPlaying = false;
        }

        public void Stop()
        {
            this.IsPlaying = false;
        }
    }
}
