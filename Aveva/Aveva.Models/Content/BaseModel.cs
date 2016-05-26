namespace Aveva.Models.Content
{
    public enum ContentType
    {
        BOX = 0,
        LIST = 1
    }

    public class BaseModel
    {
        public ContentType Type;
    }
}
