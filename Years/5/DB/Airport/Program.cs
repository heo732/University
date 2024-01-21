using Airport.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new Context())
            {
                //FillPlaneTypesAsync(context).GetAwaiter();
                //var planeTypes = GetPlaneTypes(context);
                //var result = Queries.Q1(context);
            }
        }

        public static async Task FillPlaneTypesAsync(Context context)
        {
            await context.PlaneTypes.AddRangeAsync(new List<PlaneType>
            {
                new PlaneType { Value = "Airbus" },
                new PlaneType { Value = "Boeing" }
            }).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public static List<PlaneType> GetPlaneTypes(Context context)
        {
            return context.PlaneTypes.ToList();
        }
    }
}