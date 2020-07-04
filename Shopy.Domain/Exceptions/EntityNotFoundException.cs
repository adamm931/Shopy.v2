namespace Shopy.Domain.Exceptions
{
    public class EntityNotFoundException : LocalizedException
    {

        public EntityNotFoundException(string entityName, object resourceId)
            : base(ErrorCode.EntityNotFound, entityName, resourceId)
        {
        }
    }
}
