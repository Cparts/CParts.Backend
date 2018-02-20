using System;

namespace CParts.Services.Abstractions.Parts.ViewModels
{
    public class ModelViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime ProductionStartDate { get; set; }
        public DateTime ProductionEndDate { get; set; }
    }
}