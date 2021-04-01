﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Week10_4_ChainOfResponsibility
{
    class Classes
    {
        // The 'Handler' abstract class
        public abstract class IHandler

        {
            protected IHandler successor;

            public void SetSuccessor(IHandler successor)
            {
                this.successor = successor;
            }
            public abstract void HandleRequest(SupportTicket ticket);
        }

        // A 'Concrete Handler' class
        public class Tier1 : IHandler
        {
            public override void HandleRequest(SupportTicket ticket)
            {
                if (ticket.Type == TicketType.Basic)
                {
                    Console.WriteLine("Ticket# {0} resolved at {1}", ticket.Id, this.GetType().Name);
                }
                else if (successor != null)
                {
                    successor.HandleRequest(ticket);
                }
            }
        }

        // A 'Concrete Handler' class
        public class Tier2 : IHandler
        {
            public override void HandleRequest(SupportTicket ticket)
            {
                if (ticket.Type == TicketType.InDepth)
                {
                    Console.WriteLine("Ticket# {0} resolved at {1}", ticket.Id, this.GetType().Name);
                }
                else if (successor != null)
                {
                    successor.HandleRequest(ticket);
                }
            }
        }

        // A 'Concrete Handler' class
        public class Tier3 : IHandler
        {
            public override void HandleRequest(SupportTicket ticket)
            {
                if (ticket.Type == TicketType.Advanced)
                {
                    Console.WriteLine("Ticket# {0} resolved at {1}", ticket.Id, this.GetType().Name);
                }
                else if (successor != null)
                {
                    successor.HandleRequest(ticket);
                }
            }
        }

        // A 'Concrete Handler' class
        public class Tier4 : IHandler
        {
            public override void HandleRequest(SupportTicket ticket)
            {
                if (ticket.Type == TicketType.Vendor)
                {
                    Console.WriteLine("Ticket# {0} resolved at {1}", ticket.Id, this.GetType().Name);
                }
                else
                {
                    Console.WriteLine("Ticket# {0} could not be resolved; please, forward the ticket to issue resolution department", ticket.Id);
                }
            }
        }


        // Helper SupportTicket Class
        public class SupportTicket
        {
            public int Id { get; set; }
            public TicketType Type { get; set; }

            public SupportTicket(int id, TicketType type)
            {
                this.Id = id;
                this.Type = type;
            }

        }
        public enum TicketType
        {
            Basic,
            InDepth,
            Advanced,
            Vendor,
            Unknown
        }
    }
}
