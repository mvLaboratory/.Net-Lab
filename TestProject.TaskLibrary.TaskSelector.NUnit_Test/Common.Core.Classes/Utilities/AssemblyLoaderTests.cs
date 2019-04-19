using Moq;
using NUnit.Framework;
using TestProject.Common.Core.Classes.Utilities;

namespace Tests.NUnit.TestProject.Common.Core.Classes.Utilities
{
  [TestFixture]
  public class AssemblyLoaderTests
  {
    [OneTimeSetUp]
    public void FixtureSetup()
    {
      _assemblyName = "TestProject.TaskLibrary";
    }

    [Test, Description("Test that the 'AssemblyName' property was settled up and the Load method was called with the right name!")]
    [TestCase("TestProject.TaskLibrary")]
    public void GetAssemblyName_FromConstructor(string expected)
    {
      //Arrange, //Act
      var loaderMock = new Mock<AssemblyLoader>(expected);
      loaderMock.Setup(loader => loader.Load(It.IsAny<string>()));

      var actualResult = loaderMock.Object.AssemblyName;

      //Assert
      Assert.AreEqual(expected, actualResult, "AssemblyName property was not initiated!");
      loaderMock.Verify(loader => loader.Load(It.Is<string>(val => val.Equals(expected))));
    }

    [Test, Description("Test if the real Assembly with the right name was loaded.")]
    public void GetAssemblyName_FromLoadedAssembly()
    {
      //Arrange, //Act
      var loader = new AssemblyLoader(_assemblyName);

      //Assert
      StringAssert.StartsWith(_assemblyName, loader.Assembly.FullName, "Assembly was not loaded properly!");
    }

    private string _assemblyName;
    //TODO:: Please do not use real system files in Unit tests (hardcoded File Names should be avoided in the Integration tests as well)
    //  = @"d:\!_Documents_!\_EPAM_\_Training_\GIT\Repository_Template\
    //    .Net-Lab\TestProject.TaskLibrary\bin\Debug\netcoreapp2.1\
    //    TestProject.TaskLibrary.dll"; 
    //"TestProject.TaskLibrary";
  }
}