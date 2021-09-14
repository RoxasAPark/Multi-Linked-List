using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLinkedListOfBooks
{
    class Program
    {
        // Class representing a Book in a linked list
        class Book
        {
            // Instance variables represent details about the book
            // Which include title, author, and price
            private string title;
            private string author;
            private int price;

            // Pointers to the next book based on author or by title
            public Book nextByAuthor;
            public Book nextByTitle;

            // Constructor to build a book object
            public Book(string t, string a, int p)
            {
                title = t;
                author = a;
                price = p;

                nextByAuthor = null;
                nextByTitle = null;
            }

            // Function that allows the user to know the title of the book
            public string getTitle()
            {
                return this.title;
            }

            // Function that allows the user to know the author who wrote the book
            public string getAuthor()
            {
                return this.author;
            }

            // Function that allows the user to know how much the book costs
            public int getPrice()
            {
                return this.price;
            }
        }

        // Class representing the multi linked list of books
        class MultiLinkedList
        {
            // Instance variables representing the first book in the list
            // Based on either the title or the author
            private Book firstByTitle;
            private Book firstByAuthor;

            // Constructor to initialize the object as an empty list
            public MultiLinkedList()
            {
                firstByAuthor = null;
                firstByTitle = null;
            }


            // Function to add a book to the multi linked list
            // based on both the author and the title of the book
            public void Add(string bookTitle, string bookAuthor, int bookPrice)
            {
                AddByTitle(bookTitle, bookAuthor, bookPrice);
                AddByAuthor(bookTitle, bookAuthor, bookPrice);
            }

            // Function to detect duplicates
            // If 2 books have the same author and title regardless of price, it's a duplicate
            public bool duplicateFound(Book thisBook, Book otherBook)
            {
                int compareTitle = thisBook.getTitle().CompareTo(otherBook.getTitle());
                int compareAuthor = thisBook.getAuthor().CompareTo(otherBook.getAuthor());

                return (compareTitle == 0 && compareAuthor == 0);
            }

            // Add the book to the list in an alphabetical order based on the title of the book
            public void AddByTitle(string bookTitle, string bookAuthor, int bookPrice)
            {
                // If the list is empty, the new book is the first one in the list
                if (firstByTitle == null)
                    firstByTitle = new Book(bookTitle, bookAuthor, bookPrice);
                else
                {
                    Book newBook = new Book(bookTitle, bookAuthor, bookPrice);

                    int compareWithFirstBook = newBook.getTitle().CompareTo(firstByTitle.getTitle());

                    // Compare the first book with the new book to add
                    if (compareWithFirstBook < 0)
                    {
                            // Perform the insertion only if the new book
                            // Comes before the first one
                            Book temp = firstByTitle;
                            newBook.nextByTitle = temp;
                            firstByTitle = newBook;
                    }
                    else
                    {
                        Book current = firstByTitle;
                        bool duplicateExists = false;

                        // Traverse through the list
                        while (current.nextByTitle != null)
                        {
                            // If a duplicate exists, there's no need to traverse the list
                            // Since the insertion won't happen anyways
                            if(duplicateFound(newBook, current) == true)
                            {
                                duplicateExists = true;
                                break;
                            }

                            // Traverse to the correct location based on the title of the book
                            // in alphabetical order (if no duplicates exist of course)
                            if (newBook.getTitle().CompareTo(current.nextByTitle.getTitle()) >= 0)
                                current = current.nextByTitle;
                            else
                                break;
                        }

                        // Only insert the book if the traversal of the list identified no duplicates 
                        if (duplicateExists == false)
                        {
                            Book temp = current.nextByTitle;
                            newBook.nextByTitle = temp;
                            current.nextByTitle = newBook;
                        }
                        else
                            Console.WriteLine(newBook.getTitle() + " by " +
                                newBook.getAuthor() + " already exists. Insert by title failed.");
                    }

                }
            }

            // Same logic as addByTitle but adds the book to the list alphabetically based on the author's name
            public void AddByAuthor(string bookTitle, string bookAuthor, int bookPrice)
            {
                if (firstByAuthor == null)
                    firstByAuthor = new Book(bookTitle, bookAuthor, bookPrice);
                else
                {
                    Book newBook = new Book(bookTitle, bookAuthor, bookPrice);

                    int compareWithFirstBook = newBook.getAuthor().CompareTo(firstByAuthor.getAuthor());

                    if (compareWithFirstBook < 0)
                    {
                        Book temp = firstByAuthor;
                        newBook.nextByAuthor = temp;
                        firstByAuthor = newBook;
                    }
                    else
                    {
                        Book current = firstByAuthor;
                        bool duplicateExists = false;

                        while (current.nextByAuthor != null)
                        {
                            if (duplicateFound(newBook, current) == true)
                            {
                                duplicateExists = true;
                                break;
                            }

                            if (newBook.getAuthor().CompareTo(current.nextByAuthor.getAuthor()) >= 0)
                                current = current.nextByAuthor;
                            else
                                break;
                        }

                        if (duplicateExists == false)
                        {
                            Book temp = current.nextByAuthor;
                            newBook.nextByAuthor = temp;
                            current.nextByAuthor = newBook;
                        }
                        else
                            Console.WriteLine(newBook.getTitle() + " by " +
                               newBook.getAuthor() + " already exists. Insert by author failed.");
                    }
                }
            }

            public void outputEntireList()
            {
                Console.WriteLine("Here's the list in order based on the titles of the books");
                Console.WriteLine();
                Console.WriteLine();
                outputListByTitle();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Here's the list in order based on the authors of the books");
                Console.WriteLine();
                Console.WriteLine();
                outputListByAuthor();
            }

            // Output the list of books in alphabetical order based on the author's last name
            public void outputListByAuthor()
            {
                if (firstByAuthor == null)
                    return;
                else
                {
                    Book current = firstByAuthor;
                    while (current != null)
                    {
                        Console.WriteLine(current.getTitle() + ", " + " " + current.getAuthor() + ", " + " " + current.getPrice());
                        current = current.nextByAuthor;
                    }
                }

                
            }

            // Output the list in alphabetical order based on the title of the book
            public void outputListByTitle()
            {
                if (firstByTitle == null)
                    return;
                else
                {
                    Book current = firstByTitle;
                    while (current != null)
                    {
                        Console.WriteLine(current.getTitle() + ", " + " " + current.getAuthor() + ", " + " " + current.getPrice());
                        current = current.nextByTitle;
                    }
                }
            }
        }


        static void Main(string[] args)
        {

            MultiLinkedList mll = new MultiLinkedList();
            mll.Add("Bullet chess", "Nakamura, Hikaru", 19);
            mll.Add("Flying High", "Meadows, Michelle", 16);
            mll.Add("Chess tactics", "Carlsen, Magnus", 14);
            mll.Add("Fierce", "Raisman, Aly", 18);
            mll.Add("Bullet chess", "Giri, Anish", 11);
            mll.Add("Chess tactics", "Carlsen, Magnus", 14);
            mll.outputEntireList();

        }
    }
}
