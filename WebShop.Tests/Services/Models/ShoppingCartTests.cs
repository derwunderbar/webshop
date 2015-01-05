using System;
using System.Linq;
using NUnit.Framework;
using WebShop.Services.Models.Shopping;

namespace WebShop.Tests.Services.Models
{
    [TestFixture]
    public class ShoppingCartTests
    {
        [Test]
        public void NewlyCreatedObject_HasEmptyItemsArray()
        {
            var shoppingCart = new ShoppingCart();

            Assert.That(shoppingCart.Items, Is.Not.Null);
            Assert.That(shoppingCart.Items, Is.Empty);
        }

        [Test]
        public void AddingItemsWithDifferentIds_ResultsInDifferentItems()
        {
            var shoppingCart = new ShoppingCart();

            shoppingCart.Add(1);
            shoppingCart.Add(2);

            Assert.That(shoppingCart.Items, Has.Length.EqualTo(2));
        }

        [Test]
        public void AddingItemsWithTheSameId_IncreaseCountForTheSameItem()
        {
            var shoppingCart = new ShoppingCart();

            shoppingCart.Add(1);
            shoppingCart.Add(1);
            shoppingCart.Add(1);
            shoppingCart.Add(1);

            Assert.That(shoppingCart.Items, Has.Length.EqualTo(1));
            Assert.That(shoppingCart.Items.Single().Count, Is.EqualTo(4));
        }

        [Test]
        public void RemovingItemsWithTheSameId_DecreaseCountForTheSameItem()
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.Add(1);
            shoppingCart.Add(1);
            shoppingCart.Add(1);
            shoppingCart.Add(1);

            shoppingCart.Remove(1);

            Assert.That(shoppingCart.Items, Has.Length.EqualTo(1));
            Assert.That(shoppingCart.Items.Single().Count, Is.EqualTo(3));
        }

        [Test]
        public void RemovingItem_ResultsInRemovingItem()
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.Add(1);
            shoppingCart.Add(2);

            shoppingCart.Remove(1);

            Assert.That(shoppingCart.Items.SingleOrDefault(a => a.Id == 1), Is.Null);
        }

        [Test]
        public void RemovingNotExistingItem_Fails()
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.Add(2);

            Assert.That(() => shoppingCart.Remove(1), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Clear_RemovesAllItems()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            shoppingCart.Add( 1 );
            shoppingCart.Add( 1 );
            shoppingCart.Add( 2 );

            // Act
            shoppingCart.Clear();

            // Verify
            Assert.That( shoppingCart.Items, Is.Empty );
        }
    }
}