﻿using Domain;
using MediatR;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Commands
{
    public class EditActivity
    {
        public class Command : IRequest
        {
            public required Activity Activity { get; set; }
        }

        public class Handler(AppDbContext context) : IRequestHandler<Command>
        {
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync([request.Activity.Id], cancellationToken)
                    ?? throw new Exception("Cannot find activity");

                activity.Title = request.Activity.Title;
                activity.Category = request.Activity.Category;
                activity.Description = request.Activity.Description;
                activity.City = request.Activity.City;

                await context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
