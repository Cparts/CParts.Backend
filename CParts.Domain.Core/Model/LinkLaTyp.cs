﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CParts.Domain.Core.Model
{
    public partial class LinkLaTyp
    {
        /// <summary>
        /// LAT_TYP_ID
        /// </summary>
        public int TypeId { get; set; }
        
        public Type Type { get; set; }

        /// <summary>
        /// LAT_LA_ID
        /// </summary>
        public int LinkArtId { get; set; }
        
        public LinkArt LinkArt { get; set; }

        //TODO: Investigate LAT_GA_ID
        /// <summary>
        /// LAT_GA_ID
        /// </summary>
        public int LatGaId { get; set; }
        
        [NotMapped]
        public ICollection<LinkGaStr> LGS { get; set; }
        
        /// <summary>
        /// LAT_SUP_ID
        /// </summary>
        public short? SupplierId { get; set; }
        
        public Supplier Supplier { get; set; }

        /// <summary>
        /// LAT_SORT
        /// </summary>
        public int Sort { get; set; }
    }
}