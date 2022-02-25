using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CafofoStudio
{
    [CreateAssetMenu(fileName = "MyHorrorAmbiencePreset", menuName = "CafofoStudio/Create Custom Preset Asset/Horror", order = 1)]
	public class HorrorAmbiencePreset : AmbientPreset
    {
		[Range(0, 1)] public float darkAmbience1Intensity = 0f;
		[Range(0, 1)] public float darkAmbience1VolumeMultiplier = 1f;

		[Range(0, 1)] public float darkAmbience2Intensity = 0f;
		[Range(0, 1)] public float darkAmbience2VolumeMultiplier = 1f;

        [Range(0, 1)] public float darkAmbience3Intensity = 0f;
        [Range(0, 1)] public float darkAmbience3VolumeMultiplier = 1f;

        [Range(0, 1)] public float darkAmbience4Intensity = 0f;
        [Range(0, 1)] public float darkAmbience4VolumeMultiplier = 1f;

        [Range(0, 1)] public float scaryPad1Intensity = 0f;
        [Range(0, 1)] public float scaryPad1VolumeMultiplier = 1f;

        [Range(0, 1)] public float scaryPad2Intensity = 0f;
        [Range(0, 1)] public float scaryPad2VolumeMultiplier = 1f;

        [Range(0, 1)] public float scaryPad3Intensity = 0f;
        [Range(0, 1)] public float scaryPad3VolumeMultiplier = 1f;

        [Range(0, 1)] public float scaryPad4Intensity = 0f;
        [Range(0, 1)] public float scaryPad4VolumeMultiplier = 1f;

        [Range(0, 1)] public float doomedVoicesIntensity = 0f;
		[Range(0, 1)] public float doomedVoicesVolumeMultiplier = 1f;

		[Range(0, 1)] public float rainIntensity = 0f;
		[Range(0, 1)] public float rainVolumeMultiplier = 1f;

		[Range(0, 1)] public float thunderIntensity = 0f;
		[Range(0, 1)] public float thunderVolumeMultiplier = 1f;

		[Range(0, 1)] public float windIntensity = 0f;
		[Range(0, 1)] public float windVolumeMultiplier = 1f;

		[Range(0, 1)] public float woodCreakIntensity = 0f;
		[Range(0, 1)] public float woodCreakVolumeMultiplier = 1f;

        [Range(0, 1)] public float fireIntensity = 0f;
        [Range(0, 1)] public float fireVolumeMultiplier = 1f;
    }
}