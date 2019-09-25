using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Handlers.System
{
	public class UpdateEveryXFramesExample : MonoBehaviour
	{
		private const int Interval = 3;

		private void Update()
		{
			// ReSharper disable once SwitchStatementMissingSomeCases
			switch (Time.frameCount % Interval)
			{
				case 0:
					ExampleExpensiveFunction();
					break;
				case 1:
					AnotherExampleExpensiveFunction();
					break;
			}
		}

		private static void AnotherExampleExpensiveFunction() { }

		private static void ExampleExpensiveFunction() { }
	}
}