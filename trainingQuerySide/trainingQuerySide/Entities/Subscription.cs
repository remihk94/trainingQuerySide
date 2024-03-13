﻿namespace trainingQuerySide.Entities
{
    public class Subscription
    {
        private Subscription(int sequence, string id, string accountId)
        {
            Id = id;
            Sequence = sequence;
            AccountId = accountId;
        }
        public int Sequence { get; private set; }
        public string Id { get; private set; }
        public string AccountId { get; private set; }
        // add total members in subscription
        public ICollection<UserSubscription> UserSubscriptions { get; } = [];
    }
}
