using Xunit;
using Bunit;
using Blazor.ClientApp.Pages;
using Microsoft.JSInterop;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Collections.Generic;
using System;

namespace Blazor.ClientApp.Tests;

public class BotGalleryTests : TestContext
{
    [Fact]
    public void VerifyBotGalleryRendering()
    {
        // Arrange
        Services.AddSingleton<IStorage, TestStorage>();

        // Act
        var cut = RenderComponent<BotGallery>(
            ComponentParameter.CreateParameter(
                "ImageNames",
                new[] { "test.png" }));

        // Assert
        cut.MarkupMatches(@"<div class=""grid"" >
  <button type=""button"" class=""btn-close btn-close-white"" aria-label=""Close""  ></button>
  <div class=""code"" >
    <pre >localStorage.length: 0</pre>
  </div>
</div>
<div id=""gallery"" class=""carousel slide"" >
  <div class=""carousel-inner"" >
    <div class=""carousel-item active"" >
      <img class=""rounded mx-auto d-block img-dotnet-yellow-shadow"" src=""gallery/test.png"" alt="".NET bot image named test.png"" >
    </div>
  </div>
  <button class=""carousel-control-prev"" type=""button"" data-bs-target=""#gallery"" data-bs-slide=""prev""  >
    <span class=""carousel-control-prev-icon"" aria-hidden=""true"" ></span>
    <span class=""visually-hidden"" >Previous</span>
  </button>
  <button class=""carousel-control-next"" type=""button"" data-bs-target=""#gallery"" data-bs-slide=""next""  >
    <span class=""carousel-control-next-icon"" aria-hidden=""true"" ></span>
    <span class=""visually-hidden"" >Next</span>
  </button>
</div>");
    }

    internal class TestStorage : IStorage
    {
        private readonly Dictionary<string, string> _storage =
            new(StringComparer.OrdinalIgnoreCase);

        public double Length => _storage.Count;

        public void Clear() => _storage.Clear();

        public TResult? GetItem<TResult>(
            string key, JsonSerializerOptions? options = null) =>
            _storage.TryGetValue(key, out var value)
                ? JsonSerializer.Deserialize<TResult>(value.ToString(), options)
                : default;

        public string? Key(double index) => default;

        public void RemoveItem(string key) => _storage.Remove(key);

        public void SetItem<TArg>(
            string key, TArg value, JsonSerializerOptions? options = null) =>
            _storage[key] = JsonSerializer.Serialize(value, options);
    }
}