﻿using System.Runtime.Versioning;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Handlers;
using CommunityToolkit.Maui.Views;

namespace CommunityToolkit.Maui;

/// <summary>
/// This class contains MediaElement's <see cref="MauiAppBuilder"/> extensions.
/// </summary>
[SupportedOSPlatform("iOS15.0")]
[SupportedOSPlatform("MacCatalyst15.0")]
[SupportedOSPlatform("Android26.0")]
[SupportedOSPlatform("Windows10.0.17763")]
[SupportedOSPlatform("Tizen6.5")]
public static class AppBuilderExtensions
{
	/// <summary>
	/// Initializes the .NET MAUI Community Toolkit MediaElement Library
	/// </summary>
	/// <param name="builder"><see cref="MauiAppBuilder"/> generated by <see cref="MauiApp"/>.</param>
	/// <param name="options"></param>
	/// <returns><see cref="MauiAppBuilder"/> initialized for <see cref="MediaElement"/>.</returns>
	public static MauiAppBuilder UseMauiCommunityToolkitMediaElement(this MauiAppBuilder builder, Action<MediaElementOptions>? options = null)
	{
		// Update the default MediaElementOptions for MediaElement if Action is not null
		options?.Invoke(new MediaElementOptions(builder));

		// Perform Handler configuration
		builder.ConfigureMauiHandlers(h =>
		{
			h.AddHandler<MediaElement, MediaElementHandler>();
		});

#if ANDROID
		builder.Services.AddSingleton<Media.Services.MediaControlsService>();
#endif

		return builder;
	}
}