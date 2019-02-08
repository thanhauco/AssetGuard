using System;

namespace AssetGuard.Services.DTOs
{
    public class CreateTransferDto
    {
        public int AssetId { get; set; }
        public string TransferType { get; set; }
        public int? FromEmployeeId { get; set; }
        public int? ToEmployeeId { get; set; }
        public int? FromRoomId { get; set; }
        public int? ToRoomId { get; set; }
        public int InitiatedById { get; set; }
        public string Reason { get; set; }
        public string Notes { get; set; }
    }

    public class TransferHistoryDto
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public string TransferType { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public string FromEmployee { get; set; }
        public string ToEmployee { get; set; }
        public DateTime TransferDate { get; set; }
        public string InitiatedBy { get; set; }
        public string Reason { get; set; }
    }
}
