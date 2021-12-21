﻿using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Legalios.Props
{
    public class PropsSalary : PropsBase, IPropsSalary
    {
        public static IPropsSalary Empty()
        {
            return new PropsSalary(VERSION_ZERO);
        }
        public PropsSalary(Int16 version) : base(version)
        {
            this.WorkingShiftWeek = 0;
            this.WorkingShiftTime = 0;
            this.MinMonthlyWage = 0;
            this.MinHourlyWage = 0;
        }
        public PropsSalary(VersionId version,
            Int32 workingShiftWeek, Int32 workingShiftTime,
            Int32 minMonthlyWage, Int32 minHourlyWage) : base(version)
        {
            this.WorkingShiftWeek = workingShiftWeek;
            this.WorkingShiftTime = workingShiftTime;
            this.MinMonthlyWage = minMonthlyWage;
            this.MinHourlyWage = minHourlyWage;
        }
        public Int32 WorkingShiftWeek { get; set; }
        public Int32 WorkingShiftTime { get; set; }
        public Int32 MinMonthlyWage { get; set; }
        public Int32 MinHourlyWage { get; set; }

        public bool ValueEquals(IPropsSalary other)
        {
            if (other == null)
            {
                return false;
            }
            return (this.WorkingShiftWeek == other.WorkingShiftWeek &&
                    this.WorkingShiftTime == other.WorkingShiftTime &&
                    this.MinMonthlyWage == other.MinMonthlyWage &&
                    this.MinHourlyWage == other.MinHourlyWage);
        }
    }
}
