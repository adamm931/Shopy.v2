namespace Shopy.Domain.Entitties.Base
{
    public abstract class EnumEntity<TEnumEntity> : Entity
        where TEnumEntity : EnumEntity<TEnumEntity>
    {
        public string Code { get; private set; }

        protected EnumEntity(string code)
        {
            Code = code;
        }

        protected EnumEntity()
        {
        }

        //public static TEnumEntity Parse(string code)
        //    => ReflectionHelper
        //        .GetInstances<TEnumEntity>()
        //        .SingleOrDefault(enumEntity => enumEntity.Code.Equals(code, StringComparison.OrdinalIgnoreCase))
        //        ?? throw new EnumEntityInvalidCodeException(code, typeof(TEnumEntity).Name);

        //public static IEnumerable<TEnumEntity> Parse(string[] codes)
        //    => ReflectionHelper
        //        .GetInstances<TEnumEntity>()
        //        .Where(enumEntity => codes.Any(code => code.Equals(enumEntity.Code, StringComparison.OrdinalIgnoreCase)));
    }
}
