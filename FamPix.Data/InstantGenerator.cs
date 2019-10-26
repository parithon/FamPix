using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using NodaTime;

namespace FamPix.Data
{
    internal class InstantGenerator : ValueGenerator<Instant>
    {
        public override Instant Next(EntityEntry entry) => SystemClock.Instance.GetCurrentInstant();
        public override bool GeneratesTemporaryValues => false;
    }
}
