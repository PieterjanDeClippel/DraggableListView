using Android.Widget;
using Android.Animation;
using Android.Views;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Content;
using Android.Util;
using System;

namespace App3
{
	public class DraggableListView : ListView, ITypeEvaluator, GestureDetector.IOnGestureListener
	{
		///
		/// Constructors
		///
		public DraggableListView(Context context) : base(context)
		{
		}

		public DraggableListView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
		{
		}

		public DraggableListView(Context context, IAttributeSet attrs) : base(context, attrs)
		{
		}

		#region IOnGestureListener Implementation

		public bool OnDown(MotionEvent e)
		{
			return true;
		}

		/// <summary>
		/// Determines if the touch event was right or left swipe
		/// </summary>
		public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
		{
			return false;
		}

		public bool OnSingleTapUp(MotionEvent e)
		{
			return false;
		}

		public void OnLongPress(MotionEvent e)
		{
		}

		public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
		{
			return false;
		}

		public void OnShowPress(MotionEvent e)
		{
		}

		#endregion

		/// <summary>
		/// Gets data related to touch events, moves the bitmap drawable to location of touch, and calls the HandleCellSwitch method to animate cell swaps
		/// </summary>
		public override bool OnTouchEvent(MotionEvent e)
		{
			try
			{
				switch (e.Action)
				{
					case MotionEventActions.Down:
						Console.WriteLine("down");
						break;
					case MotionEventActions.Move:
						Console.WriteLine("move");
						break;
					case MotionEventActions.Up:
						Console.WriteLine("up");
						break;
					case MotionEventActions.Cancel:
						Console.WriteLine("cancel");
						break;
					default:
						break;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error Processing OnTouchEvent in DynamicListView.cs - Message: {0}", ex.Message);
				Console.WriteLine("Error Processing OnTouchEvent in DynamicListView.cs - Stacktrace: {0}", ex.StackTrace);
			}

			return base.OnTouchEvent(e);
		}

		/// <summary>
		/// By Implementing the ITypeEvaluator Inferface, we are able to set this as the the ITypeEvaluator for the hoverViewAnimator
		/// This method is responsible for animating the drawable to its final location after touch events end.
		/// </summary>
		public Java.Lang.Object Evaluate(float fraction, Java.Lang.Object startValue, Java.Lang.Object endValue)
		{
			var startValueRect = startValue as Rect;
			var endValueRect = endValue as Rect;

			return new Rect(Interpolate(startValueRect.Left, endValueRect.Left, fraction),
				Interpolate(startValueRect.Top, endValueRect.Top, fraction),
				Interpolate(startValueRect.Right, endValueRect.Right, fraction),
				Interpolate(startValueRect.Bottom, endValueRect.Bottom, fraction));
		}
		public int Interpolate(int start, int end, float fraction)
		{
			return (int)(start + fraction * (end - start));
		}
	}
}