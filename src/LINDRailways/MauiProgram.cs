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
            builder.Services.AddSingleton<AccountsViewModel>();
            builder.Services.AddSingleton<TrainSchedulesViewModel>();
            builder.Services.AddSingleton<TicketsViewModel>();

            builder.Services.AddTransient<AccountDetailsViewModel>();
            builder.Services.AddTransient<AddAccountViewModel>();
            builder.Services.AddTransient<TrainScheduleDetailsViewModel>();
            builder.Services.AddTransient<AddTicketViewModel>();
            builder.Services.AddTransient<TicketDetailsViewModel>();

            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<AccountsPage>();
            builder.Services.AddSingleton<TrainSchedulesPage>();
            builder.Services.AddSingleton<TicketsPage>();

            builder.Services.AddTransient<AccountDetailsPage>();
            builder.Services.AddTransient<AddAccountPage>();
            builder.Services.AddTransient<TrainScheduleDetailsPage>();
            builder.Services.AddTransient<AddTicketPage>();
            builder.Services.AddTransient<TicketDetailsPage>();

            return builder.Build();
        }
    }
}