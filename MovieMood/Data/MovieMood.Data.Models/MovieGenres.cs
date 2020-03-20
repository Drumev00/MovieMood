namespace MovieMood.Data.Models
{
    using System;

    using MovieMood.Data.Common.Models;
    using MovieMood.Data.Models.Enums;

    public class MovieGenres : IAuditInfo, IDeletableEntity
    {
        public string MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public Genre Genre { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
