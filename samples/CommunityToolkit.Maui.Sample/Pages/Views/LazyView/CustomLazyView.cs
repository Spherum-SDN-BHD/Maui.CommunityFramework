﻿using CommunityToolkit.Maui.Markup;

namespace CommunityToolkit.Maui.Sample.Pages.Views.LazyView;

public partial class CustomLazyView<TView> : Maui.Views.LazyView where TView : View, new()
{
	public override async ValueTask LoadViewAsync(CancellationToken token = default)
	{
		// display a loading indicator
		Content = new ActivityIndicator { IsRunning = true }.Center();

		// simulate a long running task
		await Task.Delay(3000, token);

		// load the view
		Content = new TView { BindingContext = BindingContext };

		SetHasLazyViewLoaded(true);
	}
}