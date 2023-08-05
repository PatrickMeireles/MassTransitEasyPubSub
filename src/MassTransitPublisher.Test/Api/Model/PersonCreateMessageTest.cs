namespace MassTransitPublisher.Test.Api.Model;

[TestClass]
public class PersonCreateMessageTest
{
    [TestMethod]
    public void Should_Create_New_PersonCreateMessage()
    {
        var data = new PersonCreateMessage()
        {
            Age = 10,
            Name = "Jhon"
        };

        Assert.IsNotNull(data);
        Assert.AreNotEqual(Guid.Empty, data.Id);
        Assert.AreEqual(10, data.Age);
        Assert.AreEqual("Jhon", data.Name);
    }
}
