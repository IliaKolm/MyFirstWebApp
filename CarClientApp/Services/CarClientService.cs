using CarClientApp.Data;
using CarClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarClientApp.Services;

public class CarClientService
{
    private readonly HttpClient _httpClient;

    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public CarClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Car>> GetCarAll()
    {
        var response = await _httpClient.GetAsync("/Car");
        var responseText = await response.Content.ReadAsStringAsync();

        var responseData = JsonSerializer.Deserialize<List<Car>>(responseText, _jsonOptions);

        return (responseData);
    }

    public async Task AddCar(CarAddDto request)
    {
        var response = await _httpClient.PutAsJsonAsync("/Car", request);

        return;
    }

    public async Task Remove(int id)
    {
        var response = await _httpClient.DeleteAsync($"/Car?carId={id}");

        return;
    }

    public async Task<Car> GetCarById(int id)
    {
        var response = await _httpClient.GetAsync($"/Car/{id}");
        var responseText = await response.Content.ReadAsStringAsync();

        var responseData = JsonSerializer.Deserialize<Car>(responseText, _jsonOptions);

        return responseData;
    }

    public async Task Edit(CarEditDto request)
    {
        var response = await _httpClient.PatchAsJsonAsync("/Car", request);

        return;
    }

    public async Task<List<Car>> SearchCars(string brand, string model)
    {
        var response = await _httpClient.PostAsync($"/Car?brand={brand}&model={model}", null);
        var responseText = await response.Content.ReadAsStringAsync();

        var responseData = JsonSerializer.Deserialize<List<Car>>(responseText, _jsonOptions);

        return responseData;
    }

    public async Task<List<Group>> GetGroupAll()
    {
        var response = await _httpClient.GetAsync("/Group");
        var responseText = await response.Content.ReadAsStringAsync();

        var responseData = JsonSerializer.Deserialize<List<Group>>(responseText, _jsonOptions);

        return responseData;
    }
}
