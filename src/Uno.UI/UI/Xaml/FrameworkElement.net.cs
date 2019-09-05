﻿using System;
using System.Collections.Generic;
using System.Linq;
using Uno.Disposables;
using System.Text;
using System.Threading.Tasks;
using Uno.Extensions;
using Uno;
using Uno.Logging;
using Windows.UI.Xaml.Controls;
using Windows.Foundation;
using View = Windows.UI.Xaml.UIElement;
using System.Collections;

namespace Windows.UI.Xaml
{
	public partial class FrameworkElement : IEnumerable
	{
		internal List<View> _children = new List<View>();

		partial void OnLoadingPartial();

		public View AddChild(View child)
		{
			_children.Add(child);
			OnAddChild(child);

			return child;
		}

		public View AddChild(View child, int index)
		{
			_children.Insert(index, child);
			OnAddChild(child);

			return child;
		}

		private void OnAddChild(View child)
		{
			child.SetParent(this);
			if (child is FrameworkElement fe)
			{
				fe.IsLoaded = IsLoaded;
				fe.EnterTree();
			}
		}

		public View RemoveChild(View child)
		{
			_children.Remove(child);
			child.SetParent(null);

			return child;
		}

		public View FindFirstChild()
		{
			return _children.FirstOrDefault();
		}

		public T FindFirstChild<T>()  where T : View
		{
			return _children.OfType<T>().FirstOrDefault<T>();
		}

		public virtual IEnumerable<View> GetChildren()
		{
			return _children;
		}

		public bool HasParent()
		{
			return Parent != null;
		}

		protected internal override void OnInvalidateMeasure()
		{
			InvalidateMeasureCallCount++;
			base.OnInvalidateMeasure();
		}

		partial void OnMeasurePartial(Size slotSize)
		{
			MeasureCallCount++;
			AvailableMeasureSize = slotSize;

			if (DesiredSizeSelector != null)
			{
				DesiredSize = DesiredSizeSelector(slotSize);
				RequestedDesiredSize = DesiredSize;
			}
			else if (RequestedDesiredSize != null)
			{
				DesiredSize = RequestedDesiredSize.Value;
			}
		}

		static partial void OnGenericPropertyUpdatedPartial(object dependencyObject, DependencyPropertyChangedEventArgs args);

		public bool IsLoaded { get; private set; }

		public void ForceLoaded()
		{
			IsLoaded = true;
			EnterTree();
		}

		private void EnterTree()
		{
			if (IsLoaded)
			{
				ApplyCompiledBindings();
				OnLoading();
				OnLoaded();

				foreach (var child in _children.OfType<FrameworkElement>())
				{
					child.IsLoaded = IsLoaded;
					child.EnterTree();
				}
			}
		}

		public int InvalidateMeasureCallCount { get; private set; }

		private bool IsTopLevelXamlView() => false;

		internal void SuspendRendering() => throw new NotSupportedException();

		internal void ResumeRendering() => throw new NotSupportedException();
		public IEnumerator GetEnumerator() => _children.GetEnumerator();

		public double ActualWidth => Arranged.Width;

		public double ActualHeight => Arranged.Height;
	}
}
