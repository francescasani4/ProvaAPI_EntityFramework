using System;
namespace ProvaAPI_EntityFramework.Model
{
	public class LoanModel
	{
        public int IdLoan { get; set; }

        public int IdBook { get; set; }

        public int IdUser { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReturned { get; set; }
    }
}

