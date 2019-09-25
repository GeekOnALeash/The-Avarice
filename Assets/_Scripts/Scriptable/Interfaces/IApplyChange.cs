namespace com.ArkAngelApps.TheAvarice.Scriptable.Interfaces
{
	public interface IWithApplyChange<in T>
	{
		bool ApplyChange(T amount);
	}
}