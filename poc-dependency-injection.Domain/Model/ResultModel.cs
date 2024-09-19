namespace poc_dependency_injection.Domain.Model
{
    public class ResultModel
    {
        public List<BaseResultModel> Results { get; set; } = new List<BaseResultModel>();
        public string NameDI { get; set; }
        public string DescriptionDI { get; set; }

        public ResultModel()
        {
        }
    }
}