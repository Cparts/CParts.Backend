using System;
using System.Collections;
using System.Collections.Generic;

namespace CParts.Services.Abstractions.Parts.ViewModels
{
    public class SearchThirdStepViewModel
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public ICollection<ModelsViewModel> Models { get; set; } 
        
    }

    public class ModelsViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime ProductionStartDate { get; set; }
        public DateTime ProductionEndDate { get; set; }
    }
}