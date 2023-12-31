﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LINDRailways.Model;
using LINDRailways.Services;
using LINDRailways.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINDRailways.ViewModel
{
    public partial class TicketsViewModel : BaseViewModel
    {
        public ObservableCollection<Ticket> Tickets { get; } = new();

        public TicketsViewModel()
        {
            Title = "Tickets";

            _ = GetTicketsAsync();
        }

        [ObservableProperty]
        private bool isRefreshing;

        [RelayCommand]
        private async Task GetTicketsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                Tickets.Clear();
                var tickets = await TicketService.GetTicketsAsync();

                foreach (Ticket ticket in tickets)
                {
                    Tickets.Add(ticket);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get tickets: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        private async Task GoToTicketDetailsAsync(Ticket ticket)
        {
            if (ticket is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(TicketDetailsPage)}",
                true, new Dictionary<string, object>
                {
                    { "Ticket", ticket }
                });
        }

        [RelayCommand]
        private async Task GoToAddTicketAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(AddTicketPage)}", true);
        }
    }
}
