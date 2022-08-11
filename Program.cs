namespace Assignment_SRP_OCP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Fertilizer Calculator");

            Console.WriteLine("Input the Land Area for Maize in metre square:");
            float areaMaize = float.Parse(Console.ReadLine());
            Console.WriteLine("Input the Land Area for Pineapple in metre square:");
            float areaPineapple = float.Parse(Console.ReadLine());
            var maize = new Maize();
            maize.LandAreaM2 = areaMaize;
            var pineapple = new Pineapple();
            pineapple.LandAreaM2 = areaPineapple;
            var fert = new FertilizerApplication();
            List<Stands> stand = new List<Stands>();
            stand.Add(pineapple);
            stand.Add(maize);
            double fertAmount = fert.AmountOfFertilizerInGram(stand);
            Console.WriteLine("The required amount is: "+ fertAmount);  

        }
    }
    /// <summary>
    /// Main class for fertilizer application
    /// </summary>
    public class FertilizerApplication
    {
        /// <summary>
        /// This method calculates the amount of fertilizer required
        /// </summary>
        /// <param name="stands"></param>
        /// <returns></returns>
        public double AmountOfFertilizerInGram(List<Stands>stands)
        {
            double total = 0;
            //try catch
            try
            {
                //looping through to find the total
                foreach (var item in stands)
                {
                    total += item.NumOfStands();
                    
                }
              
            }
            catch (Exception e)
            {
                //return error message if it fails
                var error = e.Message;
            }

              return total;
        }
    }
    /// <summary>
    /// Abstract class for calculating number of stands
    /// </summary>
    public abstract class Stands
    {
        
        /// <summary>
        /// This method calculates the number of stands
        /// </summary>
        /// <returns></returns>
        public abstract int NumOfStands();

      
    }


    /// <summary>
    /// Class that inherits Stands
    /// </summary>
    public class Maize : Stands
    {
        /// <summary>
        /// Fixed value of the row
        /// </summary>
        public double LandAreaM2 { get; set; }
        public double RowSpacing { get; } = 0.75d;
        /// <summary>
        /// Fixed value of the column
        /// </summary>
        public double ColumnSpacing { get; } = 0.25d;
        //overriding the abstract method 
        public override int NumOfStands()
        {
            return (int)(LandAreaM2 / (RowSpacing * ColumnSpacing));
        }
       
    }

    /// <summary>
    /// Class that inherits Stands
    /// </summary>
    public class Pineapple : Stands
    {
        /// <summary>
        /// Fixed row of the column
        /// </summary>
        public double LandAreaM2 { get; set; }
        public double RowSpacing { get; } = 0.4d;
        /// <summary>
        /// Fixed value of the column
        /// </summary>
        public double ColumnSpacing { get; } = 0.45d;
        //overriding the abstract method 
        public override int NumOfStands()
        {
            return (int)(LandAreaM2/(RowSpacing*ColumnSpacing));
        }
    }



}