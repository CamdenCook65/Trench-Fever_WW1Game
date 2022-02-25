using System.Collections.Generic;
using UnityEditor;

namespace CafofoStudio
{
    [CustomEditor(typeof(HorrorAmbienceMixer))]
    public class HorrorAmbienceMixerEditor : AmbienceMixerEditor<HorrorAmbienceMixer, HorrorAmbiencePreset>
    {
        protected override List<string> GetSerializedElementProperties()
        {
            return new List<string>() { "_darkAmbience1", "_darkAmbience2", "_darkAmbience3", "_darkAmbience4", "_scaryPad1", "_scaryPad2", "_scaryPad3", "_scaryPad4", "_doomedVoices", "_rain", "_thunder", "_wind", "_woodCreak", "_fire" };
        }

        protected override void ApplyPreset(HorrorAmbiencePreset preset)
        {
            ApplyPresetConfig("_darkAmbience1", preset.darkAmbience1Intensity, preset.darkAmbience1VolumeMultiplier);
            ApplyPresetConfig("_darkAmbience2", preset.darkAmbience2Intensity, preset.darkAmbience2VolumeMultiplier);
            ApplyPresetConfig("_darkAmbience3", preset.darkAmbience3Intensity, preset.darkAmbience3VolumeMultiplier);
            ApplyPresetConfig("_darkAmbience4", preset.darkAmbience4Intensity, preset.darkAmbience4VolumeMultiplier);
            ApplyPresetConfig("_scaryPad1", preset.scaryPad1Intensity, preset.scaryPad1VolumeMultiplier);
            ApplyPresetConfig("_scaryPad2", preset.scaryPad2Intensity, preset.scaryPad2VolumeMultiplier);
            ApplyPresetConfig("_scaryPad3", preset.scaryPad3Intensity, preset.scaryPad3VolumeMultiplier);
            ApplyPresetConfig("_scaryPad4", preset.scaryPad4Intensity, preset.scaryPad4VolumeMultiplier);
            ApplyPresetConfig("_doomedVoices", preset.doomedVoicesIntensity, preset.doomedVoicesVolumeMultiplier);
            ApplyPresetConfig("_rain", preset.rainIntensity, preset.rainVolumeMultiplier);
            ApplyPresetConfig("_thunder", preset.thunderIntensity, preset.thunderVolumeMultiplier);
            ApplyPresetConfig("_wind", preset.windIntensity, preset.windVolumeMultiplier);
            ApplyPresetConfig("_woodCreak", preset.woodCreakIntensity, preset.woodCreakVolumeMultiplier);
            ApplyPresetConfig("_fire", preset.fireIntensity, preset.fireVolumeMultiplier);
        }

        protected override SoundElement GetSoundElementFromProperty(string propertyName)
        {
            switch (propertyName)
            {
                case "_darkAmbience1":
                    return myTarget.DarkAmbience1;
                case "_darkAmbience2":
                    return myTarget.DarkAmbience2;
                case "_darkAmbience3":
                    return myTarget.DarkAmbience3;
                case "_darkAmbience4":
                    return myTarget.DarkAmbience4;
                case "_scaryPad1":
                    return myTarget.ScaryPad1;
                case "_scaryPad2":
                    return myTarget.ScaryPad2;
                case "_scaryPad3":
                    return myTarget.ScaryPad3;
                case "_scaryPad4":
                    return myTarget.ScaryPad4;
                case "_doomedVoices":
                    return myTarget.DoomedVoices;
                case "_rain":
                    return myTarget.Rain;
                case "_thunder":
                    return myTarget.Thunder;
                case "_wind":
                    return myTarget.Wind;
                case "_fire":
                    return myTarget.Fire;
                default:
                    return myTarget.WoodCreak;
            }
        }

    }
}