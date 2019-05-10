using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountProjectCore.Models;
using AccountProjectCore.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountProjectCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
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

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult AddTransaction(int id)
        {
            return RedirectToAction("Create", "Transaction", new { accountId = id });
        }
        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account value)
        {
            try
            {
                if (value == null)
                {
                    return BadRequest("Account is null.");
                }
                _accountRepository.Create(value);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
