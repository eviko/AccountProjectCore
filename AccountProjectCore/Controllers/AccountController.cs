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
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IHolderRepository _holderRepository;
        public AccountController(IAccountRepository accountRepository, IHolderRepository holderRepository)
        {
            _holderRepository = holderRepository;
            _accountRepository = accountRepository;
        }

        // GET: Account
        public ActionResult Index()
        {
            try
            {
                return View(_accountRepository.GetAll());

            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get acounts");
            }
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View(_accountRepository.GetbyId(id));
        }

        public ActionResult AddTransaction(int id)
        {
            return RedirectToAction("Create", "Transaction", new { accountId = id });
        }

        public IActionResult GetAccountHoldersByAccount(int id)
        {
            var account = _accountRepository.GetAccountWithHolders(id);
            if (account == null)
                return View();
            return View(account);
        }

        public IActionResult GetTransactionsByAccount(int id)
        {
            var account = _accountRepository.GetAccountWithTransactions(id);
            if (account == null)
                return View();
            return View(account);
        }

    }
}
