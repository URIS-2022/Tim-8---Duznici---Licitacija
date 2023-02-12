using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlot.API.Models
{
    public class LandModel

    {    /// <summary>
         /// Guid parcele
         /// </summary>
        public Guid LandGuid { get; set; }

        /// <summary>
        /// Povrsina parcele
        /// </summary>
        public int TotalArea { get; set; }

        /// <summary>
        /// ID opstine
        /// </summary>
        public string MunicipalityId { get; set; }

        /// <summary>
        /// Naziv opstine
        /// </summary>
        public string Municipality { get; set; }

        /// <summary>
        /// Lista nepokretnosti
        /// </summary>
        public string RealEstateNumber { get; set; }

        /// <summary>
        /// Kultura
        /// </summary>
        public string LandCulture { get; set; }

        /// <summary>
        /// Klasa 
        /// </summary>
        public string LandClass { get; set; }

        /// <summary>
        /// Obradivnost zemljista 
        /// </summary>
        public string LandProcessing { get; set; }

        /// <summary>
        /// Zasticena zona 
        /// </summary>
        public string ProtectedZone { get; set; }

        /// <summary>
        /// Tip svojine
        /// </summary>
        public string PropertyType { get; set; }


        /// <summary>
        /// Navodnjavanje
        /// </summary>
        public Guid Drainage { get; set; }

       
    }
}