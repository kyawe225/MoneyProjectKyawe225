namespace MoneyProject.Api.Model
{
    public class ExpenseCreateViewModel
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public string ExpenseTypeId { set; get; }
        public long Ammount { set; get; }

    }

    public class ExpenseListViewModel
    {
        public string Name { set; get; }
        public string ExpenseTypeName { set; get; }
        public long Ammount { set; get; }
    }
}
