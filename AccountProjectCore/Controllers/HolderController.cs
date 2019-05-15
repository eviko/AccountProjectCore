using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountProjectCore.Models;
using AccountProjectCore.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountProjectCore.Controllers
{
    [Authorize]

    public class HolderController : Controller
    {
        private readonly IHolderRepository _holderRepository;
        public HolderController(IHolderRepository holderRepository)
        {
            _holderRepository = holderRepository;
        }
        // GET: Holder
        public ActionResult Index()
        {
            try
            {
                return View(_holderRepository.GetHolderByLoggedUser(User.Identity.Name));
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get acounts");
            }
        }

        // GET: Holder/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction("Details", "Account", new { id });
        }

        public IActionResult GetAccountHoldersByAccount(int id)
        {

            return RedirectToAction("GetAccountHoldersByAccount", "Account", new { id });
        }

        public IActionResult GetTransactionsByAccount(int id)
        {
            return RedirectToAction("GetTransactionsByAccount", "Account", new { id });

        }


    }
}