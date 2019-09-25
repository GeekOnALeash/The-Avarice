using com.ArkAngelApps.TheAvarice.Helpers;

namespace com.ArkAngelApps.TheAvarice.Handlers.Scene.Objects
{
	public enum InteractionType
	{
		Trigger,
		Interaction,
		Locked,
		Disabled
	}

	internal sealed class BarrierInteractionType : Enumeration
	{
		// ReSharper disable InconsistentNaming
		internal static readonly BarrierInteractionType Trigger = new BarrierInteractionType(0, "Trigger");
		internal static readonly BarrierInteractionType Interaction = new BarrierInteractionType(1, "Interaction");
		internal static readonly BarrierInteractionType Locked = new BarrierInteractionType(2, "Locked");
		internal static readonly BarrierInteractionType Disabled = new BarrierInteractionType(3, "Disabled");

		private BarrierInteractionType(int value, string displayName) : base(value, displayName) { }
	}
}