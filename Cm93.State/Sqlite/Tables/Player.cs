﻿/*
        Copyright © Iain McDonald 2013-2015
        This file is part of Cm93.

        Cm93 is free software: you can redistribute it and/or modify
        it under the terms of the GNU General Public License as published by
        the Free Software Foundation, either version 3 of the License, or
        (at your option) any later version.

        Cm93 is distributed in the hope that it will be useful,
        but WITHOUT ANY WARRANTY; without even the implied warranty of
        MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
        GNU General Public License for more details.

        You should have received a copy of the GNU General Public License
        along with Cm93. If not, see <http://www.gnu.org/licenses/>.
*/
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cm93.State.Sqlite.Tables
{
	public class Player
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public long Age { get; set; }
		public long ReleaseValue { get; set; }
		public long NumericValue { get; set; }

		[Key]
		[Column(Order = 1)]
		public long PlayerID { get; set; }

		public long Number { get; set; }
		public long Position { get; set; }

		[ForeignKey("Team")]
		public long TeamID { get; set; }
		public float LocationX { get; set; }
		public float LocationY { get; set; }

		public virtual Team Team { get; set; }
	}
}
