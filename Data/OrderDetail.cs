namespace Data
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderID { get; set; }
        public int foodID { get; set; }
        public uint price { get; set; } 

        public virtual Food food { get; set; }

        public virtual Order order { get; set; }

    }
}