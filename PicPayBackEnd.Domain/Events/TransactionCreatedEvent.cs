
using PicPayBackEnd.Domain.Entities;
using PicPayBackEnd.Domain.Primitives;

namespace PicPayBackEnd.Domain.Events;
public record TransactionCreatedEvent(Transaction Transaction) : IDomainEvent;
