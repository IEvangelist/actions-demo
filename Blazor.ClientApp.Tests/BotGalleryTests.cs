using Xunit;
using Bunit;
using Blazor.ClientApp.Pages;
using Microsoft.JSInterop;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.ClientApp.Tests;

public class BotGalleryTests : TestContext
{
    [Fact]
    public void VerifyBotGalleryRendering()
    {
        // Arrange
        JSInterop.Setup<string>(
            "window.localStorage.getItem", "bot-gallery-index")
            .SetResult("0");

        Services.AddSingleton<IJSInProcessRuntime>(
            sp => (IJSInProcessRuntime)sp.GetRequiredService<IJSRuntime>());

        // Act
        var cut = RenderComponent<BotGallery>(
            ComponentParameter.CreateParameter(
                "ImageNames",
                new[] { "test.png" }));

        // Assert
        cut.MarkupMatches(@"<div id=""gallery"" class=""carousel slide"" >
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
}