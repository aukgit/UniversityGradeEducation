namespace UGE.Models.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Choice")]
    public partial class Choice
    {
        public Choice()
        {
            Questions = new HashSet<Question>();
        }

        public long ChoiceID { get; set; }

        public long QuestionID { get; set; }

        [Required]
        [StringLength(500)]
        public string ChoiceDisplay { get; set; }

        public virtual Question Question { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
