using Assignment1_C0901142.Models; // Importing the namespace for models
using Microsoft.AspNetCore.Mvc; // Importing the namespace for ASP.NET Core MVC
using System.Diagnostics; // Importing the namespace for diagnostics

namespace Assignment1_C0901142.Controllers
{
    
    /// HomeController class to handle requests related to home page and loan payment calculations.
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // Logger for logging messages

        
        /// Constructor to initialize the HomeController with a logger.
        
        /// <param name="logger">The logger instance to be used for logging.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        /// Handles GET requests to the Index page.
        /// Initializes ViewBag properties with default values.
        
        /// <returns>The Index view.</returns>
        [HttpGet]
        public IActionResult Index()
        {
            // Initializing ViewBag properties for the view
            ViewBag.Principal = 0;
            ViewBag.YearlyInterestRate = 0;
            ViewBag.NumberOfPaymentsPerYear = 0;
            ViewBag.PaymentPerPeriod = 0;
            return View(); // Returning the view
        }

        
        /// Handles POST requests to the Index page.
        /// Validates the model and calculates the loan payment per period if valid.
        
        /// <param name="model">The LoanCalModel object containing the loan details.</param>
        /// <returns>The Index view with the model.</returns>
        [HttpPost]
        public IActionResult Index(LoanCalModel model)
        {
            // Checking if the model state is valid
            if (ModelState.IsValid)
            {
                // Calculating and setting the PaymentPerPeriod value in ViewBag
                ViewBag.PaymentPerPeriod = model.CalculateLoanPaymentPerPeriod();
            }
            else
            {
                // Setting PaymentPerPeriod to 0 if the model state is invalid
                ViewBag.PaymentPerPeriod = 0;
            }
            return View(model); // Returning the view with the model
        }

        
        /// Handles errors and returns the Error view with error details.
        
        /// <returns>The Error view with an ErrorViewModel object containing request ID and trace information.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Returning the Error view with an ErrorViewModel
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
