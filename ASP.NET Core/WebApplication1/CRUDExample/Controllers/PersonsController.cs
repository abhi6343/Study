// <copyright file="PersonsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CRUDExample.Controllers
{
    using CRUDExample.Filters;
    using CRUDExample.Filters.ActionFilters;
    using CRUDExample.Filters.AuthorizationFilters;
    using CRUDExample.Filters.ExceptionFilters;
    using CRUDExample.Filters.ResourceFilters;
    using CRUDExample.Filters.ResultFilters;
    using Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Rotativa.AspNetCore;
    using Rotativa.AspNetCore.Options;
    using ServiceContractsxUnit;
    using ServiceContractsxUnit.DTO;
    using ServiceContractsxUnit.Enums;

    /// <summary>
    /// Represents a controller for managing persons and their related actions.
    /// </summary>
    // [Route("persons")]
    [Route("[controller]")]

    // [TypeFilter(typeof(ResponseHeaderActionFilter), Arguments = new object[] { "MyKey-From-Controller", "MyValue-From-Controller" }, Order = 2)]
    // [TypeFilter(typeof(ResponseHeaderActionFilter), Arguments = new object[] { "MyKey-From-Controller", "MyValue-From-Controller", 3 })]
    // [TypeFilter(typeof(ResponseHeaderActionFilter), Arguments = new object[] { "MyKey-From-Controller", "MyValue-From-Controller", 3 }, Order = 3)]
    // [ResponseHeaderActionFilter("MyKey-From-Controller", "MyValue-From-Controller", 3)]
    [ResponseHeaderFilterFactory("MyKey-From-Controller", "MyValue-From-Controller", 3)]
    [TypeFilter(typeof(HandleExceptionFilter))]
    [TypeFilter(typeof(PersonAlwaysRunResultFilter))]
    public class PersonsController : Controller
    {
        /// <summary>
        /// The service for managing persons.
        /// </summary>
        readonly IPersonsService _personsService;

        /// <summary>
        /// The service for managing countries.
        /// </summary>
        readonly ICountriesService _countriesService;

        /// <summary>
        /// The logger for logging information related to the controller's actions.
        /// </summary>
        readonly ILogger<PersonsController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonsController"/> class with the specified services and logger.
        /// </summary>
        /// <param name="personsService">The service for managing persons.</param>
        /// <param name="countriesService">The service for managing countries.</param>
        /// <param name="logger">The logger for logging information.</param>
        public PersonsController(IPersonsService personsService, ICountriesService countriesService, ILogger<PersonsController> logger)
        {
            this._personsService = personsService;
            this._countriesService = countriesService;
            this._logger = logger;
        }

        /// <summary>
        /// Handles the request to display a list of persons with optional search and sorting parameters.
        /// </summary>
        /// <param name="searchBy">The field to search by.</param>
        /// <param name="searchString">The string to search for.</param>
        /// <param name="sortBy">The field to sort by.</param>
        /// <param name="sortOrder">The order to sort in.</param>
        /// <returns>The action result.</returns>
        // [Route("persons/index")]20
        // [Route("/index")]
        // [Route("index")]
        [Route("[action]")]
        [Route("/")]

        // [TypeFilter(typeof(PersonsListActionFilter))]
        // [TypeFilter(typeof(PersonsListActionFilter), Order = 4)]

        // [TypeFilter(typeof(ResponseHeaderActionFilter), Arguments = new object[] { "X-Custom_Key", "Custom-Value" }, Order = 1)]
        // [TypeFilter(typeof(ResponseHeaderActionFilter), Arguments = new object[] { "X-Custom_Key", "Custom-Value", 1 }, Order = 1)]
        // [ResponseHeaderActionFilter("X-Custom_Key", "Custom-Value", 1)]
        [ResponseHeaderFilterFactory("X-Custom_Key", "Custom-Value", 1)]
        [TypeFilter(typeof(PersonsListResultFilter))]
        [ServiceFilter(typeof(PersonsListActionFilter))]
        [SkipFilter]

        // public IActionResult Index(string searchBy, string searchString, string? sortBy = nameof(PersonResponse.PersonName), SortOrderOptions sortOrder = SortOrderOptions.ASC)
        public async Task<IActionResult> Index(string searchBy, string searchString, string? sortBy = nameof(PersonResponse.PersonName), SortOrderOptions sortOrder = SortOrderOptions.ASC)
        {
            this._logger.LogInformation("Index action method of PersonsController");

            this._logger.LogDebug($"searchBy: {searchBy}, searchString: {searchString}, sortBy: {sortBy}, sortOrder: {sortOrder}");

            // Search fields for searching persons
            // this.ViewBag.SearchFields = new Dictionary<string, string>()
            // {
            //     { nameof(PersonResponse.PersonName), "Person Name" },
            //     { nameof(PersonResponse.Email), "Email" },
            //     { nameof(PersonResponse.DateOfBirth), "Date of Birth" },
            //     { nameof(PersonResponse.Age), "Age" },
            //     { nameof(PersonResponse.Gender), "Gender" },
            //     { nameof(PersonResponse.Country), "Country" },
            //     { nameof(PersonResponse.Address), "Address" },
            //     { nameof(PersonResponse.ReceiveNewsLetters), "Receive News Letters" },
            // };

            // var persons = _personsService.GetAllPersons();
            // var persons = _personsService.GetFilteredPersons(searchBy, searchString);
            var persons = await this._personsService.GetFilteredPersons(searchBy, searchString);

            // this.ViewBag.CurrentSearchBy = searchBy;
            // this.ViewBag.CurrentSearchString = searchString;

            // Sort
            // var sortedPersons = _personsService.GetSortedPersons(persons, sortBy, sortOrder);
            var sortedPersons = await this._personsService.GetSortedPersons(persons, sortBy!, sortOrder);

            /* this.ViewBag.CurrentSortBy = sortBy;
            this.ViewBag.CurrentSortOrder = sortOrder;*/

            return this.View(sortedPersons);
        }

        /// <summary>
        /// Handles the request to display the form for creating a new person.
        /// </summary>
        /// <returns>The action result.</returns>
        // Executes when user clicks on "Create Person" link
        // [Route("persons/create")]
        [Route("create")]
        [HttpGet]

        // [TypeFilter(typeof(ResponseHeaderActionFilter), Arguments = new object[] { "my-key", "my-value", 4 })]
        // [ResponseHeaderActionFilter("my-key", "my-value", 4)]
        [ResponseHeaderFilterFactory("my-key", "my-value", 4)]

        // public IActionResult Create()
        public async Task<IActionResult> Create()
        {
            var countries = await this._countriesService.GetAllCountries();
            this.ViewBag.Countries = countries.Select(c => new SelectListItem() { Text = c.CountryName, Value = c.CountryID.ToString() });

            // new SelectListItem() { Text = "-- Select Country --", Value = "" };
            // <option value="">-- Select Country --</option>
            return this.View();
        }

        /// <summary>
        /// Handles the request to create a new person based on the provided person add request.
        /// </summary>
        /// <param name="personAddRequest">The person add request.</param>
        /// <param name="personRequest">The person add request.</param>
        /// <returns>The action result.</returns>
        // [Route("persons/create")]
        [Route("create")]
        [HttpPost]
        [TypeFilter(typeof(PersonCreateAndEditPostActionFilter))]
        [TypeFilter(typeof(FeatureDisabledResourceFilter), Arguments = new object[] { false })]

        // public IActionResult Create(PersonAddRequest personAddRequest)
        public async Task<IActionResult> Create(PersonAddRequest personRequest) // personAddRequest)
        {
            /*if (!this.ModelState.IsValid)
            {
                var countries = await this._countriesService.GetAllCountries();
                this.ViewBag.Countries = countries.Select(c => new SelectListItem() { Text = c.CountryName, Value = c.CountryID.ToString() });
                this.ViewBag.Errors = this.ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage);
                return this.View(personRequest);
            }*/

            // call service method to add person
            // var personResponse = _personsService.AddPerson(personAddRequest);
            var personResponse = await this._personsService.AddPerson(personRequest);

            // navigate user to "Index" action of this controller
            return this.RedirectToAction("Index");
        }

        [Route("[action]/{personID}")]
        [HttpGet]

        // [TypeFilter(typeof(TokenResultFilter))]
        /// <summary>
        /// Displays the form for editing an existing person.
        /// </summary>
        /// <param name="personID">The ID of the person to edit.</param>
        /// <returns>The action result.</returns>
        // public IActionResult Edit(Guid personID)
        public async Task<IActionResult> Edit(Guid personID)
        {
            var personResponse = await this._personsService.GetPersonByPersonID(personID);
            if (personResponse == null)
            {
                return this.RedirectToAction("Index");
            }

            var personUpdateRequest = personResponse.ToPersonUpdateRequest();

            var countries = await this._countriesService.GetAllCountries();
            this.ViewBag.Countries = countries.Select(c => new SelectListItem() { Text = c.CountryName, Value = c.CountryID.ToString() });

            return this.View(personUpdateRequest);
        }

        [Route("[action]/{personID}")]
        [HttpPost]
        [TypeFilter(typeof(PersonCreateAndEditPostActionFilter))]
        [TypeFilter(typeof(TokenAuthorizationFilter))]

        // [TypeFilter(typeof(PersonsAlwaysRunResultFilter))]
        /// <summary>
        /// Updates an existing person.
        /// </summary>
        /// <param name="personUpdateRequest">The request containing the updated person information.</param>
        /// <param name="personRequest">The request containing the updated person information.</param>
        /// <returns>The action result.</returns>
        // public IActionResult Edit(PersonUpdateRequest personUpdateRequest)
        public async Task<IActionResult> Edit(PersonUpdateRequest personRequest) // personUpdateRequest)
        {
            var personResponse = await this._personsService.GetPersonByPersonID(personRequest.PersonID);
            if (personResponse == null)
            {
                return this.RedirectToAction("Index");
            }

            /*if (!this.ModelState.IsValid)
            {
                var countries = await this._countriesService.GetAllCountries();
                this.ViewBag.Countries = countries.Select(c => new SelectListItem() { Text = c.CountryName, Value = c.CountryID.ToString() });
                this.ViewBag.Errors = this.ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage);

                // return this.View(personResponse.ToPersonUpdateRequest());
                return this.View(personResponse.ToPersonUpdateRequest());
            }
            else*/
            {
                var updatedPerson = await this._personsService.UpdatePerson(personRequest);
                return this.RedirectToAction("Index");
            }
        }

        [Route("[action]/{personID}")]
        [HttpGet]
        /// <summary>
        /// Displays the delete confirmation page for a specific person.
        /// </summary>
        /// <param name="personID">The ID of the person to delete.</param>
        /// <returns>The action result.</returns>
        /// 
        // public IActionResult Delete(Guid personID)
        public async Task<IActionResult> Delete(Guid personID)
        {
            var personResponse = await this._personsService.GetPersonByPersonID(personID);
            if (personResponse == null)
            {
                return this.RedirectToAction("Index");
            }

            return this.View(personResponse);
        }

        [Route("[action]/{personID}")]
        [HttpPost]
        /// <summary>
        /// Deletes a specific person.
        /// </summary>
        /// <param name="personUpdateRequest">The request containing the person to delete.</param>
        /// <returns>The action result.</returns>
        // public IActionResult Delete(PersonUpdateRequest personUpdateRequest)
        public async Task<IActionResult> Delete(PersonUpdateRequest personUpdateRequest)
        {
            var personResponse = await this._personsService.GetPersonByPersonID(personUpdateRequest.PersonID);
            if (personResponse == null)
            {
                return this.RedirectToAction("Index");
            }

            await this._personsService.DeletePerson(personUpdateRequest.PersonID);
            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// Generates a PDF document containing the list of persons and returns it as a response.
        /// </summary>
        /// <returns>The action result.</returns>
        [Route("PersonsPDF")]
        public async Task<IActionResult> PersonsPDF()
        {
            // Get list of persons
            var persons = await this._personsService.GetAllPersons();

            // Return view as pdf
            return new ViewAsPdf("PersonsPDF", persons, this.ViewData)
            {
                PageMargins = new Margins(20, 10, 20, 10),
                PageOrientation = Orientation.Landscape,
            };
        }

        /// <summary>
        /// Generates a CSV file containing the list of persons and returns it as a response.
        /// </summary>
        /// <returns>The action result.</returns>
        [Route("PersonsCSV")]
        public async Task<IActionResult> PersonsCSV()
        {
            var memoryStream = await this._personsService.GetPersonsCSV();
            return this.File(memoryStream, "application/octet-stream", "persons.csv");
        }

        /// <summary>
        /// Generates an Excel file containing the list of persons and returns it as a response.
        /// </summary>
        /// <returns>The action result.</returns>
        [Route("PersonsExcel")]
        public async Task<IActionResult> PersonsExcel()
        {
            var memoryStream = await this._personsService.GetPersonsExcel();
            return this.File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "persons.xlsx");
        }
    }
}
