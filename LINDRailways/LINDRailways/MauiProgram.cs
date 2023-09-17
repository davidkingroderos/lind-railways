﻿using LINDRailways.View;
using LINDRailways.ViewModel;
using Microsoft.Extensions.Logging;

namespace LINDRailways
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<TrainSchedulesViewModel>();
            builder.Services.AddSingleton<TicketsViewModel>();
            builder.Services.AddSingleton<PendingTicketsViewModel>();

            builder.Services.AddTransient<AddTicketViewModel>();

            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<TicketsPage>();
            builder.Services.AddSingleton<TrainSchedulesPage>();
            builder.Services.AddSingleton<PendingTicketsPage>();

            builder.Services.AddTransient<AddTicketPage>();

            return builder.Build();
        }
    }
}