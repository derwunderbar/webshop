using NUnit.Framework;
using WebShop.Services.Models;

namespace WebShop.Tests.Services.Models
{
    [TestFixture]
    public class ShoppingCartItemTests
    {
        [Test]
        public void ObjectsWithTheSameIdAndCount_AreEqual()
        {
            var left = new ShoppingCartItem() { Id = 2, Count = 5 };
            var right = new ShoppingCartItem() { Id = 2, Count = 5 };
            var isEqualUsingEqualsMethod = left.Equals(right);
            var isEqualUsingEqualityOperator = left == right;
            var isHashCodeEqual = left.GetHashCode() == right.GetHashCode();

            Assert.That(isEqualUsingEqualsMethod, Is.True);
            Assert.That(isEqualUsingEqualityOperator, Is.True);
            Assert.That(isHashCodeEqual, Is.True);
        }

        [Test]
        public void ObjectsWithTheSameIdButDifferentCount_AreNotEqual()
        {
            var left = new ShoppingCartItem() { Id = 10, Count = 3 };
            var right = new ShoppingCartItem() { Id = 10, Count = 7 };
            var isEqualUsingEqualsMethod = left.Equals( right );
            var isEqualUsingEqualityOperator = left == right;
            var isHashCodeEqual = left.GetHashCode() == right.GetHashCode();

            Assert.That( isEqualUsingEqualsMethod, Is.False );
            Assert.That( isEqualUsingEqualityOperator, Is.False );
            Assert.That( isHashCodeEqual, Is.False);
        }

        [Test]
        public void ObjectsWithDifferentIdButTheSameCount_AreNotEqual()
        {
            var left = new ShoppingCartItem() { Id = 5, Count = 4 };
            var right = new ShoppingCartItem() { Id = 6, Count = 4 };
            var isEqualUsingEqualsMethod = left.Equals( right );
            var isEqualUsingEqualityOperator = left == right;
            var isHashCodeEqual = left.GetHashCode() == right.GetHashCode();

            Assert.That( isEqualUsingEqualsMethod, Is.False );
            Assert.That( isEqualUsingEqualityOperator, Is.False );
            Assert.That( isHashCodeEqual, Is.False );
        }

        [Test]
        public void ObjectsWithDifferentIdAndCount_AreNotEqual()
        {
            var left = new ShoppingCartItem() { Id = 5, Count = 4 };
            var right = new ShoppingCartItem() { Id = 6, Count = 13 };
            var isEqualUsingEqualsMethod = left.Equals( right );
            var isEqualUsingEqualityOperator = left == right;
            var isHashCodeEqual = left.GetHashCode() == right.GetHashCode();

            Assert.That( isEqualUsingEqualsMethod, Is.False );
            Assert.That( isEqualUsingEqualityOperator, Is.False );
            Assert.That( isHashCodeEqual, Is.False );
        }

        [Test]
        public void ObjectAndItself_AreEqual()
        {
            var left = new ShoppingCartItem() { Id = 6, Count = 13 };
            var right = left;
            var isEqualUsingEqualsMethod = left.Equals( right );
            var isEqualUsingEqualityOperator = left == right;
            var isHashCodeEqual = left.GetHashCode() == right.GetHashCode();

            Assert.That( isEqualUsingEqualsMethod, Is.True );
            Assert.That( isEqualUsingEqualityOperator, Is.True );
            Assert.That( isHashCodeEqual, Is.True);
        }

        [Test]
        public void ObjectAndNull_AreNotEqual()
        {
            var left = new ShoppingCartItem() { Id = 6, Count = 13 };
            var right = (ShoppingCartItem)null;
            var isEqualUsingEqualsMethod = left.Equals( right );
            var isEqualUsingEqualityOperator = left == right;

            Assert.That( isEqualUsingEqualsMethod, Is.False );
            Assert.That( isEqualUsingEqualityOperator, Is.False);
        }
    }
}