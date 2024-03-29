﻿using Context.Interface;
using Entity.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Model.DetailsItem;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Xunit;
using static Test.Common.GenerateToken;

namespace Test.Integration
{
    public class MaterialTest : IClassFixture<WebApplicationFactory<Program>>, IDisposable
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
        protected readonly PotShopIDbContext _context;

        public MaterialTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("Test");
            });

            _context = _factory.Services.GetService<PotShopIDbContext>();

            _client = _factory.CreateClient();

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }


        [Fact]
        public async Task GetAllMaterials_ReturnAllMaterials()
        {

            var adminUser = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, "admin_username"),
                new Claim(ClaimTypes.Role, RoleString.Admin)
            }, "test"));
            var token = GenerateJwtTokenForUser(adminUser);

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {token}");

            // Act
            var response = await _client.GetAsync("/api/material");

            // Assert
            response.EnsureSuccessStatusCode();

            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<List<ReadMaterial>>>();

            // Vérifiez que la réponse contient la propriété "message" et la propriété "result"
            Assert.NotNull(apiResponse.Message);
            Assert.NotNull(apiResponse.Result);

        }

        /*[Fact]
        public async Task CreateMaterial_ReturnMaterial()
        {
            var newMaterial = new ReadMaterial { Id = 5,Label = "material_test",Description="description material_test"};
            var newMaterialJson = new StringContent(JsonSerializer.Serialize(newMaterial), Encoding.UTF8, "application/json");

            var adminUser = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, "admin_username"),
                new Claim(ClaimTypes.Role, RoleString.Admin)
            }, "test"));
            var token = GenerateJwtTokenForUser(adminUser);

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {token}");

            var response = await _client.PostAsync("/api/material/create", newMaterialJson);

            response.EnsureSuccessStatusCode();

            var createdMaterial = await response.Content.ReadFromJsonAsync<ReadMaterial>();
            Assert.NotNull(createdMaterial);
        }
        */

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
