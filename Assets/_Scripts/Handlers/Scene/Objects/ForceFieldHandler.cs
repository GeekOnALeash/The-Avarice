namespace com.ArkAngelApps.TheAvarice.Handlers.Scene.Objects
{
	public sealed class ForceFieldHandler : BarrierHandler
	{
		public override void OpenBarrier()
		{
			base.OpenBarrier();

			_barrierInteractionType = BarrierInteractionType.Disabled;
		}

		public override void CloseBarrier()
		{
			base.OpenBarrier();

			_barrierInteractionType = BarrierInteractionType.Locked;
		}
	}
}