using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalShelter.Models;

namespace AnimalShelter.Tests
{
  [TestClass]
  public class AnimalTests : IDisposable
  {
      public void Dispose()
      {
          Animal.DeleteAll();
      }
      public AnimalTests()
      {
          DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=animal_shelter_test;";
      }
  }
}
