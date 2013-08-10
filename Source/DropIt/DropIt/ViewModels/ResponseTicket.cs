using DropIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropIt.ViewModels
{
    public class ResponseSubmit
    {
        public int TicketId {get;set;}
        public Boolean IsResponse { get; set; }
        public String Description { get; set; }
    }

    public class CreateResponses
    {
        public int UserId {get;set;}
        public int EventId { get; set; }
        public List<ResponseSubmit> responses { get; set; }

        //public CreateResponses()
        //{
        //    responses = new List<ResponseSubmit>();
        //}

        //public CreateResponses(IEnumerable<Ticket> Tickets)
        //{
        //    responses = new List<ResponseSubmit>();
        //    foreach(Ticket Ticket in Tickets){
        //        responses.Add(new ResponseSubmit(){
        //            TicketId = Ticket.TicketId,
        //            IsResponse = false,
        //            Description = null
        //        });
        //    }
        //}
    }
}