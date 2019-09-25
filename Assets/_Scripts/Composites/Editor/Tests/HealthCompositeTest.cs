using com.ArkAngelApps.TheAvarice.Scriptable.Events;
using com.ArkAngelApps.TheAvarice.Scriptable.Variables.Int;
using NUnit.Framework;
using UnityEngine;

namespace com.ArkAngelApps.TheAvarice.Composites.Editor.Tests
{
	public sealed class HealthCompositeTest
	{
		private const int StartingHealth = 10;
		private const int MaxValue = 20;
		private HealthComposite _healthComposite;

		[SetUp]
		public void SetUp()
		{
			_healthComposite = new HealthComposite(new IntVariable_Health())
			                   {
				                   events =
				                   {
					                   healthIncreased = ScriptableObject.CreateInstance<GameEvent>(),
					                   takesDamage = ScriptableObject.CreateInstance<GameEvent>(),
					                   die = ScriptableObject.CreateInstance<GameEvent>(),
					                   healthLow = ScriptableObject.CreateInstance<GameEvent>()
				                   }
			                   };

			_healthComposite.HealthData.MaxValue = MaxValue;
		}

		[Test]
		public void HealthCanBeUpdatedTest()
		{
			_healthComposite.SetHealth(StartingHealth);
			Assert.That(_healthComposite.GetHealth(), Is.EqualTo(StartingHealth));
		}

		[Test]
		public void HealthCanBeDecreasedTest()
		{
			_healthComposite.SetHealth(StartingHealth);
			_healthComposite.TakeDamage(5);
			Assert.AreEqual(5, _healthComposite.GetHealth());
		}

		[Test]
		public void HealthDecreasedByLessThanCurrentAndDidNotDie()
		{
			_healthComposite.SetHealth(StartingHealth);
			_healthComposite.TakeDamage(5);
			Assert.That(_healthComposite.IsDead, Is.False);
		}

		[Test]
		public void HealthDecreaseByMoreThanCurrentAndIsDead()
		{
			_healthComposite.SetHealth(StartingHealth);
			_healthComposite.TakeDamage(10);
			Assert.IsTrue(_healthComposite.IsDead);
		}

		[TestCase(150, 0)]
		[TestCase(200, 0)]
		public void HealthCannotGoNegativeTest(int amount, int expected)
		{
			_healthComposite.SetHealth(StartingHealth);
			_healthComposite.TakeDamage(amount);
			Assert.AreEqual(expected, _healthComposite.GetHealth());
		}

		[TestCase(150, 100)]
		[TestCase(200, 100)]
		public void HealthCannotExceedMaxValueTest(int amount, int expected)
		{
			_healthComposite.HealthData.MaxValue = expected;
			_healthComposite.SetHealth(amount);
			Assert.AreEqual(expected, _healthComposite.GetHealth());
		}


		public void HealthUpdatedEventMock()
		{
			Debug.Log("Health Updated Event Mock");
		}

		public void DeadEventMock()
		{
			Debug.Log("Dead Event Mock");
		}
	}
}
