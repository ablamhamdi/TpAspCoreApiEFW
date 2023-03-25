namespace APiEntity.Entitys
{
    public class Contact
    {
     
            public int Id { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public int RestaurantId { get; set; }

            public Restaurant Restaurant { get; set; }
        
    }
}
