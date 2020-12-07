namespace CourseStore.Core.Domain
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public string Name { get; set; }
        public int NewPrice { get; set; }
        public int CourseId { get; set; }

    }
}
