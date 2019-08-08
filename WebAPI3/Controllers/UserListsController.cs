using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPI3.Models;

namespace WebAPI3.Controllers
{
    public class UserListsController : Controller
    {
        private readonly dictUserContext _context;

        public UserListsController(dictUserContext context)
        {
            _context = context;
        }

        // GET: UserLists
        [Authorize]
        public IEnumerable<UserList> GetUsers()
        {
            return _context.UserList.ToList();
        }

        // GET: UserLists/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userList = await _context.UserList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userList == null)
            {
                return NotFound();
            }

            return Ok();
        }

        // GET: UserLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserList userList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userList);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return View(userList);
        }

        // GET: UserLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userList = await _context.UserList.FindAsync(id);
            if (userList == null)
            {
                return NotFound();
            }
            return View(userList);
        }

        // POST: UserLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Password,EMail,Name,SurName")] UserList userList)
        {
            if (id != userList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserListExists(userList.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok();
            }
            return View(userList);
        }

        // GET: UserLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userList = await _context.UserList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userList == null)
            {
                return NotFound();
            }

            return Ok();
        }

        // POST: UserLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userList = await _context.UserList.FindAsync(id);
            _context.UserList.Remove(userList);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool UserListExists(int id)
        {
            return _context.UserList.Any(e => e.Id == id);
        }
    }
}
