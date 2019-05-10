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
    public class TransactionController : Controller
    {
        ITransactionRepository _transactionRepository;
        IAccountRepository _accountRepository;
        IRepository<TransactionType> _trnTypeRepository;
        public TransactionController(ITransactionRepository transactionRepository, IAccountRepository accountRepository, IRepository<TransactionType> trnTypeRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _trnTypeRepository = trnTypeRepository;
        }
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

        // GET: Transaction/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Transaction/Create
        public ActionResult Create(int id)
        {
            ViewBag.TransactionTypes = _trnTypeRepository.GetAll();
            var trn = new Transaction();
            trn.ForAccountId = id;
            trn.TransactionDatetime = DateTime.Now;
            trn.Amount = 0;
            return View(trn);
        }

        // POST: Transaction/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transaction value)
        {
            try
            {              
                if (value == null)
                {
                    return BadRequest("Transaction is null.");
                }
                value.Id = 0;
                var trnType = _trnTypeRepository.GetbyId(value.InTransactionTypeId);
                var account = _accountRepository.GetbyId(value.ForAccountId);
                value.TransactionDatetime = DateTime.Now;
                if (trnType.ChargeType == ChargeType.Debit)
                {
                    if (account.Balance - value.Amount < 0)
                    {
                        return BadRequest("Account balance is less than the amount.");
                    }
                    else
                    {
                        account.Balance = account.Balance - value.Amount;
                        _accountRepository.Update(account);
                    }
                }
                else
                {
                    account.Balance = account.Balance + value.Amount;
                    _accountRepository.Update(account);
                }

                _transactionRepository.Create(value);

                return RedirectToAction("Index", "Account", new { id = value.ForAccountId });
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Transaction/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transaction/Edit/5
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

        // GET: Transaction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transaction/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}