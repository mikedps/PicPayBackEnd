using MediatR;
using Microsoft.Extensions.Logging;
using PicPayBackEnd.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayBackEnd.Data.Events
{
    public class DummynHandler : INotificationHandler<UserCreatedEvent>
    {
        private ILogger<UserCreatedEvent> _logger;

        public DummynHandler(ILogger<UserCreatedEvent> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("new User {0} created again", notification.User.Name);


            return Task.CompletedTask;
        }
    }
}
