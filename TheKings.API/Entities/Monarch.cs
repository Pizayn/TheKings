using System.ComponentModel.DataAnnotations;
using TheKings.API.Data;

namespace TheKings.API.Entities
{
    public class Monarch : EntityBase
    {
        public int Id { get; set; }
        public string Nm { get; set; }
        public string Cty { get; set; }
        public string Hse { get; set; }
        public string Yrs { get; set; }

        public int ReignLength
        {
            get
            {
                if (string.IsNullOrEmpty(Yrs))
                {
                    return 0;
                }

                var parts = Yrs.Split('-');
                if (!int.TryParse(parts[0], out int startYear))
                {
                    return 0; 
                }

                int endYear;
                if (parts.Length > 1 && int.TryParse(parts[1], out endYear))
                {
                }
                else
                {
                    endYear = (parts.Length == 1) ? startYear : DateTime.Now.Year; 
                }

                return endYear - startYear;
            }
        }

    }
}
