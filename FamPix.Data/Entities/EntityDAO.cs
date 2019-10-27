using NodaTime;

namespace FamPix.Data.Entities
{
    public abstract class EntityDAO
    {
        public int Id { get; set; }

        public Instant Created { get; set; } = SystemClock.Instance.GetCurrentInstant();

        public Instant Modified { get; set; } = SystemClock.Instance.GetCurrentInstant();
    }
}
