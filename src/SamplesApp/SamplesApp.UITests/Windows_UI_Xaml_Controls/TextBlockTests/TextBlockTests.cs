﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SamplesApp.UITests.TestFramework;
using Uno.UITest.Helpers;
using Uno.UITest.Helpers.Queries;

namespace SamplesApp.UITests.Windows_UI_Xaml_Controls
{
	[TestFixture]
	public class TextBlockTests : SampleControlUITestBase
	{
		[Test]
		[AutoRetry]
		public void When_Visibility_Changed_During_Arrange()
		{
			Run("UITests.Shared.Windows_UI_Xaml_Controls.TextBlockControl.TextBlock_Visibility_Arrange");

			var textBlock = _app.Marked("SubjectTextBlock");

			_app.WaitForElement(textBlock);

			_app.WaitForDependencyPropertyValue(textBlock, "Text", "It worked!");
		}

		[Test]
		[AutoRetry]
		public void When_Multiple_Controls_And_Some_Are_Collapsed_Arrange()
		{
			Run("UITests.Shared.Windows_UI_Xaml_Controls.TextBlockControl.TextBlock_LineHeight_MultipleControls");

			var leftControls = new[]
			{
				_app.Marked("stackPanel1"), _app.Marked("txt1_1"), _app.Marked("rect1"), _app.Marked("txt1_2")
			};

			var rightControls = new[]
			{
				_app.Marked("stackPanel2"), _app.Marked("txt2_1"), _app.Marked("rect2"), _app.Marked("txt2_2")
			};

			_app.WaitForElement(rightControls.Last());

			for (var i = 0; i < leftControls.Length; i++)
			{
				var left = leftControls[i].FirstResult().Rect;
				var right = rightControls[i].FirstResult().Rect;

				left.Width.Should().Be(right.Width, "Width");
				left.Height.Should().Be(right.Height, "Height");
				left.Y.Should().Be(right.Y, "Y position");
			}
		}
	}
}
