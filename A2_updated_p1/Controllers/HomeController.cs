using A2_updated_p1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace A2_updated_p1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbContext;  // Inject the DbContext

        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            // Fetch categories and FAQs from the database
            var categories = _dbContext.Categories.ToList();
            var faqs = _dbContext.FAQs.ToList();
            var topics = _dbContext.Topics.ToList();

            // Pass both categories and FAQs to the view using ViewBag
            ViewBag.Categories = categories;
            ViewBag.FAQs = faqs;
            ViewBag.Topics = topics;

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult FilterByCategory(string categoryId)
        {
            var categories = _dbContext.Categories.ToList();
            var topics = _dbContext.Topics.ToList();

            // Pass both categories and FAQs to the view using ViewBag
            ViewBag.Categories = categories;
            

            // Fetch filtered FAQs based on categoryId
            var filteredFaqs = _dbContext.FAQs.Where(f => f.CategoryId.Equals(categoryId)).ToList();

            // Fetch topics related to the filtered FAQs
            var filteredTopics = _dbContext.Topics
                .Where(t => t.CategoryId.Equals(categoryId))
                .ToList();

            ViewBag.Topics = filteredTopics;
            // Pass filtered FAQs to the view
            ViewBag.FAQs = filteredFaqs;
            ViewBag.selectedCategory = categoryId;

            return View("FilterByCategory");
        }


        public IActionResult FilterByTopic(string topicId)
        {
            var categories = _dbContext.Categories.ToList();
            var topics = _dbContext.Topics.ToList();

            // Pass both categories and FAQs to the view using ViewBag
            ViewBag.Categories = categories;

            // Fetch filtered FAQs based on topicId
            var filteredFaqs = _dbContext.FAQs
                .Where(f => f.TopicId.Equals(topicId))
                .ToList();

            // Get the selected category from the first FAQ (assuming there is at least one)
            var selectedCategory = filteredFaqs.FirstOrDefault()?.CategoryId;

            // Fetch topics related to the filtered FAQs
            var filteredTopics = _dbContext.Topics
                .Where(t => t.CategoryId.Equals(selectedCategory))
                .ToList();

            // Pass filtered FAQs to the view
            ViewBag.FAQs = filteredFaqs;
            ViewBag.Topics = filteredTopics;
            ViewBag.SelectedTopic = topicId;

            ViewBag.SelectedCategory = selectedCategory;

            return View("FilterByTopic");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
