using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAt
{
	public partial class KontrolaDatabaze
	{

		/// <summary>
		/// > 0 tabulka nalezena, vrací počet sloupců
		/// - 1 server se nepodařilo otevřít
		/// - 2 tabulku se nepodařilo otevřít
		/// </summary>
		/// <param name="connString"></param>
		/// <param name="DbSelect"></param>
		/// <returns></returns>
		public int TestExistenceDatabáze(string connString, string DbSelect)
		{
			int platna = -1;
			SqlConnection conn = null;
			try
			{
				// pokus otevřít databázi
				conn = new SqlConnection(connString);
				conn.Open();
				platna = -2;
				// pokus otevřít tabulku
				SqlCommand cmd = conn.CreateCommand();
				cmd.CommandText = DbSelect;
				SqlDataReader sdr = cmd.ExecuteReader();
				if (sdr.FieldCount > 0)
				{
					// tabulka existuje a má nejméně jeden sloupec
					platna = sdr.FieldCount;
				}
			}
			catch { }
			finally
			{
				conn.Close();
			}
			return platna;
		}
	}
}
