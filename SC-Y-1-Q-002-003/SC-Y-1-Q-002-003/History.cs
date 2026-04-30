using System;

namespace SC_Y_1_Q_002_003
{
    internal class History
    {
        private int receipt_number;
        private DateTime history_date;
        private double history_grandtotal;
        private double history_discount;
        private double history_finaltotal;
        private double history_payment;
        private double history_change;

        public History(int receiptNumber, DateTime date, double grandTotal, double discount, double finalTotal, double payment, double change)
        {
            receipt_number = receiptNumber;
            history_date = date;
            history_grandtotal = grandTotal;
            history_discount = discount;
            history_finaltotal = finalTotal;
            history_payment = payment;
            history_change = change;
        }

        public int HId
        {
            get { return receipt_number; }
            set { receipt_number = (value > 0) ? value : 0; }
        }

        public DateTime HDate
        {
            get { return history_date; }
            set { history_date = value; }
        }

        public double HGtotal
        {
            get { return history_grandtotal; }
            set { history_grandtotal = (value < 0) ? 0 : value; }
        }

        public double HDiscount
        {
            get { return history_discount; }
            set { history_discount = (value < 0) ? 0 : value; }
        }

        public double HFTotal
        {
            get { return history_finaltotal; }
            set { history_finaltotal = (value < 0) ? 0 : value; }
        }

        public double HPayment
        {
            get { return history_payment; }
            set { history_payment = (value < 0) ? 0 : value; }
        }

        public double HChange
        {
            get { return history_change; }
            set { history_change = (value < 0) ? 0 : value; }
        }

        public string DisplayHistory()
        {
            return $"Receipt #{receipt_number} | Date: {history_date} | Final: ₱{history_finaltotal:N2}";
        }

        // this will be the final receipt of the product when it's already checked out. 
        public string DisplayFullReceipt()
        {
            return $"\n================ RECEIPT ================" +
                   $"\nReceipt No: {receipt_number:D4}" +
                   $"\nDate & Time: {history_date}" +
                   $"\nGrand Total: ₱{history_grandtotal:N2}" +
                   $"\nDiscount: ₱{history_discount:N2}" +
                   $"\nFinal Total: ₱{history_finaltotal:N2}" +
                   $"\nPayment: ₱{history_payment:N2}" +
                   $"\nChange: ₱{history_change:N2}" +
                   $"\n=========================================\n";
        }
    }
}