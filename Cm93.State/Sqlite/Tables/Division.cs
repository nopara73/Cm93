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
	public class Division
	{
		[Key]
		[Column(Order = 1)]
		public long CompetitionID { get; set; }

		[Key]
		[Column(Order = 2)]
		//[ForeignKey("Team")]
		public long TeamID { get; set; }

		public long Wins { get; set; }
		public long Draws { get; set; }
		public long Losses { get; set; }
		public long GoalsFor { get; set; }
		public long GoalsAgainst { get; set; }
		public long GoalDifference { get; set; }
		public long Points { get; set; }

		public virtual Competition Competition { get; set; }
		public virtual Team Team { get; set; }
	}
}
