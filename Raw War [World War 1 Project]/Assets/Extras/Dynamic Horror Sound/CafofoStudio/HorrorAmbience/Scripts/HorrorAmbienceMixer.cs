using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CafofoStudio
{
	public class HorrorAmbienceMixer : AmbienceMixer<HorrorAmbiencePreset>
    {

		[SerializeField] private SoundElement _darkAmbience1;
		public SoundElement DarkAmbience1
		{
			get { return _darkAmbience1; }
			private set { _darkAmbience1 = DarkAmbience1; }
		}

		[SerializeField] private SoundElement _darkAmbience2;
		public SoundElement DarkAmbience2
		{
			get { return _darkAmbience2; }
			private set { _darkAmbience2 = DarkAmbience2; }
		}

        [SerializeField] private SoundElement _darkAmbience3;
        public SoundElement DarkAmbience3
        {
            get { return _darkAmbience3; }
            private set { _darkAmbience3 = DarkAmbience3; }
        }

        [SerializeField] private SoundElement _darkAmbience4;
        public SoundElement DarkAmbience4
        {
            get { return _darkAmbience4; }
            private set { _darkAmbience4 = DarkAmbience4; }
        }

        [SerializeField] private SoundElement _scaryPad1;
        public SoundElement ScaryPad1
        {
            get { return _scaryPad1; }
            private set { _scaryPad1 = ScaryPad1; }
        }

        [SerializeField] private SoundElement _scaryPad2;
        public SoundElement ScaryPad2
        {
            get { return _scaryPad2; }
            private set { _scaryPad2 = ScaryPad2; }
        }

        [SerializeField] private SoundElement _scaryPad3;
        public SoundElement ScaryPad3
        {
            get { return _scaryPad3; }
            private set { _scaryPad3 = ScaryPad3; }
        }

        [SerializeField] private SoundElement _scaryPad4;
        public SoundElement ScaryPad4
        {
            get { return _scaryPad4; }
            private set { _scaryPad4 = ScaryPad4; }
        }

        [SerializeField] private SoundElement _doomedVoices;
		public SoundElement DoomedVoices
		{
			get { return _doomedVoices; }
			private set { _doomedVoices = DoomedVoices; }
		}

		[SerializeField] private SoundElement _rain;
		public SoundElement Rain
		{
			get { return _rain; }
			private set { _rain = Rain; }
		}

		[SerializeField] private SoundElement _thunder;
		public SoundElement Thunder
		{
			get { return _thunder; }
			private set { _thunder = Thunder; }
		}

		[SerializeField] private SoundElement _wind;
		public SoundElement Wind
		{
			get { return _wind; }
			private set { _wind = Wind; }
		}

        [SerializeField] private SoundElement _woodCreak;
        public SoundElement WoodCreak
        {
            get { return _woodCreak; }
            private set { _woodCreak = WoodCreak; }
        }

        [SerializeField] private SoundElement _fire;
        public SoundElement Fire
        {
            get { return _fire; }
            private set { _fire = Fire; }
        }

        protected override List<SoundElement> elements {
			get {
				return new List<SoundElement>() { _darkAmbience1, _darkAmbience2, _darkAmbience3, _darkAmbience4, _scaryPad1, _scaryPad2, _scaryPad3, _scaryPad4,_doomedVoices, _rain, _thunder, _wind, _woodCreak, _fire};
			}
		}

		override public void ApplyPreset(HorrorAmbiencePreset selectedPreset) 
		{
			_darkAmbience1.SetIntensity (selectedPreset.darkAmbience1Intensity);
			_darkAmbience1.SetVolumeMultiplier (selectedPreset.darkAmbience1VolumeMultiplier);

			_darkAmbience2.SetIntensity (selectedPreset.darkAmbience2Intensity);
			_darkAmbience2.SetVolumeMultiplier (selectedPreset.darkAmbience2VolumeMultiplier);

            _darkAmbience3.SetIntensity(selectedPreset.darkAmbience3Intensity);
            _darkAmbience3.SetVolumeMultiplier(selectedPreset.darkAmbience3VolumeMultiplier);

            _darkAmbience4.SetIntensity(selectedPreset.darkAmbience4Intensity);
            _darkAmbience4.SetVolumeMultiplier(selectedPreset.darkAmbience4VolumeMultiplier);

            _scaryPad1.SetIntensity(selectedPreset.scaryPad1Intensity);
            _scaryPad1.SetVolumeMultiplier(selectedPreset.scaryPad1VolumeMultiplier);

            _scaryPad2.SetIntensity(selectedPreset.scaryPad2Intensity);
            _scaryPad2.SetVolumeMultiplier(selectedPreset.scaryPad2VolumeMultiplier);

            _scaryPad3.SetIntensity(selectedPreset.scaryPad3Intensity);
            _scaryPad3.SetVolumeMultiplier(selectedPreset.scaryPad3VolumeMultiplier);

            _scaryPad4.SetIntensity(selectedPreset.scaryPad4Intensity);
            _scaryPad4.SetVolumeMultiplier(selectedPreset.scaryPad4VolumeMultiplier);

            _doomedVoices.SetIntensity(selectedPreset.doomedVoicesIntensity);
			_doomedVoices.SetVolumeMultiplier(selectedPreset.doomedVoicesVolumeMultiplier);

			_rain.SetIntensity (selectedPreset.rainIntensity);
			_rain.SetVolumeMultiplier (selectedPreset.rainVolumeMultiplier);

			_thunder.SetIntensity(selectedPreset.thunderIntensity);
			_thunder.SetVolumeMultiplier(selectedPreset.thunderVolumeMultiplier);

			_wind.SetIntensity(selectedPreset.windIntensity);
			_wind.SetVolumeMultiplier(selectedPreset.windVolumeMultiplier);

			_woodCreak.SetIntensity(selectedPreset.woodCreakIntensity);
			_woodCreak.SetVolumeMultiplier(selectedPreset.woodCreakVolumeMultiplier);

            _fire.SetIntensity(selectedPreset.fireIntensity);
            _fire.SetVolumeMultiplier(selectedPreset.fireVolumeMultiplier);
        }

    }
}