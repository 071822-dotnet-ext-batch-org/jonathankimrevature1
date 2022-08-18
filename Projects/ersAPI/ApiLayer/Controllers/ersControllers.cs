using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;


namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ersControllers : ControllerBase
    {
        //Use ersBusinessLayer from BusinessLayer and create _businessLayer
        // The _ is naming convention for private local variables
        // This is the instance of the business layer to call this._businessLayer.TicketsAsync(type)
        //_businessLayer here is a class object that's instantiated by this controller
        private readonly ersBusinessLayer _businessLayer;
       
        public ersControllers()
        {
            this._businessLayer = new ersBusinessLayer();
        }

        //These are optional request parameters in the header in Swagger
        //These are the action methods in ApiLayer
        //There is a "route" way of doing it but Mark likes it like this
        //? means optional, without it, these are all required
        [HttpGet("TicketsAsync")]//get all tickets
        [HttpGet("TicketsAsync/{type}")]//get all of a certain type of tickets
        //[HttpGet("TicketsAsync/{id}/{type?}")]//get all OR a specific id AND type. Figure out how to strucure the query so that the optional values are indeed optional
        //[HttpGet("TicketssAsync/{id}")]//get all of a specific employees tickets

        
        //Gives you a Task of ActionResult that gives you a list of the type "Ticket" (from ModelsLayer)
        //Call it by using the newly created method, TicketsAsync()
        public async Task<ActionResult<List<Ticket>>> TicketsAsync(int type, Guid? id)
        {
            //Create ticketList
            List<Ticket> ticketList = await this._businessLayer.TicketsAsync(type);//Same list from ersRepoLayer travelled repo -> business -> controllers. That whole thing was called here in this empty list.
            return Ok(ticketList); //Returns entire list to the caller in swagger //returns 200, http status code

            return null;
        }
    }
}
