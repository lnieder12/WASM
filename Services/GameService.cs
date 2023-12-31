﻿using System.Net.Http.Json;
using StarWars.Model;

namespace WASM.Services
{
    public class GameService
    {
        private readonly HttpClient _httpClient;

        public GameService()
        {
            _httpClient = new HttpClient{BaseAddress = new Uri("https://localhost:7038/") };
        }

        public Task<Game?> Get(int id)
        {
            // Méthode proposé par Microsoft pour Blazor WASM
            // Applicable aussi pour Blazor Server
            return _httpClient.GetFromJsonAsync<Game>($"/game/{id}");
        }

        public Task<List<Game>?> GetAll()
        {
            return _httpClient.GetFromJsonAsync<List<Game>>("/game");
        }

        public Task<Round?> Fight(int id)
        {
            return _httpClient.GetFromJsonAsync<Round>($"/game/{id}/fight");
        }
    }
}
