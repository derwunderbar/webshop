using System;
using NUnit.Framework;
using WebShop.Services.Models.Shopping;

namespace WebShop.Tests.Services.Models
{
    [TestFixture]
    public class ShoppingCartItemsEqualityComparerTests
    {
        [Test]
        public void ArraysWithTheSameSingleElement_AreEqual()
        {
            var left = new[]
            {
                new ShoppingCartItem(){Id = 3, Count = 1},
            };

            var right = new[]
            {
                new ShoppingCartItem(){Id = 3, Count = 1},
            };

            var equalityComparer = new ShoppingCartItemsEqualityComparer();
            var isEqual = equalityComparer.Equals(left, right);
            var isHashCodeEqual = equalityComparer.GetHashCode(left) == equalityComparer.GetHashCode(right);
            
            Assert.That(isEqual, Is.True);
            Assert.That(isHashCodeEqual, Is.True);
        }

        [Test]
        public void ArraysWithTheSameElements_AreEqual()
        {
            var left = new[]
            {
                new ShoppingCartItem(){Id = 3, Count = 1},
                new ShoppingCartItem(){Id = 1, Count = 3},
                new ShoppingCartItem(){Id = 6, Count = 1},
            };

            var right = new[]
            {
                new ShoppingCartItem(){Id = 3, Count = 1},
                new ShoppingCartItem(){Id = 1, Count = 3},
                new ShoppingCartItem(){Id = 6, Count = 1},
            };

            var equalityComparer = new ShoppingCartItemsEqualityComparer();
            var isEqual = equalityComparer.Equals( left, right );
            var isHashCodeEqual = equalityComparer.GetHashCode( left ) == equalityComparer.GetHashCode( right );

            Assert.That( isEqual, Is.True );
            Assert.That( isHashCodeEqual, Is.True );
        }

        [Test]
        public void EmptyArrays_AreEqual()
        {
            var left = new ShoppingCartItem[] { };
            var right = new ShoppingCartItem[] { };

            var equalityComparer = new ShoppingCartItemsEqualityComparer();
            var isEqual = equalityComparer.Equals( left, right );
            var isHashCodeEqual = equalityComparer.GetHashCode( left ) == equalityComparer.GetHashCode( right );

            Assert.That( isEqual, Is.True );
            Assert.That( isHashCodeEqual, Is.True );
        }

        

        [Test]
        public void ArraysWithDifferentSingleElement_AreNotEqual()
        {
            var left = new[]
            {
                new ShoppingCartItem(){Id = 3, Count = 1},
            };

            var right = new[]
            {
                new ShoppingCartItem(){Id = 6, Count = 1},
            };

            var equalityComparer = new ShoppingCartItemsEqualityComparer();
            var isEqual = equalityComparer.Equals( left, right );
            var isHashCodeEqual = equalityComparer.GetHashCode( left ) == equalityComparer.GetHashCode( right );

            Assert.That( isEqual, Is.False );
            Assert.That( isHashCodeEqual, Is.False );
        }

        [Test]
        public void ArraysWithOneDifferentElement_AreNotEqual()
        {
            var left = new[]
            {
                new ShoppingCartItem(){Id = 6, Count = 1},
                new ShoppingCartItem(){Id = 3, Count = 5},
                new ShoppingCartItem(){Id = 2, Count = 2},
            };

            var right = new[]
            {
                new ShoppingCartItem(){Id = 6, Count = 1},
                new ShoppingCartItem(){Id = 3, Count = 4},
                new ShoppingCartItem(){Id = 2, Count = 2},
            };

            var equalityComparer = new ShoppingCartItemsEqualityComparer();
            var isEqual = equalityComparer.Equals( left, right );
            var isHashCodeEqual = equalityComparer.GetHashCode( left ) == equalityComparer.GetHashCode( right );

            Assert.That( isEqual, Is.False );
            Assert.That( isHashCodeEqual, Is.False );
        }

        [Test]
        public void ArrayAndNull_AreNotEqual()
        {
            var left = new ShoppingCartItem[] { };
            var right = (ShoppingCartItem[])null;

            var equalityComparer = new ShoppingCartItemsEqualityComparer();
            var isEqual = equalityComparer.Equals( left, right );
            
            Assert.That( isEqual, Is.False );
            Assert.That(()=>equalityComparer.GetHashCode(right), Throws.Exception.TypeOf<ArgumentNullException>());
        }


        [Test]
        public void ArraysWithMoreThanOneTheSameElements_Fails()
        {
            var left = new[]
            {
                new ShoppingCartItem(){Id = 6, Count = 1},
                new ShoppingCartItem(){Id = 3, Count = 5},
                new ShoppingCartItem(){Id = 2, Count = 2},
            };

            var right = new[]
            {
                new ShoppingCartItem(){Id = 6, Count = 1},
                new ShoppingCartItem(){Id = 3, Count = 5},
                new ShoppingCartItem(){Id = 3, Count = 5},
            };

            var equalityComparer = new ShoppingCartItemsEqualityComparer();
            Assert.That(()=>equalityComparer.Equals( left, right ), Throws.Exception.TypeOf<InvalidOperationException>());
        }
    }
}