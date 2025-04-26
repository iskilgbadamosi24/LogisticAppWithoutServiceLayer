namespace Shipping_System.Models
{
    public class OrderState
    {
        //This is the type of order status. We will also put them as local or international delivery status.
        public int Id { get; set; }
        
        public string Name { get; set; }

        public bool IsDelievered { get; set; } = false;


    }
}
