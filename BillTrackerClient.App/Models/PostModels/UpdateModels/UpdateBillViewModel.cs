﻿using BillTrackerClient.App.CustomAnnotations;

namespace BillTrackerClient.App.Models.PostModels.UpdateModels
{
    public class UpdateBillViewModel : PostBillViewModel
    {
        [NumberMustBeGreaterThanZero]
        public int BillId { get; set; }
    }
}
