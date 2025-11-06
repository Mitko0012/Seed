using NAudio.Wave;

namespace Seed
{
    /// <summary>
    /// A class that represents a sound.
    /// </summary>
    public class Sound : IDisposable
    {
        WaveOutEvent _outputDevice = new WaveOutEvent();
        AudioFileReader _soundFile;
        private bool _isPlaying;
		readonly bool _isInitialized;
        /// <summary>
        /// True if the sound is playing, otherwise false.
        /// </summary>
        public bool IsPlaying
        {
            get
            {
                if (_isPlaying && _outputDevice.PlaybackState == PlaybackState.Stopped)
                {
					if(_isInitialized)
                    	_outputDevice.Stop();
                    _soundFile.Position = 0;
                    _isPlaying = false;
                }
                return _isPlaying;
            }
            private set
            {
                _isPlaying = value;
            }
        }
        string path;
        private float _volume = 1;
        /// <summary>
        /// Gets or sets the volume of the sound.
        /// </summary>
        public float Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                if (value <= 1 && value >= 0)
                {
                    _volume = value;
                    _outputDevice.Volume = value;
                }
            }
        }
        /// <summary>
        /// Creates an object of the Sound class.
        /// </summary>
        /// <param name="path">The filepath of the sound file.</param>
        /// <param name="volume">The volume of the sound. A float between 0 and 1.</param>

        public Sound(string path, float volume)
        {
            this.path = path;
			try
			{
				_soundFile = new AudioFileReader(path);
				_outputDevice.Init(_soundFile);
				_isInitialized = true;
			}
			catch
			{
				_isInitialized = false;
			}
        }

        /// <summary>
        /// Plays the sound.
        /// </summary>
        public void Play()
        {
            if (!IsPlaying)
            {
                IsPlaying = true;
				if(_isInitialized)
                	_outputDevice.Play();
            }
        }

        /// <summary>
        /// Stops the sound.
        /// </summary>
        public void Stop()
        {
            if (_isInitialized)
                _outputDevice.Stop();
            _soundFile.Position = 0;
            IsPlaying = false;
        }

        /// <summary>
        /// Disposes the resources used by the sound.
        /// </summary>
        public void Dispose()
        {
            _outputDevice?.Dispose();
            _soundFile?.Dispose();
        }
    }
}
