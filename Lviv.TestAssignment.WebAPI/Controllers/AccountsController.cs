using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lviv.TestAssignment.Database;
using Lviv.TestAssignment.Database.Entities;

namespace Lviv.TestAssignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController(AppDbContext context) : ControllerBase
    {

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return await context.Accounts.ToListAsync();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, Account account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            context.Entry(account).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account account, int contactId)
        {
            Contact? contact = await context.Contacts.FirstOrDefaultAsync(c => c.Id == contactId);

            if (contact is null)
            {
                return BadRequest("Account must have at least one contact provided");
            }

            account.Contacts.Add(contact);
            contact.AccountId = account.Id;

            context.Accounts.Add(account);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = account.Id }, account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            context.Accounts.Remove(account);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountExists(int id)
        {
            return context.Accounts.Any(e => e.Id == id);
        }
    }
}
