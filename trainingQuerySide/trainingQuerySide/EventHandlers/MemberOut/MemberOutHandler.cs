using MediatR;
using trainingQuerySide.Abstractions;
using trainingQuerySide.Infrastructure.Data;

namespace trainingQuerySide.EventHandlers.MemberOut
{
    public class MemberOutHandler(IUnitOfWork unitOfWork, IMediator mediator, ILogger<MemberOutHandler> logger) : IRequestHandler<MemberOut, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<MemberOutHandler> _logger = logger;
       

        public async Task<bool> Handle(MemberOut @event, CancellationToken cancellationToken)
        {
            //هون المقروض يوصلني الحدث مع نوعه 
            var usersubscription =  await _unitOfWork.SubscriptionUsers.FindAsync(@event.AggregateId, cancellationToken);

            if (usersubscription is null)
            {
                _logger.LogWarning("user-subscription {usersubscription} not found", @event.AggregateId);
                return false;
            }

       
            // if (@event.Sequence <= employee.Sequence) return true;

            //if (@event.Sequence > employee.Sequence + 1)
            //{
            //    _logger.LogWarning("Sequence {Sequence} is not expected for employee {EmployeeId}", @event.Sequence, @event.AggregateId);
            //    return false;
            //}
           
            usersubscription.MemberOut(@event);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return true;
        }
    }
}
