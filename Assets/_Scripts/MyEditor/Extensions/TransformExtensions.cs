using UnityEngine;

// ReSharper disable CheckNamespace
namespace com.ArkAngelApps.UtilityLibraries.Extensions
{
	public static class TransformExtensions
	{
		public static void SetPositionX(this Transform _transform_, float _x_)
		{
			var position_ = _transform_.position;
			position_ = new Vector3(_x_, position_.y, position_.z);
			_transform_.position = position_;
		}

		public static void SetPositionY(this Transform _transform_, float _y_)
		{
			var position_ = _transform_.position;
			position_ = new Vector3(position_.x, _y_, position_.z);
			_transform_.position = position_;
		}

		public static void SetPositionZ(this Transform _transform_, float _z_)
		{
			var position_ = _transform_.position;
			position_ = new Vector3(position_.x, position_.y, _z_);
			_transform_.position = position_;
		}

		public static void SetPositionXy(this Transform _transform_, float _x_, float _y_)
		{
			_transform_.position = new Vector3(_x_, _y_, _transform_.position.z);
		}

		public static void SetPosition(this Transform _transform_, float _x_, float _y_, float _z_)
		{
			_transform_.position = new Vector3(_x_, _y_, _z_);
		}

		public static void SetLocalPositionX(this Transform _transform_, float _x_)
		{
			var localPosition_ = _transform_.localPosition;
			localPosition_ = new Vector3(_x_, localPosition_.y, localPosition_.z);
			_transform_.localPosition = localPosition_;
		}

		public static void SetLocalPositionY(this Transform _transform_, float _y_)
		{
			var localPosition_ = _transform_.localPosition;
			localPosition_ = new Vector3(localPosition_.x, _y_, localPosition_.z);
			_transform_.localPosition = localPosition_;
		}

		public static void SetLocalPositionZ(this Transform _transform_, float _z_)
		{
			var localPosition_ = _transform_.localPosition;
			localPosition_ = new Vector3(localPosition_.x, localPosition_.y, _z_);
			_transform_.localPosition = localPosition_;
		}

		public static void SetLocalPositionXy(this Transform _transform_, float _x_, float _y_)
		{
			_transform_.localPosition = new Vector3(_x_, _y_, _transform_.localPosition.z);
		}

		public static void SetLocalPosition(this Transform _transform_, float _x_, float _y_, float _z_)
		{
			_transform_.localPosition = new Vector3(_x_, _y_, _z_);
		}

		public static void SetAbsLocalPositionX(this Transform _transform_, float _x_)
		{
			var localPosition_ = _transform_.localPosition;
			
			if (_transform_.lossyScale.x > 0f) {
				localPosition_ = new Vector3(_x_, localPosition_.y, localPosition_.z);
				_transform_.localPosition = localPosition_;
			} else {
				localPosition_ = new Vector3(-_x_, localPosition_.y, localPosition_.z);
				_transform_.localPosition = localPosition_;
			}
		}

		public static void SetLocalScaleX(this Transform _transform_, float _x_)
		{
			var localScale_ = _transform_.localScale;
			localScale_ = new Vector3(_x_, localScale_.y, localScale_.z);
			_transform_.localScale = localScale_;
		}

		public static void SetLocalScale(this Transform _transform_, float _x_, float _y_, float _z_)
		{
			_transform_.localScale = new Vector3(_x_, _y_, _z_);
		}

		public static void SetAbsLocalScaleX(this Transform _transform_, float _x_)
		{
			var localScale_ = _transform_.localScale;
			
			if (_transform_.lossyScale.x > 0f) {
				localScale_ = new Vector3(_x_, localScale_.y, localScale_.z);
				_transform_.localScale = localScale_;
			} else {
				localScale_ = new Vector3(-_x_, localScale_.y, localScale_.z);
				_transform_.localScale = localScale_;
			}
		}
	}
}