using Microsoft.AspNetCore.Mvc;
using BookLibraryExam.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookLibraryExam.Controllers
{
    public class BooksController : Controller
    {
        private static List<Book> books = new List<Book>();
        private static int nextId = 1;

        public IActionResult Index()
        {
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = nextId++;
                books.Add(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                var existing = books.FirstOrDefault(b => b.Id == book.Id);
                if (existing == null) return NotFound();

                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.ISBN = book.ISBN;
                existing.PublicationYear = book.PublicationYear;

                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
            }
            return RedirectToAction("Index");
        }
    }
}
