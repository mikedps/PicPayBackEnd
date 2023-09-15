using PicPayBackEnd.Domain.Entities;
using PicPayBackEnd.Domain.Primitives;

namespace PicPayBackEnd.Domain.Events;

public record UserCreatedEvent(User User) : IDomainEvent;

