namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {

        [Test]
        public void ConstructorShouldAddValidData()
        {
            Book book = new Book("Thinking, Fast and Slow", "Daniel Kahneman");

            Assert.AreEqual("Thinking, Fast and Slow", book.BookName);
            Assert.AreEqual("Daniel Kahneman", book.Author);
            Assert.AreEqual(0, book.FootnoteCount);
        }

        [Test]
        public void BookNameNullShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(null, "Daniel Kahneman");
            });
        }

        [Test]
        public void BookNameEmptyShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("", "Daniel Kahneman");
            });
        }

        [Test]
        public void AuthorNameNullShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("Thinking, Fast and Slow", null);
            });
        }

        [Test]
        public void AuthorNameEmptyShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("Thinking, Fast and Slow", "");
            });
        }

        [Test]
        public void AddFootnoteCounterShouldWorkProperly()
        {
            Book book = new Book("Thinking, Fast and Slow", "Daniel Kahneman");

            book.AddFootnote(1, "thinking...");
            book.AddFootnote(2, "fast...");
            book.AddFootnote(3, "slow...");

            Assert.AreEqual(3, book.FootnoteCount);
        }

        
        [Test]
        public void AddFootnoteWithSameNumberShouldThrowException()
        {
            Book book = new Book("Thinking, Fast and Slow", "Daniel Kahneman");

            book.AddFootnote(1, "thinking...");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(1, "fast...");
            });
        }

        [Test]
        public void FindFootnoteShouldWorkProperly()
        {
            Book book = new Book("Thinking, Fast and Slow", "Daniel Kahneman");

            book.AddFootnote(1, "thinking...");

            Assert.AreEqual("Footnote #1: thinking...", book.FindFootnote(1));
        }


        [Test]
        public void FindFootnoteWithNonExistingNumberShouldThrowException()
        {
            Book book = new Book("Thinking, Fast and Slow", "Daniel Kahneman");

            book.AddFootnote(1, "thinking...");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(2);
            });
        }

        [Test]
        public void AlterFootnoteShouldWorkProperly()
        {
            Book book = new Book("Thinking, Fast and Slow", "Daniel Kahneman");

            book.AddFootnote(1, "thinking...");
            book.AlterFootnote(1, "fast...");

            Assert.AreEqual("Footnote #1: fast...", book.FindFootnote(1));
        }

        [Test]
        public void AlterFootnoteWithNonExistNumberShouldThrowException()
        {
            Book book = new Book("Thinking, Fast and Slow", "Daniel Kahneman");

            book.AddFootnote(1, "thinking...");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(2, "fast...");
            });
        }

    }
}