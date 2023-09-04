using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PicPayBackEnd.Data.Context;
using PicPayBackEnd.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Data.Interceptors
{
    public class PublishDomainEventsInterceptor : SaveChangesInterceptor
    {

        private readonly IPublisher _publisher;

        public PublishDomainEventsInterceptor(IPublisher publisher)
        {
            _publisher = publisher;
        }


        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, 
            InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;


            if (context is null)
            {
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            }

            var entries = context.ChangeTracker.Entries().ToList();
            var entries1 = context.ChangeTracker.Entries<Entity>().ToList();


            var domainEvents = context.ChangeTracker
                                .Entries<Entity>()
                                .Select(x => x.Entity)
                                .SelectMany(aggregate =>
                                {
                                    var domainEvents = aggregate.GetDomainEvents();
                                    aggregate.ClearEvents();
                                    return domainEvents;
                                }).ToList();


            foreach (var domainEvent in domainEvents)
            {
                 _publisher.Publish(domainEvent);
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

    }
}
