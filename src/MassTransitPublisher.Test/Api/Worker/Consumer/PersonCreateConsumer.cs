using MassTransit;
using MassTransitPublisher.Api.Worker.Consumer;
using Microsoft.Extensions.Logging;
using Moq;

namespace MassTransitPublisher.Test.Api.Worker.Consumer;

[TestClass]
public class PersonCreateConsumerTest
{
    private Mock<ILogger<PersonCreateConsumer>> _mockLogger;
    private PersonCreateConsumer _consumer;

    [TestInitialize]
    public void Initialize()
    {
        _mockLogger = new();
        _consumer = new(_mockLogger.Object);
    }

    [TestMethod]
    public async void Should_Consume_Message()
    {
        var data = new PersonCreateMessage()
        {
            Age = 10,
            Name = "Jhon"
        };

        var mockContext = new Mock<ConsumeContext<PersonCreateMessage>>();

        mockContext.Setup(c => c.Message == data);

        await _consumer.Consume(mockContext.Object);

        _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals("Received Message", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);
    }
}
