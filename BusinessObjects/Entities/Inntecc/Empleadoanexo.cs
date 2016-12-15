using System;
using ServiceStack.DataAnnotations;

namespace BusinessObjects.Entities
{
	[Schema("inntecc")]
	[Alias("empleadoanexo")]
	public class Empleadoanexo
	{
		[PrimaryKey]
		[AutoIncrement]
		[Alias("idempleadoanexo")]
		public  int Idempleadoanexo{ get; set; }
		public  int Idempleado{ get; set; }
		public  DateTime Fechaanexo{ get; set; }
		public  string Nombrearchivo{ get; set; }
		public  string Comentario{ get; set; }
	}
}
