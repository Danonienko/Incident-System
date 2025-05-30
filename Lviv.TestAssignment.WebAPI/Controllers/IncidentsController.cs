using Lviv.TestAssignment.WebAPI.DTOs;
using Lviv.TestAssignment.WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lviv.TestAssignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController(AppDbContext context) : ControllerBase
    {
        // GET: api/<IncidentController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(context.Incidents.ToList());
        }

        // GET api/<IncidentController>/5
        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            Incident? incident = context.Incidents.FirstOrDefault(i => i.Name == name);

            if (incident is null)
            {
                return NotFound($"Could not find incident '{name}'");
            }

            return Ok(incident);
        }

        // POST api/<IncidentController>
        [HttpPost]
        public IActionResult Post(IncidentDTO incidentDTO)
        {
            Account? account = context.Accounts.FirstOrDefault(a => a.Name == incidentDTO.AccountName);

            if (account is null)
            {
                return NotFound($"Account '{incidentDTO.AccountName}' not found");
            }

            Contact? contact = context.Contacts.FirstOrDefault(c => c.Email == incidentDTO.ContactEmail);

            if (contact is null)
            {
                Contact newContact = new()
                {
                    FirstName = incidentDTO.ContactFirstName,
                    LastName = incidentDTO.ContactLastName,
                    Email = incidentDTO.ContactEmail,
                };

                account.Contacts.Add(newContact);

                Incident newIncident = new()
                {
                    Description = incidentDTO.IncidentDescription
                };

                newIncident.Accounts.Add(account);

                context.Contacts.Add(newContact);
                context.Incidents.Add(newIncident);

                account.IncidentId = newIncident.Name;

                context.SaveChanges();

                return Ok(newIncident);
            }

            contact.FirstName = incidentDTO.ContactFirstName;
            contact.LastName = incidentDTO.ContactLastName;

            if (contact.AccountId is null)
            {
                contact.AccountId = account.Id;
                account.Contacts.Add(contact);
            }

            context.SaveChanges();

            return Ok(contact);
        }
    }
}
