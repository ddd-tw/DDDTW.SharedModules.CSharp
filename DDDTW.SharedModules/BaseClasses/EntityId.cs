using System;
using System.Collections.Generic;
using DDDTW.SharedModules.Interfaces;

namespace DDDTW.SharedModules.BaseClasses
{
    public abstract class EntityId : PropertyComparer<EntityId>, IEntityId
    {
        #region Constructors

        protected EntityId(string abbr, long seqNo, DateTimeOffset? occuredDate = null)
        {
            if (string.IsNullOrWhiteSpace(abbr))
                throw new ArgumentException("Abbreviation can not be empty or null");

            if (seqNo < 0)
                throw new ArgumentException("SeqNo can not be negative digital");

            this.Abbr = abbr;
            this.SeqNo = seqNo;
            this.OccuredDate = occuredDate ?? DateTimeOffset.Now;
        }

        #endregion Constructors

        #region Properties

        public string Abbr { get; private set; }

        public long SeqNo { get; private set; }

        public DateTimeOffset? OccuredDate { get; private set; }

        #endregion Properties

        public override string ToString() => $"{this.Abbr}-{this.OccuredDate:yyyyMMdd}-{this.SeqNo:X}";

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Abbr;
            yield return this.SeqNo;
            yield return this.OccuredDate?.ToString("yyyyMMddHHmmSS");
        }
    }
}