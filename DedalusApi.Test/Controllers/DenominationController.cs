using DedalusApi.Controllers;
using DedalusApi.Dtos;
using DedalusApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DedalusApi.Test.Controllers;


public class DenominationControllerTests
{
    [Fact]
    public void Post_ReturnsOk()
    {
        var mockDto = new DenominationInput(Amount: It.IsAny<decimal>());
        var mockService = new Mock<IDenominationService>();
        mockService.Setup(service => service.Calculate(It.IsAny<decimal>())).Returns(It.IsAny<DenominationOutput[]>);
        var controller = new DenominationController(mockService.Object);

        var result = controller.Post(mockDto);

        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void Post_ReturnsBadRequest()
    {
        var mockDto = new DenominationInput(Amount: It.IsAny<decimal>());
        var mockService = new Mock<IDenominationService>();
        mockService.Setup(service => service.Calculate(It.IsAny<decimal>())).Throws<ArgumentException>();
        var controller = new DenominationController(mockService.Object);

        var result = controller.Post(mockDto);

        Assert.IsType<BadRequestObjectResult>(result.Result);
    }
}