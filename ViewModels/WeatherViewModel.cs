﻿using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using InterfazTicketsApp.Data;
using InterfazTicketsApp.Models;

namespace InterfazTicketsApp.ViewModels
{
    public class WeatherViewModel : BaseViewModel
    {
        private string _cityName;
        private string _weatherResult;
        private WeatherRecord _selectedWeatherRecord;
        private readonly HttpClient _httpClient;
        private readonly WeatherDatabase _weatherDatabase;

        public WeatherViewModel()
        {
            _httpClient = new HttpClient();
            _weatherDatabase = App.Database;
            SearchWeatherCommand = new Command(async () => await GetWeatherAsync());
            LoadWeatherRecordsCommand = new Command(async () => await LoadWeatherRecordsAsync());
            DeleteWeatherRecordCommand = new Command<WeatherRecord>(async (record) => await DeleteWeatherRecordAsync(record));
            WeatherRecords = new ObservableCollection<WeatherRecord>();
        }

        public string CityName
        {
            get => _cityName;
            set
            {
                _cityName = value;
                OnPropertyChanged();
            }
        }

        public string WeatherResult
        {
            get => _weatherResult;
            set
            {
                _weatherResult = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<WeatherRecord> WeatherRecords { get; }

        public WeatherRecord SelectedWeatherRecord
        {
            get => _selectedWeatherRecord;
            set
            {
                _selectedWeatherRecord = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchWeatherCommand { get; }
        public ICommand LoadWeatherRecordsCommand { get; }
        public ICommand DeleteWeatherRecordCommand { get; }

        private async Task GetWeatherAsync()
        {
            if (string.IsNullOrWhiteSpace(CityName))
            {
                WeatherResult = "Por favor, ingrese el nombre de una ciudad.";
                return;
            }

            string apiKey = "382177252d4cc43d39cae111ac5772c2";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={CityName}&appid={apiKey}&units=metric";

            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var weatherData = await response.Content.ReadFromJsonAsync<WeatherData>();
                if (weatherData != null)
                {
                    WeatherResult = $"Ciudad: {weatherData.Name}\n" +
                                    $"País: {weatherData.Sys.Country}\n" +
                                    $"Temperatura: {weatherData.Main.Temp}°C\n" +
                                    $"Clima: {weatherData.Weather[0].Description}";

                    var weatherRecord = new WeatherRecord
                    {
                        CityName = weatherData.Name,
                        Country = weatherData.Sys.Country,
                        Temperature = $"{weatherData.Main.Temp}°C",
                        Description = weatherData.Weather[0].Description,
                        Date = DateTime.Now
                    };

                    await _weatherDatabase.SaveWeatherRecordAsync(weatherRecord);
                    WeatherRecords.Add(weatherRecord);
                }
            }
            catch (HttpRequestException ex)
            {
                WeatherResult = $"Error al obtener el clima: {ex.Message}";
            }
            catch (Exception ex)
            {
                WeatherResult = $"Error: {ex.Message}";
            }
        }

        private async Task LoadWeatherRecordsAsync()
        {
            var records = await _weatherDatabase.GetWeatherRecordsAsync();
            WeatherRecords.Clear();
            foreach (var record in records)
            {
                WeatherRecords.Add(record);
            }
        }

        private async Task DeleteWeatherRecordAsync(WeatherRecord record)
        {
            await _weatherDatabase.DeleteWeatherRecordAsync(record);
            WeatherRecords.Remove(record);
        }
    }

    public class WeatherData
    {
        public string Name { get; set; }
        public Main Main { get; set; }
        public Weather[] Weather { get; set; }
        public Sys Sys { get; set; }
    }

    public class Main
    {
        public float Temp { get; set; }
    }

    public class Weather
    {
        public string Description { get; set; }
    }

    public class Sys
    {
        public string Country { get; set; }
    }
}