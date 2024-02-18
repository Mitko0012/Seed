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
        public bool Looping {get; set;}
        public float Volume {get; private set;}
        
        public void SetVolume(float vol)
        {
            if(vol > 0 && vol < 1)
            {
                outputDevice.Volume = vol;
                Volume = vol;
            }
        }
        public Sound(string path, float volume, bool looping)
        {
            this.path = path;
            SetVolume(volume);
            this.Looping = looping;
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
            if(Looping && IsPlaying)
            {
                this.Play();
            }
            else
            {
                outputDevice.Stop();
                IsPlaying = false;
            }
        }

        public void Stop()
        {
            this.IsPlaying = false;
        }

        public void ChangeSound(float vol)
        {
            outputDevice.Volume = vol;
        }
    }
}
