namespace Assignment_SRP_OCP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Fertilizer Calculator");
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
        public double LandAreaM2 { get; set; }
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