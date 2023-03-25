namespace APiEntity.Entitys
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CuisinId { get; set; }
        public int ContactId { get; set; }
        public string Adress { get; set; }


        public virtual List<Cuisin> Cuisins { get; set; }
        public virtual Contact Contact { get; set; }
    }
}