using System;

namespace EasyButtons
{
	public enum ButtonMode
	{
		AlwaysEnabled,
		EnabledInPlayMode,
		DisabledInPlayMode
	}

	[Flags]
	public enum ButtonSpacing
	{
		None = 0,
		Before = 1,
		After = 2
	}

	[AttributeUsage(AttributeTargets.Method)]
	public sealed class ButtonAttribute : Attribute
	{
		private string _name;
		private ButtonMode _mode = ButtonMode.AlwaysEnabled;
		private ButtonSpacing _spacing = ButtonSpacing.None;

		public string Name => _name;

		public ButtonMode Mode => _mode;

		public ButtonSpacing Spacing => _spacing;

		public ButtonAttribute() { }

		public ButtonAttribute(string name) => _name = name;

		public ButtonAttribute(ButtonMode mode) => _mode = mode;

		public ButtonAttribute(ButtonSpacing spacing) => _spacing = spacing;

		public ButtonAttribute(string name, ButtonMode mode)
		{
			_name = name;
			_mode = mode;
		}

		public ButtonAttribute(string name, ButtonSpacing spacing)
		{
			_name = name;
			_spacing = spacing;
		}

		public ButtonAttribute(string name, ButtonMode mode, ButtonSpacing spacing)
		{
			_name = name;
			_mode = mode;
			_spacing = spacing;
		}
	}
}