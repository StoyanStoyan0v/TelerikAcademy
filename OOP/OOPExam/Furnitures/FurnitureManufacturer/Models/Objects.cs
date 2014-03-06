namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.Furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException("Company name cannot be null, empty or shorter than 5 characters");
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            private set
            {
                ulong num;
                if (value.Length != 10 || !(ulong.TryParse(value, out num)))
                {
                    throw new ArgumentException("Company registration number length cannot be different than 10 and must contain only numbers");
                }
                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures { get; private set; }

        public void Add(IFurniture furniture)
        {
            this.Furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            if (this.Furnitures.Count > 0)
            {
                this.Furnitures.Remove(furniture);
            }
        }

        public IFurniture Find(string model)
        {
            IFurniture first = null;
            foreach (var item in this.Furnitures)
            {
                if(item.Model.ToLower()==model.ToLower())
                {
                    first = item;
                    break;
                }
            }

            if(first == null)
            {
                return null;
            }
            else
            {
                return first;
            }
        }

        public string Catalog()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0} - {1} - {2} {3}", this.Name, this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no" ,
                this.Furnitures.Count != 1 ? "furnitures"+ (this.Furnitures.Count==0 ? null: Environment.NewLine) : "furniture");           
            output.Append(string.Join(string.Format("{0}",Environment.NewLine), 
                this.Furnitures.OrderBy(item=>item.Price).ThenBy(item=>item.Model)));
            return output.ToString();
        }
    }

    public abstract class Furniture : IFurniture
    {
        private string model;
        private decimal price;
        private decimal height;
        private MaterialType material;
        
        protected Furniture(string model, MaterialType material, decimal price, decimal height)
        {
            this.Model = model;
            this.Price = price;
            this.material = material;
            this.Height = height;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("Furniture model cannot be null, empty or shorter than 3 characters");
                }
                this.model = value;
            }
        }

        public string Material { get {throw new NotImplementedException();} }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Furniture price cannot be negative or zero");
                }
                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Furniture height cannot be negative or zero");
                }
                this.height = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendFormat("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, ",
                this.GetType().Name, this.Model, this.material, this.Price, this.Height);

            return output.ToString();
        }
    }

    public class Table : Furniture, ITable
    {
        private decimal length;
        private decimal width;

        public Table(string model, MaterialType material, decimal price, decimal height, decimal length, decimal width) : 
            base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Table length cannot be negative or zero");
                }
                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Table width cannot be negative or zero");
                }
                this.width = value;
            }
        }

        public decimal Area
        {
            get
            {
                return this.Length * this.Width;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0}Length: {1}, Width: {2}, Area: {3}",
                base.ToString(), this.length, this.width, this.Area);
            return output.ToString();
        }
    }

    public class Chair : Furniture, IChair
    {
        private int numberOfLegs;

        public Chair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs) : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Chair legs cannot be negative or zero");
                }
                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0}Legs: {1}",
                base.ToString(), this.NumberOfLegs);
            return output.ToString();
        }
    }

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private readonly decimal initialHeight;
        private const decimal ConvertedHeight = 0.10m;

        public ConvertibleChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs) : 
            base(model, material, price, height, numberOfLegs)
        {
            initialHeight = height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            this.IsConverted = !IsConverted;
            if (IsConverted)
            {
                this.Height = ConvertedHeight;
            }
            else
            {
                this.Height = initialHeight;
            }
        }
         public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0}, State: {1}",
                base.ToString(), this.IsConverted ? "Converted" : "Normal");
            return output.ToString();
        }   
    }

    public class AdjustableChair : Chair, IAdjustableChair
    {
        public AdjustableChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs) : 
            base(model, material, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            this.Height = height;
        }
    }
}