using NodaTime;

namespace FamPix.Core
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        public Instant Created { get; protected set; }

        public Instant Modified { get; protected set; }
    }
}
