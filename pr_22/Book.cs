using System;
using System.Collections.Generic;
using System.Text;

namespace pr_22
{
	internal class Book
	{
		public string Title { get; set; }       
		public string Author { get; set; }      
		public string Cover { get; set; }       
		public int Count { get; set; }          
		public int Taken { get; set; }         

		public string Status
		{
			get { return $"В наличии: {Count}, На руках: {Taken}"; }
		}
	}
}
