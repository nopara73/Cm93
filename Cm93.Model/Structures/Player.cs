﻿/*
        Copyright © Iain McDonald 2013-2016
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
using Cm93.Model.Attributes;
using Cm93.Model.Enumerations;
using Cm93.Model.Interfaces;
using System;
using System.Globalization;
using System.Linq;

namespace Cm93.Model.Structures
{
	public class Player : ICloneable, IGameInfo
	{
		private Lazy<PlayerIndex> lazyPlayerIndex;

		public Player()
		{
			ResetPlayerIndex();
		}

		public void ResetPlayerIndex()
		{
			lazyPlayerIndex = new Lazy<PlayerIndex>(() => new PlayerIndex(Number, TeamName));
		}

		public PlayerIndex Index { get { return lazyPlayerIndex.Value; } }

		public string FirstName { get; set; }
		public string LastName { get; set; }

		[DataGridRowMetric(Order = 1)]
		public int Number { get; set; }

		[DataGridRowMetric(Order = 2)]
		public string TeamName { get; set; }

		[DataGridRowMetric(Order = 3)]
		public string FullName
		{
			get
			{
				return string.Format(CultureInfo.CurrentCulture, "{0} {1}", FirstName, LastName);
			}
		}

		[DataGridRowMetric(Order = 4)]
		public int Age { get; set; }

		[DataGridRowMetric(Order = 5)]
		public double Rating { get; set; }
		[DataGridRowMetric(Order = 6)]
		public int Goals { get; set; }

		[DataGridRowMetric(Order = 7)]
		public Position Position { get; set; }
		[DataGridRowMetric(Order = 8)]
		public string Nationality { get; set; }

		public Coordinate Location { get; set; }
		public Instruction Instruction { get; set; }

		[DataGridRowMetric(Order = 9)]
		public string Value
		{
			get { return string.Format(CultureInfo.CurrentCulture, "{0:c0}", NumericValue); }
		}

		public int NumericValue { get; set; }

		//	TODO: This is a very important field to keep secret. At some point change
		//	to internal and alter assembly attributes to allow the UI project access.
		public int ReleaseValue { get; set; }

		//	Cannot guarantee uniqueness of player based on any union of player fields
		//	therefore, have to include the DB index within this class.
		public int Id { get; set; }

		public int Formation { get; set; }

		public override string ToString()
		{
			return string.Format("{0} {1}.", LastName, FirstName.First().ToString(CultureInfo.CurrentCulture));
		}

		public object Clone()
		{
			return new Player
				{
					Age = this.Age,
					FirstName = this.FirstName,
					Goals = this.Goals,
					Instruction = this.Instruction,
					LastName = this.LastName,
					lazyPlayerIndex = this.lazyPlayerIndex,
					Location = new Coordinate { X = this.Location.X, Y = this.Location.Y },
					Number = this.Number,
					NumericValue = this.NumericValue,
					Position = this.Position,
					Nationality = this.Nationality,
					Rating = this.Rating,
					ReleaseValue = this.ReleaseValue,
					TeamName = this.TeamName,
					Formation = this.Formation
				};
		}
	}
}
