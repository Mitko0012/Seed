using NAudio.MediaFoundation;
using NAudio.Wave;

namespace Seed
{
    /// <summary>
    /// A class that represents a sound.
    /// </summary>
    public class Sound
    {
        AudioFileReader soundFile;
        WaveOutEvent _outputDevice = new WaveOutEvent();
        /// <summary>
        /// True if the sound is playing, otherwise false.
        /// </summary>
        public bool IsPlaying { get; private set; }
        /// <summary>
        /// True if the sound is paused, otherwise false.
        /// </summary>
        public bool IsPaused { get; private set; }
        /// <summary>
        /// True if the sound should loop after it finishes, otherwise false.
        /// </summary>
        public bool Looping { get; set; }
        /// <summary>
        /// Shows the volume of the sound.
        /// </summary>
        public float Volume { get; private set; }

        /// <summary>
        /// Sets the volume of the sound.
        /// </summary>
        /// <param name="vol">The value to be set as the volume of the sound. A float between 0 and 1.</param>
        public void SetVolume(float vol)
        {
            if (vol >= 0 && vol <= 1)
            {
                _outputDevice.Volume = vol;
                Volume = vol;
            }
        }
        /// <summary>
        /// Creates an object of the Sound class.
        /// </summary>
        /// <param name="path">The filepath of the sound file.</param>
        /// <param name="volume">The volume of the sound. A float between 0 and 1.</param>
        /// <param name="looping">True if the sound should loop, otherwise false.</param>
        public Sound(string path, float volume, bool looping)
        {
            _outputDevice.PlaybackStopped += PlaybackStopped;
            soundFile = new AudioFileReader(path);
            _outputDevice.Init(soundFile);
            SetVolume(volume);
            this.Looping = looping;
        }

        /// <summary>
        /// Plays the sound.
        /// </summary>
        public void Play()
        {
            if (!IsPlaying)
            {
                _outputDevice.Play();
                IsPlaying = true;
            }
        }

        private void PlaybackStopped(object? sender, EventArgs args)
        {
            soundFile.Position = 0;
            if (Looping && IsPlaying)
            {
                IsPlaying = false;
                Play();
            }
            else 
                IsPlaying = false;
        }

        /// <summary>
        /// Stops the sound.
        /// </summary>
        public void Stop()
        {
            if (IsPlaying)
            {
                IsPlaying = false;
                IsPaused = false;
                _outputDevice.Stop();
                IsPlaying = false;
            }
        }

        /// <summary>
        /// Pauses the sound.
        /// </summary>
        public void Pause()
        {
            if (IsPlaying && !IsPaused)
            {
                IsPaused = true;
                _outputDevice.Pause();
            }
        }

        /// <summary>
        /// Resumes the sound.
        /// </summary>
        public void Resume()
        {
            if (IsPlaying && IsPaused)
            {
                IsPaused = false;
                _outputDevice.Play();
            }
        }
    }
}