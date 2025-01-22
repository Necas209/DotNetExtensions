using DotNetExtensions;

namespace DotNetExtensionsTests;

[TestClass]
public class DictionaryExtensionsTests
{
    [TestMethod]
    public void TestGetOrAddNewKey()
    {
        // Arrange
        var dictionary = new Dictionary<string, int>();
        const string key = "newKey";
        const int valueToAdd = 42;

        // Act
        var result = dictionary.GetOrAdd(key, valueToAdd);

        // Assert
        Assert.IsTrue(dictionary.ContainsKey(key), "The key should be added to the dictionary.");
        Assert.AreEqual(valueToAdd, dictionary[key], "The value associated with the key should be the value provided.");
        Assert.AreEqual(valueToAdd, result, "The returned value should match the value added to the dictionary.");
    }

    [TestMethod]
    public void TestGetOrAddExistingKey()
    {
        // Arrange
        var dictionary = new Dictionary<string, int> { { "existingKey", 100 } };
        const string key = "existingKey";
        const int valueToAdd = 42; // This value should not be used since the key already exists.

        // Act
        var result = dictionary.GetOrAdd(key, valueToAdd);

        // Assert
        Assert.AreEqual(100, dictionary[key], "The value in the dictionary should remain unchanged.");
        Assert.AreEqual(100, result, "The returned value should be the value already in the dictionary.");
    }

    [TestMethod]
    public void TestTryUpdateExistingKey()
    {
        // Arrange
        var dictionary = new Dictionary<string, int> { { "existingKey", 100 } };
        const string key = "existingKey";
        const int newValue = 200;

        // Act
        var result = dictionary.TryUpdate(key, newValue);

        // Assert
        Assert.IsTrue(result, "The method should return true for an existing key.");
        Assert.AreEqual(newValue, dictionary[key], "The value in the dictionary should be updated to the new value.");
    }

    [TestMethod]
    public void TestTryUpdateNonExistingKey()
    {
        // Arrange
        var dictionary = new Dictionary<string, int>();
        const string key = "nonExistingKey";
        const int value = 42;

        // Act
        var result = dictionary.TryUpdate(key, value);

        // Assert
        Assert.IsFalse(result, "The method should return false for a non-existing key.");
        Assert.IsFalse(dictionary.ContainsKey(key), "The dictionary should remain unchanged for a non-existing key.");
    }
}