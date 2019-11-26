using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeanTechniques
{
    public class Validation
    {
        public static string validateEntry(string albumID)
        {
            string returnString = null;
            int id;
            bool numeric = true;

            if (String.IsNullOrWhiteSpace(albumID))
            {
                returnString = "No Entry, please try again";
            }
            else
            {

                numeric = int.TryParse(albumID, out id);
                if (numeric == true)
                {
                    int checkRange = int.Parse(albumID);
                    if (checkRange > 100 || checkRange <= 0)
                    {
                        returnString = "Album not within range, please try again";
                    }
                }
                else
                {
                    returnString = "Not a number, please try again";
                }
            }
            return returnString;
        }
    }
}
