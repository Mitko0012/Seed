using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using NAudio;
using NAudio.Wave;

namespace Seed
{
    /// <summary>
    /// Class that represents a sound.
    /// </summary>
    public class Sound
    {
        WaveOutEvent outputDevice = new WaveOutEvent();
        /// <summary>
        /// Shows if the sound is playing.
        /// </summary>
        public bool IsPlaying {get; private set;}
        string path;
        /// <summary>
        /// Shows if the sound should loop after it finishes.
        /// </summary>
        public bool Looping {get; set;}
        /// <summary>
        /// Shows the volume of the sound.
        /// </summary>
        public float Volume {get; private set;}
        
        /// <summary>
        /// Sets the volume of the sound.
        /// </summary>
        /// <param name="vol">The value which should be set as the volume of the sound. A float between 0 and 1.</param>
        public void SetVolume(float vol)
        {
            if(vol > 0 && vol < 1)
            {
                outputDevice.Volume = vol;
                Volume = vol;
            }
        }
        /// <summary>
        /// Creates an object of the Sound class.
        /// </summary>
        /// <param name="path">The filepath of the sound file.</param>
        /// <param name="volume">The volume of the sound. A float between 0 and 1.</param>
        /// <param name="looping">Value that shows whether the sound should loop.</param>
        public Sound(string path, float volume, bool looping)
        {
            this.path = path;
            SetVolume(volume);
            this.Looping = looping;
        }

        /// <summary>
        /// Plays the sound.
        /// </summary>
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

        /// <summary>
        /// Stops the sound.
        /// </summary>
        public void Stop()
        {
            this.IsPlaying = false;
        }

        /// <summary>
        /// Changes the volume of the sound.
        /// </summary>
        /// <param name="vol">Value to be set as the volume.</param>
        public void ChangeVolume(float vol)
        {
            outputDevice.Volume = vol;
        }
    }
}
