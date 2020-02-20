using System;
using System.Collections.Generic;

namespace UnitOfWorkRuleSpecificationRepository.Models
{
    public partial class GroupSpecification
    {
        public int GroupSpecificationId { get; set; }
        public int SpecificationId { get; set; }
        public int? MainGroup { get; set; }
        public string MainJoin { get; set; }
        public int? SubGroup { get; set; }
        public string SubJoin { get; set; }

        public virtual Specification Specification { get; set; }

    }
}
