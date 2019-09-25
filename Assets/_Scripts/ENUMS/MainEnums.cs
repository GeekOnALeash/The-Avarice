using System;

// ReSharper disable once CheckNamespace
namespace com.ArkAngelApps.UtilityLibraries.ENUMS
{
	/// <summary>
	/// Resource value label enum, to represent the resource current amount and its limit if one is set.
	/// </summary>
	[Flags]
	public enum Layers
	{
		// Values in tab manager
		Everything = -1,
		Nothing = 0,
		Default = 1 << 0,
		TransparentFX = 1 << 1,
		IgnoreRaycast = 1 << 2,
		Water = 1 << 4,
		UI = 1 << 5,

		ClickPlane = 1 << 8,
		Selectable = 1 << 9,
		NoLightMask = 1 << 10,
		PostProcessGlobal = 1 << 11,
		PostProcessStar = 1 << 12,
	}

	public enum DateType
	{
		Hour,
		Day,
		Month,
		Year
	}

	public enum GameSpeed
	{
		Slowest = 1,
		Slow,
		Normal,
		Fast,
		Fastest
	}

	public enum LabelType
	{
		Current,
		Limit
	}

	public enum WindowType
	{
		Info,
		Message,
		Keypad,
		Inventory
	}

	public enum MenuType
	{
		Main,
		Pause,
		Settings
	}

	public enum UIType
	{
		SystemName,
		Resource
	}

	public enum SelectableType
	{
		Planet,
		Tech
	}

	public enum StarType
	{
		RedGiant,
		RedDwarf,
		YelowGiant,
		YellowDwarf,
		BlueGiant,
		WhiteDwarf,
		BrownDwarf,
		SuperGiant,
		Pulsar,
		Neutron,
		BlackHole,
		Cepheid,
		Magnetar,
	}

	public enum StarCount
	{
		Unary,
		Binary,
		Ternary,
	}


	// http://phl.upr.edu/library/notes/amassclassificationforbothsolarandextrasolarplanets
	public enum PlanetSize
	{
		Asteroidan,
		Mercurian,
		Subterran,
		Terran,
		Superterran,
		Neptunian,
		Jovian,
	}

	public enum PlanetType
	{
		Temperate,
		Silicate,
		Puffy,
		Oceanic,
		Lava,
		Desert,
		Ice,
		Gas,
		Iron,
		Carbon,
		Protoplanet
	}
}
