namespace UGE.Models.Garbage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        public Question()
        {
            Choices = new HashSet<Choice>();
        }

        public long QuestionID { get; set; }

        [StringLength(200)]
        public string Hint { get; set; }

        public long AnswerChoiceID { get; set; }

        [Required]
        [StringLength(800)]
        public string QuestionDisplay { get; set; }

        public int MCQID { get; set; }

        public virtual ICollection<Choice> Choices { get; set; }

        public virtual Choice Choice { get; set; }

        public virtual MCQ MCQ { get; set; }
    }
}
