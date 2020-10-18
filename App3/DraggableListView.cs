using Android.Widget;
using Android.Views;
using Android.Content;
using Android.Util;
using System;

namespace App3
{
    public class DraggableListView : ListView
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
	}
}