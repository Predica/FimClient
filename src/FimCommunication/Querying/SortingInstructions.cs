namespace Predica.FimCommunication.Querying
{
    public enum SortOrder
    {
        Ascending,
        Descending
    }

    public class SortingInstructions
    {
        public static readonly SortingInstructions None = new SortingInstructions(string.Empty, SortOrder.Ascending);

        public string AttributeName { get; set; }
        public SortOrder Order { get; set; }

        public SortingInstructions(string attributeName, SortOrder order)
        {
            AttributeName = attributeName;
            Order = order;
        }
    }
}