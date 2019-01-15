using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;
using System.Collections.Generic;

namespace AssetGuard.Tests.Services.Tags
{
    public class TagGenerationServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly TagGenerationService _service;

        public TagGenerationServiceTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new TagGenerationService(_mockUow.Object);
        }

        [Fact]
        public async Task GenerateTag_ReturnsValidOutput()
        {
            var asset = new Asset { Id = 1, Name = "Laptop", SerialNumber = "SN123" };
            var assetRepo = new Mock<IRepository<Asset>>();
            assetRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(asset);

            var templateRepo = new Mock<IRepository<LabelTemplate>>();
            templateRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<LabelTemplate>
            {
                new LabelTemplate { Id = 1, IsDefault = true, IncludeQrCode = true, IncludeBarcode = true }
            });

            _mockUow.Setup(u => u.Repository<Asset>()).Returns(assetRepo.Object);
            _mockUow.Setup(u => u.Repository<LabelTemplate>()).Returns(templateRepo.Object);

            var result = await _service.GenerateTagAsync(new GenerateTagDto { AssetId = 1 });

            Assert.Equal(1, result.AssetId);
            Assert.Equal("Laptop", result.AssetName);
            Assert.Contains("AG-000001", result.BarcodeData);
            Assert.Contains("SN123", result.QrCodeData);
            Assert.Contains("<div class='asset-tag'>", result.HtmlContent);
        }

        [Fact]
        public async Task CreateTemplate_AddsEntity()
        {
            var repo = new Mock<IRepository<LabelTemplate>>();
            _mockUow.Setup(u => u.Repository<LabelTemplate>()).Returns(repo.Object);

            await _service.CreateTemplateAsync(new LabelTemplateDto { Name = "Default", Size = "Medium" });

            repo.Verify(r => r.AddAsync(It.Is<LabelTemplate>(t => t.Name == "Default")), Times.Once);
        }
    }
}
