namespace poc_dependency_injection.Domain.Model
{
    public class BaseResultModel
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }

        public BaseResultModel(Guid id, DateTime dateTime)
        {
            Id = id;
            DateTime = dateTime;
        }

        public BaseResultModel()
        {
        }
    }
}