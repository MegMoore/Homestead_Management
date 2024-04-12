namespace Homestead_Management.Models.Animals
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int AnimalTypeId {  get; set; } 
        public virtual AnimalType? AnimalType { get; set; }

        public int GenderId { get; set; }
        public virtual Gender? Gender { get; set; }
        
        public DateOnly? DateOfBirth { get; set; } 
        public DateOnly? PurchaseDate { get; set; }
        public DateOnly? DateBred { get; set; }
        public DateOnly? DueDate { get; set; }

    }
}
