namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        //The Pastures of Heaven, John Steinbeck
        [Test]
        public void BookCtorShouldWork()
        {
            Book book = new Book("The Lord of the Rings", "J.R.R.Tolkien");

            Assert.AreEqual("The Lord of the Rings", book.BookName);
            Assert.AreEqual("J.R.R.Tolkien", book.Author);
            Assert.AreEqual(0, book.FootnoteCount);
        }

        [Test]
        public void BookNameNullShouldThrowException()
        {
            string name = null;

            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(name, "J.R.R.Tolkien");
            });
        }

        [Test]
        public void BookNameEmptyShouldThrowException()
        {
            string name = string.Empty;

            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(name, "J.R.R.Tolkien");
            });
        }

        [Test]
        public void BookAuthorNullShouldThrowException()
        {
            string name = null;

            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("The Lord of the Rings", name);
            });
        }

        [Test]
        public void BookAuthorEmptyShouldThrowException()
        {
            string name = string.Empty;

            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("The Lord of the Rings", name);
            });
        }

        [Test]
        public void AddFootnoteShouldWork()
        {
            Book book = new Book("The Lord of the Rings", "J.R.R.Tolkien");
            book.AddFootnote(1, "footnote...");
            book.AddFootnote(2, "second footnote...");

            Assert.AreEqual(2, book.FootnoteCount);
        }

        [Test]
        public void AddFootnoteShouldThrowException()
        {
            Book book = new Book("The Lord of the Rings", "J.R.R.Tolkien");
            book.AddFootnote(1, "footnote...");
            book.AddFootnote(2, "second footnote...");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(2, "another footnote...");
            });
        }

        [Test]
        public void FindFootnoteShouldWork()
        {
            Book book = new Book("The Lord of the Rings", "J.R.R.Tolkien");
            book.AddFootnote(1, "footnote...");
            book.AddFootnote(2, "second footnote...");

            Assert.AreEqual(book.FindFootnote(1), "Footnote #1: footnote...");
        }

        [Test]
        public void FindFootnoteShouldThrowException()
        {
            Book book = new Book("The Lord of the Rings", "J.R.R.Tolkien");
            book.AddFootnote(1, "footnote...");
            book.AddFootnote(2, "second footnote...");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(3);
            });
        }

        [Test]
        public void AlterFootnoteShouldWork()
        {
            Book book = new Book("The Lord of the Rings", "J.R.R.Tolkien");
            book.AddFootnote(1, "footnote...");
            book.AddFootnote(2, "second footnote...");
            book.AlterFootnote(1, "new footnote...");

            Assert.AreEqual(book.FindFootnote(1), "Footnote #1: new footnote...");
        }

        [Test]
        public void AlterFootnoteShouldThrowException()
        {
            Book book = new Book("The Lord of the Rings", "J.R.R.Tolkien");
            book.AddFootnote(1, "footnote...");
            book.AddFootnote(2, "second footnote...");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(3, "new");
            });
        }
    }
}