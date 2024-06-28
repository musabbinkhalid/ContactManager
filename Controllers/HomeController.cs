using ContactManager.Infrastructure.Entities;
using ContactManager.Infrastructure.Repository;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repository;
        public HomeController(ILogger<HomeController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            //Get all contacts
            var model = _repository.Get<Contact>().ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Add new Contact to DB
                    _repository.Add(contact);
                    _repository.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return View(contact);
                }
            }
            catch (Exception ex)
            {
                //Log Exception if any
                _logger.LogError(ex, ex.Message);
                return View();
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> updateContact(Contact model)
        {
            try
            {
                //Get contact
                var Contact = await _repository.Get<Contact>().Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                //Update Required Fields
                Contact.Name = model.Name;
                Contact.Email = model.Email;
                Contact.Phone = model.Phone;
                Contact.Address = model.Address;
                Contact.City = model.City;
                Contact.Region = model.Region;
                Contact.PostalCode = model.PostalCode;
                Contact.Country = model.Country;

                //Save Changes
                _ = await _repository.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                //Log Exception if any
                _logger.LogError(ex, ex.Message);
                return Problem(ex.Message);
            }
        }
        /// <summary>
        /// Delete Contact Method. it will physically Delete contact
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var Contact = await _repository.Get<Contact>().Where(x => x.Id == Id).FirstOrDefaultAsync();
                _repository.Delete(Contact);
                await _repository.SaveChangesAsync();
                return Ok(true);
            }
            catch (Exception ex)
            {

                return Problem();
            }
        }

        #region PartialViews
        public async Task<IActionResult> _viewModal(int Id)
        {
            try
            {
                var model = await _repository.Get<Contact>().Where(x => x.Id == Id).FirstOrDefaultAsync();
                return PartialView("Partials/_viewmodal", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return PartialView("Partials/_viewmodal", new Contact());
            }
        }

        public async Task<IActionResult> _editModal(int Id)
        {
            try
            {
                var model = await _repository.Get<Contact>().Where(x => x.Id == Id).FirstOrDefaultAsync();
                return PartialView("Partials/_editmodal", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return PartialView("Partials/_editmodal", new Contact());
            }
        }

        #endregion
    }
}
