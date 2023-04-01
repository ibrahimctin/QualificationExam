namespace QualificationExam.Domain.Enitities.Identity
{
    public class AppRole:IdentityRole<string>
    {
        public virtual ICollection<AppUserRole>? UserRoles { get; set; }

    }
}
