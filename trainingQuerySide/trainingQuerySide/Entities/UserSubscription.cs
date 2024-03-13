using System.Numerics;
using trainingQuerySide.EventHandlers.MemberOut;

namespace trainingQuerySide.Entities
{
    public class UserSubscription
    { 
        // for created event 
        private UserSubscription(
            string aggregateId,
            string subscriptionId,
            string userId,
            string memberId,
            string accountId,
            int sequence)
        {
            Id = aggregateId;
            UserId = userId;
            MemberId = memberId;
            Sequence = sequence;
            AccountId = accountId;
            SubscriptionId = subscriptionId;
        }

        public string Id { get; set; }
        public string UserId { get; private set; }
        public string MemberId { get; private set; }
        public string AccountId { get; private set; }
        public string SubscriptionId { get; private set; }
        public int Sequence { get; private set; }
        public User? User { get; private set; }
        public Subscription? Subscription { get; private set; }
       // public string Type { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public void IncrementSequence() => Sequence++;


        public void MemberOut(MemberOut @event)
        {
            Sequence = @event.Sequence;
            UserId = @event.Data.UserId;
            SubscriptionId = @event.Data.SubscriptionId;
            MemberId = @event.Data.MemberId;
          //  Type = @event.Data.Type;
        }

    }
}
