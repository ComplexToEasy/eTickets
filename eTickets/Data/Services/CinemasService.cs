﻿using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.services

{
    public class CinemasService:EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context)
        {

        }
    }
}
