using System;
using System.Collections.Generic;
using Xunit;
using ContactManager;

namespace ContactManagerTests
{
    public class ProgramTests
    {
        public ProgramTests()
        {
            Program.ClearContacts();
        }

        [Theory]
        [InlineData("Jafar Ramadan", "Friends")]
        [InlineData("Sami Ahmad", "Work")]
        public void AddContact_ShouldAddContact(string name, string category)
        {
            // Act
            var result = Program.AddContact(name, category);

            // Assert
            Assert.Contains(result, c => c.Name == name && c.Category == category);
        }

        [Theory]
        [InlineData("Abed Radwan", "Friends")]
        //[InlineData("Abed Radwan", "Work")]
        public void AddContact_ShouldThrowException_WhenContactIsDuplicate(string name, string category)
        {
            // Arrange
            Program.AddContact(name, category);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => Program.AddContact(name, category));
        }

        [Fact]
        public void RemoveContact_ShouldRemoveContact()
        {
            // Arrange
            var name = "Ibrahim Nimer";
            var category = "Friends";
            Program.AddContact(name, category);

            // Act
            var result = Program.RemoveContact(name);

            // Assert
            Assert.DoesNotContain(result, c => c.Name == name);
        }

        [Fact]
        public void RemoveContact_ShouldThrowException_WhenContactNotFound()
        {
            // Arrange
            var name = "Jamal Hasan";

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => Program.RemoveContact(name));
        }

        [Fact]
        public void ViewAllContacts_ShouldReturnAllContacts()
        {
            // Arrange
            var name1 = "Mohanad Hamdan";
            var category1 = "Family";
            var name2 = "Mohammad Hamdan";
            var category2 = "Family";
            var name3 = "Eyas Almasri";
            var category3 = "Work";
            Program.AddContact(name1, category1);
            Program.AddContact(name2, category2);
            Program.AddContact(name3, category3);

            // Act
            var result = Program.ViewAllContacts();

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Contains(result, c => c.Name == name1 && c.Category == category1);
            Assert.Contains(result, c => c.Name == name2 && c.Category == category2);
            Assert.Contains(result, c => c.Name == name3 && c.Category == category3);
        }

        [Fact]
        public void SearchContact_ShouldReturnContactDetails()
        {
            // Arrange
            var name = "Eyas Almasri";
            var category = "Work";
            Program.AddContact(name, category);

            // Act
            var result = Program.SearchContact(name);

            // Assert
            Assert.Equal("Eyas Almasri (Work)", result);
        }

        [Fact]
        public void SearchContact_ShouldReturnNotFoundMessage_WhenContactNotFound()
        {
            // Arrange
            var name = "Jamal Hasan";

            // Act
            var result = Program.SearchContact(name);

            // Assert
            Assert.Equal("Contact not found.", result);
        }
    }
}
