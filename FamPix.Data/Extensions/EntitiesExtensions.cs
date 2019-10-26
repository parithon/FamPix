using FamPix.Core;
using System.Linq;

namespace FamPix.Data.Entities
{
    public static class EntitiesExtensions
    {
        public static TDomainObject ToDTO<TDomainObject>(this EntityDAO dao) where TDomainObject : new()
        {
            var fromProperties = dao.GetType().GetProperties();
            var toProperties = typeof(TDomainObject).GetProperties();

            var dto = new TDomainObject();

            foreach (var property in fromProperties)
            {
                if (toProperties.Any(p => p.Name == property.Name))
                {
                    var value = property.GetValue(dao);
                    var toProperty = toProperties.Single(p => p.Name == property.Name);
                    toProperty.SetValue(dto, value);
                }
            }

            return dto;
        }

        public static TDataObject ToDAO<TDataObject>(this Entity dto) where TDataObject : new()
        {
            var fromProperties = dto.GetType().GetProperties();
            var toProperties = typeof(TDataObject).GetProperties();
            var dao = new TDataObject();

            foreach (var property in fromProperties)
            {
                if (toProperties.Any(p => p.Name == property.Name))
                {
                    var value = property.GetValue(dto);
                    var toProperty = toProperties.Single(p => p.Name == property.Name);
                    toProperty.SetValue(dao, value);
                }
            }

            return dao;
        }
    }
}
